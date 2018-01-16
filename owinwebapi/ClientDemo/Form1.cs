using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ClientDemo
{
    public partial class Form1 : Form
    {
        StringBuilder str = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void but_runAPI_Click(object sender, EventArgs e)
        {
            txt_result.Text = "";
            RunAsync();
        }
        async Task RunAsyncII()
        {//http://192.168.0.11:8094/ELDWebService.asmx?op=GetMessage
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.11:8094/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
                string xmlString = await client.GetStringAsync("ELDWebService.asmx?op=GetMessage");
            }
        }
        async Task RunAsync()
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
                    string id = node.SelectSingleNode("Id").InnerText;
                    string Title = node.SelectSingleNode("Title").InnerText;
                    string Content = node.SelectSingleNode("Content").InnerText;
                    string Author = node.SelectSingleNode("Author").InnerText;
                    string CreateTime = node.SelectSingleNode("CreateTime").InnerText;
                    //+ "\r\n"
                    txt_result.Text += "新闻ID：" + node.SelectSingleNode("Id").InnerText + "\r\n";
                    txt_result.Text += "新闻标题：" + node.SelectSingleNode("Title").InnerText + "\r\n";
                    txt_result.Text += "新闻内容：" + node.SelectSingleNode("Content").InnerText + "\r\n";
                    txt_result.Text += "作者：" + node.SelectSingleNode("Author").InnerText + "\r\n";
                    txt_result.Text += "新闻发布时间：" + DateTime.Parse(node.SelectSingleNode("CreateTime").InnerText).ToString("yyyy-MM-dd HH:mm:ss") + "\r\n\r\n";
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

        private void bu_WebService_Click(object sender, EventArgs e)
        {
            hh.ELDWebServiceSoapClient op = new hh.ELDWebServiceSoapClient();
            txt_result.Text = op.GetMessage();
        }
    }
}
