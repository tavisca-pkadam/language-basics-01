using System;
using System.Text.RegularExpressions;  

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
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
            Console.WriteLine(equation);
            var op1 = Regex.Split(equation, @"[*,=]");
            Console.WriteLine("op1 contains ?");
            Console.WriteLine(op1[0].Contains('?'));

            Console.WriteLine(op1[0]);
            Console.WriteLine(op1[1]);
            Console.WriteLine(op1[2]);
            string ans = "";
            // if op1 and op2 both do not contain ?
            Console.WriteLine("op1 contains ?");
            Console.WriteLine(op1[0].Contains('?'));

            if(op1[0].Contains("?") )
            {
                Console.WriteLine("op1  contains ?");
                ans = (Int32.Parse(op1[2]) / Int32.Parse(op1[0])).ToString();
                op1[0].Replace( '?' , ans[op1[0].IndexOf("?")] );

                Console.WriteLine(op1[0]);
            }
            else if( op1[1].Contains("?"))
            {
                Console.WriteLine("op2  contains ?");
                ans = (Int32.Parse(op1[2]) / Int32.Parse(op1[1])).ToString();
                op1[1].Replace( '?' , ans[op1[1].IndexOf("?")] );

                Console.WriteLine(op1[1]);
            }
            else{
                Console.WriteLine("op3  contains ?");
            }


            // if op1 or op2 contain ?



            return 0;
            // Add your code here.
        }

       
    }
}
