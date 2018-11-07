using System;
using TiempoDev.DataTypeSamples.Interactive;

namespace TiempoDev.DataTypeSamples
{
    partial class Program
    {
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
