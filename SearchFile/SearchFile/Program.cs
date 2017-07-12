using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;


namespace SearchFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("输入路径");
            String path = Console.ReadLine();
    //        Console.WriteLine("输入文件类型");
    //        String type = Console.ReadLine();
            Console.WriteLine("文件个数");
            int length = int.Parse(Console.ReadLine());
            printFile(path,length);
        }

        public static void printFile(String path, int length)
        {
     //       String typee = "*\."+type;
            FileInfo file = new FileInfo(path);
            Regex regex = new Regex(@".*\.dcm");
           

            if (File.Exists(path))
            {
                Console.WriteLine("您给定的是一个文件");
                Console.ReadKey();
            }
            else
            {
                DirectoryInfo dire = new DirectoryInfo(path);
                FileInfo[] fs = dire.GetFiles();
                FileInfo[] fss = dire.GetFiles();
                int j = 0,t=0;

                for (int i = 0; i < fs.Length; i++)
                {
                    if (regex.IsMatch(fs[i].Name))
                    {   fss[j++] = fs[i];
                //        Console.WriteLine(fs[i].Name);    //输出元素名称
                    t++;
                    }

 /*                   if (Directory.Exists(fs[i].FullName))
                    {    //判断元素是不是一个目录
                        DirectoryInfo[] dires = dire.GetDirectories(path);
                        printFile(dires[i].Name, length);    //如果是目录，继续调用本方法来输出其子目录
                    }
          */       
                }
                 try{
                    for (int k = 0; k < length; k++)
                    {
                        Console.WriteLine(fss[k].Name);
              //          Console.WriteLine(fss.Length);
                        if (k >= t)
                        {
                            Console.Clear();
                            Console.WriteLine("查询类型文件数量超过上限");
                            Console.WriteLine("共有该类型文件"+t+"个");
                        }
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.Clear();
                    Console.WriteLine("文件总个数超限");
                    Console.WriteLine("共有该类型文件" + t + "个");
                }
                 Console.ReadKey();
            }
        }
    }
}
