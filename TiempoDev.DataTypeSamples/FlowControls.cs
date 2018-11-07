using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiempoDev.DataTypeSamples.Generic;

namespace TiempoDev.DataTypeSamples
{
    public class FlowControls : ISample
    {
        private readonly string[] _fruits;

        public FlowControls()
        {
            _fruits = new string[] { "apple", "orange", "grape", "banana", "pear", "kiwi" };
        }

        public string GetDescription()
        {
            return "Flow controls (for/foreach loops, while loops, if/else statements)";
        }

        public string GetSampleData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("In this sample we will be showing some examples using flow controls");
            sb.AppendLine("Simple for loop sample: Print all fruits available:");

            PrintFruitsForLoop(sb);

            sb.AppendLine();
            sb.AppendLine("foreach loop are simpler to write/handle but you'll lose the current index position in the loop");
            sb.AppendLine("Printing all fruits using the foreach loop:");

            PrintFruitsForEachLoop(sb);

            sb.AppendLine();
            sb.AppendLine("Now, will be showing array element finding using while loops");
            sb.AppendLine("We'll look for 'orange' in the array:");
            sb.Append("orange: ");
            FindInArrayWhileLoop("orange", sb);

            sb.AppendLine();
            sb.AppendLine("Now, we will dig into switch statements using the fruits as examples which has seeds or not");
            sb.Append("apple: ").AppendLine(CheckFruitsForSeeds("apple"));
            sb.Append("banana: ").AppendLine(CheckFruitsForSeeds("banana"));
            sb.Append("watermelon: ").AppendLine(CheckFruitsForSeeds("watermelon"));

            sb.AppendLine();
            sb.AppendLine("And finally, let's look at the if/else statement");
            sb.AppendLine("One of these was already implemented in the while loop sample");
            sb.AppendLine("Let try finding some more fruits again:");

            sb.Append("kiwi: ");
            FindInArrayWhileLoop("kiwi", sb);

            sb.Append("watermelon: ");
            FindInArrayWhileLoop("watermelon", sb);

            return sb.ToString();
        }

        private void PrintFruitsForLoop(StringBuilder sb)
        {
            for (int i = 0; i < _fruits.Length; i++)
            {
                sb.AppendLine($"[{i}] : {_fruits[i]}");
            }
        }

        private void PrintFruitsForEachLoop(StringBuilder sb)
        {
            foreach (string fruit in _fruits)
            {
                sb.AppendLine(fruit);
            }
        }

        private void FindInArrayWhileLoop(string criteria, StringBuilder sb)
        {
            int count = 0;
            while (count <= _fruits.Length)
            {
                if (criteria == _fruits[count])
                    break;
                count++;
            }

            if (count > _fruits.Length)
                sb.AppendLine("Value was not found in the array");
            else
                sb.AppendLine($"Value has been found at position {count}");
        }

        private string CheckFruitsForSeeds(string fruit)
        {
            string result = "";
            switch (fruit)
            {
                case "apple":
                case "orange":
                case "grape":
                case "pear":
                case "kiwi":
                    result = "This fruit has seeds";
                    break;
                case "banana":
                    result = "This fruit doesn't have seeds";
                    break;
                default:
                    result = "No fruit was found or specified";
                    break;
            }

            return result;
        }
    }
}
