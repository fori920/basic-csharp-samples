using System.Collections;
using System.Collections.Generic;
using System.Text;
using TiempoDev.DataTypeSamples.Generic;

namespace TiempoDev.DataTypeSamples
{
    public class Collections : IWritableSample
    {
        // ArrayList is a non-generic type of collection in C#. It can contain elements of any data types.
        private ArrayList _objectList;
        // The List<T> collection is the same as an ArrayList except that List<T> is a generic collection whereas ArrayList is a non-generic collection. 
        private List<string> _genericList;
        // Primitive array; statically defined (its size is fixed at assigment/re-assigment)
        private string[] _primitiveArray;

        public Collections()
        {
            _objectList = new ArrayList();
            _genericList = new List<string>();
            // we will start the primitive array with some sample values like fruit names
            _primitiveArray = new string[] { "apple", "orange", "grape", "banana" };
            // and add some data to the object list with random data types
            _objectList.Add(1);
            _objectList.Add("two");
            _objectList.Add(3L);
            _objectList.Add('4');
            _objectList.Add(true);
        }


        public void AddElement(string element)
        {
            // In this sample, we will be adding elements to the generic list as requested.
            _genericList.Add(element);
        }

        public string GetDescription()
        {
            return "Collections in C# (generic, ArrayList and arrays)";
        }

        public string GetSampleData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("There are several array/collection implementation")
                .AppendLine("This sample will mention the common ones:").AppendLine();

            // Generic List type output display

            sb.AppendLine("Generic Lists: strongly-typed lists which accepts values from the specified type")
                .AppendLine("Printing samples provided:");

            foreach (string item in _genericList)
                sb.AppendLine(item);

            // Array list type output display

            sb.AppendLine() // add some space
                .AppendLine("Array Lists: data type-agnostic collection.")
                .AppendLine("Printing some samples:");

            foreach (object item in _objectList)
                sb.AppendFormat("Type: {0}, Value: {1}", item.GetType(), item).AppendLine();

            // Array type output display

            sb.AppendLine("Arrays: a fixed size collection which commonly uses indexes to access its items.")
                .AppendLine("Here is an example string array data:");

            for (int i = 0; i < _primitiveArray.Length; i++)
                sb.AppendFormat("[{0}]: {1}", i, _primitiveArray[i]).AppendLine();
            
            return sb.ToString();
        }
    }
}
