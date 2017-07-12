using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;

namespace readdb
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ReadDB();

        }

        public void ReadDB()
        {
            //数据库连接字符串
            string conStr = "Password=123456;Persist Security Info=True;User ID=sa;Initial Catalog=Test;Data Source=.";
            //查询语句
            string sql = "select * from testt2";
            //输出的XML文件
    //        string xmlFile = "..\\output.xml";
            string id = String.Empty;
            string parentId = String.Empty;
            string name = String.Empty;
            string age = String.Empty;
            string sex = String.Empty;
            string value = String.Empty;
          Boolean notFind = true;

          try
          {
              SqlConnection conn = new SqlConnection();
              conn.ConnectionString = conStr;
              conn.Open();
              SqlCommand sqlCmd = conn.CreateCommand();
              sqlCmd.CommandType = CommandType.Text;
              sqlCmd.CommandText = sql;
              SqlDataReader reader = sqlCmd.ExecuteReader();

 
              XmlDocument doc = new XmlDocument();
                 XmlElement xe = doc.CreateElement("root");
                  //xe.SetAttribute("value", value);
                  //xe.SetAttribute("id", id);
              while (reader.Read())
              {
                  id = reader[0].ToString();
                  parentId = reader[1].ToString();
                  name = reader[2].ToString();
                  value = reader[3].ToString();
                  age = reader[4].ToString();
                  sex = reader[5].ToString().Trim();
                  

                  doc.AppendChild(xe);
                  //建立子节点
                  XmlElement department = doc.CreateElement("item");
                  department.SetAttribute("name", name);//設定属性
                  department.SetAttribute("age", age);
                  department.SetAttribute("sex", sex);
     
                  //加入至xe节点底下
                  xe.AppendChild(department);
              }

                  doc.Save("E:\\code\\c#\\Test.xml");
          }
          catch (Exception xe)
          {
              Console.WriteLine(xe.Message);
              Console.ReadKey();
          }
            finally
            {
            }
        }
    }
}