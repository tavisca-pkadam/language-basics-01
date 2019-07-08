using System;
using System.Text.RegularExpressions;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        const int failed = -1;
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            var operators = Regex.Split(equation, @"[*,=]");
            var computeValue = "";
            string ans = "";
            const string questionMark = "?";

            if (operators[0].Contains(questionMark))
            {
                return SolveForFirstOperand(operators, out computeValue, out ans, questionMark);
            }
            else if (operators[1].Contains(questionMark))
            {
                return SolveForSecondOperand(operators, out computeValue, out ans, questionMark);
            }
            else
            {
                return SolveForThirdOperand(operators, out computeValue, out ans, questionMark);
            }

        }

        private static int SolveForThirdOperand(string[] operators, out string computeValue, out string ans, string questionMark)
        {
            ans = (Double.Parse(operators[0]) * Double.Parse(operators[1])).ToString();
            computeValue = operators[2].Replace('?', ans[operators[2].IndexOf(questionMark)]);

            if (ans.Equals(computeValue))
            {
                var missingValue = ans[operators[2].IndexOf(questionMark)];
                return Int16.Parse(missingValue.ToString());
            }
            else
            {
                return failed;
            }
        }

        private static int SolveForSecondOperand(string[] operators, out string computeValue, out string ans, string questionMark)
        {
            ans = (Double.Parse(operators[2]) / Double.Parse(operators[0])).ToString();
            computeValue = operators[1].Replace('?', ans[operators[1].IndexOf(questionMark)]);

            if (ans.Equals(computeValue))
            {
                var missingValue = ans[operators[1].IndexOf(questionMark)];
                return Int16.Parse(missingValue.ToString());
            }
            else
            {
                return failed;
            }
        }

        private static int SolveForFirstOperand(string[] operators, out string computeValue, out string ans, string questionMark)
        {
            ans = (Double.Parse(operators[2]) / Double.Parse(operators[1])).ToString();
            computeValue = operators[0].Replace('?', ans[operators[0].IndexOf(questionMark)]);

            if (ans.Equals(computeValue))
            {
                var missingValue = ans[operators[0].IndexOf(questionMark)];
                return Int16.Parse(missingValue.ToString());
            }
            else
            {
                return failed;
            }
        }
    }
}
