using System;
using TiempoDev.DataTypeSamples.Utils;

namespace TiempoDev.DataTypeSamples
{
    partial class Program
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
    }
}
