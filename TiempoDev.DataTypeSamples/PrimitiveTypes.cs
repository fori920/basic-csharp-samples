using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiempoDev.DataTypeSamples
{
    public class PrimitiveTypes : ISample
    {
        // System.Boolean value type : Default = false
        private bool _boolVar;

        // Numeric types
        // Signed types (number with ability to enter negative values)
        // System.SByte value type : Default = 0
        private sbyte _sbyteVar;
        // System.Int16 value type : Default = 0
        private short _shortVar;
        // System.Int32 value type : Default = 0
        private int _intVar;
        // System.Int64 value type : Default = 0L (L represents long type)
        private long _longVar;

        // Unsigned types (numbers which start from 0; negative values cannot be entered)
        // System.Byte value type : Default = 0
        private byte _byteVar;
        // System.Uint16 value type : Default = 0
        private ushort _ushortVar;
        // System.Uint32 value type : Default = 0
        private uint _uintVar;
        // System.UInt64 value type : Default = 0L  (L represents ulong type)
        private ulong _ulongVar;

        // Floating point number types
        // System.Single value type (32-bit precision floating number type) : Default 0.0F (F represents float type)
        private float _floatVar;
        // System.Double value type (64-bit precision floating number type) : Default 0.0D (D represents float type)
        private double _doubleVar;

        // System.Char value type (Unicode 16-bit character) : Default = '\0' (a.k.a. a null value)
        private char _charVar;
        // System.Decimal value type (128-bit floating point number with more precision and a less range;
        // suitable for money calculations) : Default 0.0M (M represents decimal type)
        private decimal _decimalVar;

        public PrimitiveTypes()
        {
            // Sample value initialization
            _sbyteVar = sbyte.MaxValue;
            _shortVar = short.MaxValue;
            _intVar = int.MaxValue;
            _longVar = long.MaxValue;

            _byteVar = byte.MaxValue;
            _ushortVar = ushort.MaxValue;
            _uintVar = uint.MaxValue;
            _ulongVar = ulong.MaxValue;

            _floatVar = float.MaxValue;
            _doubleVar = double.MaxValue;

            _charVar = 'A';
            _decimalVar = decimal.MaxValue;
        }

        public string GetDescription()
        {
            return "Primitive data types found in C#";
        }

        public string GetSampleData()
        {
            var sb = new StringBuilder();

            sb.AppendFormat("{0}, {1}", _sbyteVar.GetType(), _sbyteVar).AppendLine()
                .AppendFormat("{0}, {1}", _shortVar.GetType(), _shortVar).AppendLine()
                .AppendFormat("{0}, {1}", _intVar.GetType(), _intVar).AppendLine()
                .AppendFormat("{0}, {1}", _longVar.GetType(), _longVar).AppendLine()
                .AppendFormat("{0}, {1}", _byteVar.GetType(), _byteVar).AppendLine()
                .AppendFormat("{0}, {1}", _ushortVar.GetType(), _ushortVar).AppendLine()
                .AppendFormat("{0}, {1}", _uintVar.GetType(), _uintVar).AppendLine()
                .AppendFormat("{0}, {1}", _ulongVar.GetType(), _ulongVar).AppendLine()
                .AppendFormat("{0}, {1}", _floatVar.GetType(), _floatVar).AppendLine()
                .AppendFormat("{0}, {1}", _doubleVar.GetType(), _doubleVar).AppendLine()
                .AppendFormat("{0}, {1}", _charVar.GetType(), _charVar).AppendLine()
                .AppendFormat("{0}, {1}", _decimalVar.GetType(), _decimalVar);

            return sb.ToString();
        }
    }
}
