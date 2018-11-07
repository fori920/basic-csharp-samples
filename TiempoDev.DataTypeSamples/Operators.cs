using System;
using System.Text;
using TiempoDev.DataTypeSamples.Generic;

namespace TiempoDev.DataTypeSamples
{
    public class Operators : ISample
    {
        private int _numberResult;

        public Operators()
        {
            _numberResult = 0;
        }

        public string GetDescription()
        {
            return "Operators in C# (arithmetic, relational, logical, unary, etc.)";
        }

        public string GetSampleData()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Basic assigment operator (=)");
            HandleBasicAssigment(sb);

            sb.AppendLine();
            sb.AppendLine("Arithmetic operators (+ - * / %)");
            HandleArithmeticOperators(sb);

            sb.AppendLine();
            sb.AppendLine("Relational operators (== > < >= <= !=)");
            HandleRelationalOperators(sb);

            sb.AppendLine();
            sb.AppendLine("Logical operators (|| &&)");
            HandleLogicalOperator(sb);

            sb.AppendLine();
            sb.AppendLine("Unary operators (+ - ++ -- !)");
            HandleUnaryOperators(sb);

            return sb.ToString();
        }

        private void HandleUnaryOperators(StringBuilder sb)
        {
            int number = 10, result;
            bool flag = true;

            result = +number;
            sb.AppendLine($"+number = {result}");

            result = -number;
            sb.AppendLine($"-number = {result}");

            result = ++number;
            sb.AppendLine($"++number = {result}");

            result = --number;
            sb.AppendLine($"--number = {result}");

            sb.AppendLine($"!flag = {!flag}");
        }

        private void HandleLogicalOperator(StringBuilder sb)
        {
            bool result;
            int num1 = 10, num2 = 20;

            sb.AppendLine($"Numbers to evaluate: {num1}, {num2}");

            // OR operator
            sb.Append($"({num1} == {num2}) || ({num1} > 5): ");
            result = (num1 == num2) || (num1 > 5);
            sb.Append(result).AppendLine();

            // AND operator
            sb.Append($"({num1} == {num2}) && ({num1} > 5): ");
            result = (num1 == num2) && (num1 > 5);
            sb.Append(result).AppendLine();
        }

        private void HandleRelationalOperators(StringBuilder sb)
        {
            int num1 = 10;
            int num2 = 20;

            sb.AppendFormat("{0} == {1} = {2}", num1, num2, num1 == num2).AppendLine();
            sb.AppendFormat("{0} > {1} = {2}", num1, num2, num1 > num2).AppendLine();
            sb.AppendFormat("{0} < {1} = {2}", num1, num2, num1 < num2).AppendLine();
            sb.AppendFormat("{0} >= {1} = {2}", num1, num2, num1 >= num2).AppendLine();
            sb.AppendFormat("{0} <= {1} = {2}", num1, num2, num1 <= num2).AppendLine();
            sb.AppendFormat("{0} != {1} = {2}", num1, num2, num1 != num2).AppendLine();
        }

        private void HandleArithmeticOperators(StringBuilder sb)
        {
            int num1 = 5;
            int num2 = 4;

            sb.AppendFormat("{0} + {1} = {2}", num1, num2, num1 + num2).AppendLine();
            sb.AppendFormat("{0} - {1} = {2}", num1, num2, num1 - num2).AppendLine();
            sb.AppendFormat("{0} * {1} = {2}", num1, num2, num1 * num2).AppendLine();
            sb.AppendFormat("{0} / {1} = {2}", num1, num2, num1 / num2).AppendLine();
            sb.AppendFormat("{0} % {1} = {2}", num1, num2, num1 % num2).AppendLine();
        }

        private void HandleBasicAssigment(StringBuilder sb)
        {
            int value = default(int);

            sb.AppendFormat("the current default variable value is {0}", value).AppendLine();

            value = 1;

            sb.AppendFormat("the new value assigned to the variable is {0}", value).AppendLine();
        }
    }
}
