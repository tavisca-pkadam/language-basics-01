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
            // Console.WriteLine(equation);
            var op1 = Regex.Split(equation, @"[*,=]");
            var re_op = "";
            // Console.WriteLine(op1[0]);
            // Console.WriteLine(op1[1]);
            // Console.WriteLine(op1[2]);
            string ans = "";
            // if op1 and op2 both do not contain ?

            if(op1[0].Contains("?") )
            {
                // Console.WriteLine("op1  contains ?");
                
                // System.Console.WriteLine(Int32.Parse(op1[2]) / Int32.Parse(op1[1]));
                ans = (Double.Parse(op1[2]) / Double.Parse(op1[1])).ToString();
                // System.Console.WriteLine(op1[0].IndexOf("?"));
                // System.Console.WriteLine(ans[0]);

                re_op = op1[0].Replace( '?' , ans[op1[0].IndexOf("?")] );
                
                if(ans.Equals(re_op)){
                    var x =  ans[op1[0].IndexOf("?")];
                    // Console.WriteLine(result);
                    return Int16.Parse(x.ToString());
                }else{
                    return -1;
                }
            }
            else if( op1[1].Contains("?"))
            {
                // Console.WriteLine("op2  contains ?");
                // System.Console.WriteLine(Int32.Parse(op1[2]) / Int32.Parse(op1[0]));
                ans = (Double.Parse(op1[2]) / Double.Parse(op1[0])).ToString();
                // System.Console.WriteLine(op1[1].IndexOf("?"));
                // System.Console.WriteLine(ans[0]);

                re_op = op1[1].Replace( '?' , ans[op1[1].IndexOf("?")] );
                
                if(ans.Equals(re_op)){
                    var x =  ans[op1[1].IndexOf("?")];
                    // Console.WriteLine(result);
                    return Int16.Parse(x.ToString());
                }else{
                    return -1;
                }
            }
            else{
                // Console.WriteLine("op3  contains ?");
                // System.Console.WriteLine(Int32.Parse(op1[2]) / Int32.Parse(op1[1]));
                ans = (Double.Parse(op1[0]) * Double.Parse(op1[1])).ToString();
                // Console.WriteLine(op1[1].IndexOf("?"));
                // System.Console.WriteLine(ans[0]);

                re_op = op1[2].Replace( '?' , ans[op1[2].IndexOf("?")] );
                
                if(ans.Equals(re_op)){
                    var x =  ans[op1[2].IndexOf("?")];
                    // Console.WriteLine(result);
                    return Int16.Parse(x.ToString());
                }else{
                    return -1;
                }

                
            }

        }

       
    }
}
