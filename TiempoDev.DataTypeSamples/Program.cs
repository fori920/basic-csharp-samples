using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TiempoDev.DataTypeSamples.Utils;

namespace TiempoDev.DataTypeSamples
{
    public class Program
    {
        internal static readonly TerminalFormatter _formatter;

        static Program()
        {
            try
            {
                TerminalFormatter.EnableWindowsVirtualTerminalSequences();
            }
            catch (Exception)
            {
                // Ignore
            }

            try
            {
                TerminalFormatter.EnableWindowsVirtualTerminalSequences(stdErr: true);
            }
            catch (Exception)
            {
                // Ignore
            }

            _formatter = new TerminalFormatter();
        }

        static void Main(string[] args)
        {
            try
            {
                SampleRunner.Build(_formatter)
                    .Register<PrimitiveTypes>("Primitive types (int, bool, char, etc.)")
                    .Register<Collections>("Collections (generic lists, array lists and arrays)")
                    .Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has ocurred: {ex.Message}");
            }

            //Thread.Sleep(TimeSpan.FromSeconds(5));
        }
    }
}
