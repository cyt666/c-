using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
         
            var input = Console.ReadLine();
            string sss = pipei(input);
            Console.WriteLine(sss);

            Console.ReadKey();
            
        }
        static String pipei(String s)
        {
            String ss = s;
            int se = s.Length - 1;

            if (!(s[se] > 64 && s[se] < 124))
            {
               
                if (s.Substring(0, 1) == "0") ss = ss.Substring(1, se) + "," + "Y";
                else ss = ss + "," + "Y";
                if (!isNumeric(s.Substring(0, s.Length)))
                    ss = "格式不匹配";

            }
            else
            {
                if (!isNumeric(s.Substring(0, se)))
                {
                    ss = "格式不匹配";
                    return ss;
                }


                if (s[se] != 89 && s[se] != 121 && s[se] != 77 && s[se] != 109 && s[se] != 87 && s[se] != 119 && s[se] != 68 && s[se] != 100 && s[se] != 72 && s[se] != 104)
                {
                    ss = "单位不匹配";
                    return ss;
                }

               if (s.Substring(0, 1) == "0") ss = ss.Substring(1, se-1) + "," +s[se];
               else ss = ss.Substring(0, se) + "," + s[se];
            }
            
            return ss;
        }
        public static bool isNumeric(String str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]))
                {
                    return false;
                }
            }
            return true;
        }
     

    }
}
