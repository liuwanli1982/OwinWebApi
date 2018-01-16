using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            using (var client = new HttpClient())
            {
              //  client.BaseAddress = new Uri("http://localhost:11493/");
                client.BaseAddress = new Uri("http://192.168.0.11:8012/");
              ////  http://192.168.0.11:8012/api/News/GetAllNews
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

                string xmlString = await client.GetStringAsync("api/News/GetAllNews");
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                XmlNodeList nodeList = xmlDoc.GetElementsByTagName("News");
                foreach (XmlNode node in nodeList)
                {
                    Console.WriteLine("新闻ID：" + node.SelectSingleNode("Id").InnerText);
                    Console.WriteLine("新闻标题：" + node.SelectSingleNode("Title").InnerText);
                    Console.WriteLine("新闻内容：" + node.SelectSingleNode("Content").InnerText);
                    Console.WriteLine("作者：" + node.SelectSingleNode("Author").InnerText);
                    Console.WriteLine("新闻发布时间：" + node.SelectSingleNode("CreateTime").InnerText);
                    Console.WriteLine("======================");
                }
                Console.ReadKey();
                //Stream stream = await client.GetStreamAsync("api/News/GetNewsByID/1");
                //if (stream != null)
                //{
                //    StreamReader streamReader = new StreamReader(stream);
                //    string theLine = null;
                //    while ((theLine = streamReader.ReadLine()) != null)
                //    {
                //    }
                //}
            }
        }
    }
}
