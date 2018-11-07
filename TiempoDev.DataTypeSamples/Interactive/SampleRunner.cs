using Nibbles.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TiempoDev.DataTypeSamples.Generic;
using TiempoDev.DataTypeSamples.Utils;

namespace TiempoDev.DataTypeSamples
{
    internal sealed class SampleRunner
    {
        private readonly IDictionary<string, ISample> _sampleList;

        private readonly StringBuilder _consoleBuffer;

        private readonly TerminalFormatter _formatter;

        private readonly int _consoleWidth;

        private readonly int _consoleHeight;

        private SampleRunner(TerminalFormatter formatter)
        {
            _sampleList = new Dictionary<string, ISample>();
            _consoleBuffer = new StringBuilder();
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));

            _consoleWidth = ConsoleUtils.ConsoleWidth;
            _consoleHeight = ConsoleUtils.ConsoleHeight;
        }

        public static SampleRunner Build(TerminalFormatter formatter)
        {
            return new SampleRunner(formatter);
        }

        public SampleRunner Register<TSample>(string name) where TSample : ISample
        {
            var instance = Activator.CreateInstance<TSample>();
            _sampleList.Add(name, instance);

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

                Thread.Sleep(TimeSpan.FromSeconds(5));
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

            int counter = 1;
            foreach (var sample in _sampleList)
            {
                sb.AppendLine($" [{counter}]: {sample.Key}");
            
                counter++;
            }

            sb.Append(_formatter.SetCursorPosition(1, _consoleHeight));

            sb.Append("Press Enter to exit");
        }

        private void FlushConsoleBuffer()
        {
            //this.writeConsoleDelegate(this.consoleBuffer.ToString(), false);
            Console.Out.Write(_consoleBuffer.ToString());
            _consoleBuffer.Clear();
        }

        private void RunSample(int selectedSample)
        {

        }

    }
}
