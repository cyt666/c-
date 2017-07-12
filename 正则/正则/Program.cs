using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace zheng
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
            Regex regex = new Regex(@"([0-9]{1,})([ymwdhYMWDH])");
             Regex regex2 = new Regex(@"[0-9]");

             if (regex.IsMatch(s) && !regex2.IsMatch(s.Substring(se))) ss = ss.Substring(0, se) + "," + s[se];
             else if (regex2.IsMatch(s.Substring(se))) ss = ss + "," + "Y";
             else ss = "单位不匹配";
            if (s == null) ss = "输入为空";
            return ss;
        }
    }
}
