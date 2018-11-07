using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoDev.DataTypeSamples.Generic
{
    public interface IWritableSample : ISample
    {
        void AddElement(string element);

        void Clear();
    }
}
