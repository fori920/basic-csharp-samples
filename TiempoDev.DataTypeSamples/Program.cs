using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TiempoDev.DataTypeSamples.Interactive;
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
                    .Register<PrimitiveTypes>('1')
                    .Register<Collections>('2')
                    .Register<FlowControls>('3')
                    .Register<Operators>('4')
                    .Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error has ocurred: {ex.ToString()}");
                throw;
            }
        }
    }
}
