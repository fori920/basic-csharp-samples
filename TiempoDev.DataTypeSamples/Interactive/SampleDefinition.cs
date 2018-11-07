using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoDev.DataTypeSamples.Generic;

namespace TiempoDev.DataTypeSamples.Interactive
{
    internal class SampleDefinition
    {
        public string Name { get; set; }
        public ISample Instance { get; set; }
        public char KeyBind { get; set; }
    }
}
