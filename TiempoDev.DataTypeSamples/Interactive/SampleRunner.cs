using Nibbles.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TiempoDev.DataTypeSamples.Generic;
using TiempoDev.DataTypeSamples.Utils;

namespace TiempoDev.DataTypeSamples.Interactive
{
    internal sealed class SampleRunner
    {
        private readonly IDictionary<char, SampleDefinition> _sampleList;

        private readonly StringBuilder _consoleBuffer;

        private readonly TerminalFormatter _formatter;

        private readonly int _consoleWidth;

        private readonly int _consoleHeight;

        private SampleRunner(TerminalFormatter formatter)
        {
            _sampleList = new Dictionary<char, SampleDefinition>();
            _consoleBuffer = new StringBuilder();

            if (formatter == null) throw new ArgumentNullException(nameof(formatter));
            _formatter = formatter;

            _consoleWidth = ConsoleUtils.ConsoleWidth;
            _consoleHeight = ConsoleUtils.ConsoleHeight;
        }

        public static SampleRunner Build(TerminalFormatter formatter)
        {
            return new SampleRunner(formatter);
        }

        public SampleRunner Register<TSample>(char charBinding) where TSample : ISample
        {
            var instance = Activator.CreateInstance<TSample>();
            var definition = new SampleDefinition
            {
                Name = instance.GetDescription(),
                Instance = instance,
                KeyBind = charBinding
            };
            _sampleList.Add(definition.KeyBind, definition);

            return this;
        }

        public void Run()
        {
            if (_sampleList.Count == 0) // if it's empty, abort run
                throw new ArgumentException("There are no samples registered. Aborting...");

            // Switch to the alternate screen buffer.
            _consoleBuffer.Append(_formatter.SwitchAlternateScreenBuffer(true));
            // Hide the cursor.
            _consoleBuffer.Append(_formatter.SetCursorVisibility(false));

            try
            {
                // Create the initial sample menu
                CreateSampleMenu(_consoleBuffer);
                FlushConsoleBuffer();

                ConsoleKeyInfo keyPressed;

                do
                {
                    keyPressed = Console.ReadKey(true);

                    var keyChar = keyPressed.KeyChar;

                    var selectedSample = _sampleList.Where(x => x.Key == keyChar).Select(x => x.Value).SingleOrDefault();

                    if (selectedSample != null)
                    {
                        RunSample(selectedSample.Instance);
                        
                        // After the sample has run, press any key to continue.
                        Console.ReadKey(true);

                        // Clear the console and recreate the main menu.
                        Console.Clear();

                        // Clear the sample data if it's an interactive sample.
                        var writable = selectedSample as IWritableSample;
                        if (writable != null) writable.Clear();

                        CreateSampleMenu(_consoleBuffer);
                        FlushConsoleBuffer();
                    }

                } while (keyPressed.Key != ConsoleKey.Enter);
            }
            finally
            {
                _consoleBuffer.Append(_formatter.SwitchAlternateScreenBuffer(false));
                _consoleBuffer.Append(_formatter.SetCursorVisibility(true));
                _consoleBuffer.Append(_formatter.Format(0));
                FlushConsoleBuffer();
            }
            
        }

        private void CreateSampleMenu(StringBuilder sb)
        {
            sb.Append(_formatter.SetCursorPosition(1,1));
            sb.AppendLine("Please select a sample to begin.");

            sb.AppendLine();

            foreach (var sample in _sampleList)
                sb.AppendLine($" [{sample.Value.KeyBind}]: {sample.Value.Name}");

            sb.Append(_formatter.SetCursorPosition(1, _consoleHeight));

            sb.Append("Press Enter to exit");
        }

        private void FlushConsoleBuffer()
        {
            Console.Out.Write(_consoleBuffer.ToString());
            _consoleBuffer.Clear();
        }

        private void RunSample(ISample selectedSample)
        {
            // Show the sample contents
            Console.Clear();

            if (selectedSample is IWritableSample)
            {
                _consoleBuffer.AppendLine("You can interact with this sample by entering some items. Press [Enter] when done.");
                ReadConsoleData(selectedSample as IWritableSample);
            }
            
            _consoleBuffer.Append(selectedSample.GetSampleData());
            _consoleBuffer.AppendLine();
            // Finalize sample
            _consoleBuffer.Append(_formatter.Format(TerminalFormatting.BackgroundRed, TerminalFormatting.ForegroundWhite));
            _consoleBuffer.Append("[End of sample]");
            _consoleBuffer.Append(_formatter.Format(0));
            _consoleBuffer.AppendLine();
            _consoleBuffer.AppendLine("Sample has ended. Press any key to continue...");

            FlushConsoleBuffer();
        }

        private void ReadConsoleData(IWritableSample sample)
        {
            // Because this sample needs some interactive, we will show the console cursor.
            _consoleBuffer.Append(_formatter.SetCursorVisibility(true));

            string data = ""; // data to be read everytime
            bool reading = true; // if set to false, the sample stops reading data and continues with the execution
            int counter = 0; // Up to 16 items limit to be entered
            while (reading)
            {
                counter++;

                _consoleBuffer.AppendFormat("[{0:D2}]: Enter a value: ", counter);
                FlushConsoleBuffer();

                data = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(data) || counter > 16)
                {
                    reading = false;
                    continue;
                }
                else
                {
                    sample.AddElement(data);
                }
            }

            // We don't need the cursor anymore, so hide it
            _consoleBuffer.Append(_formatter.SetCursorVisibility(false));
            _consoleBuffer.AppendLine("=================================");

            FlushConsoleBuffer();
        }
    }
}
