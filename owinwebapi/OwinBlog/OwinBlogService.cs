using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace OwinBlog
{
    public class OwinBlogService
    {


        readonly Timer _timer;

        public OwinBlogService()
        {
            RunService();
            WriteFile("OwinBlogService","启动服务"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            //  _timer = new Timer(1000) { AutoReset = true };

            // _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} and all is well", DateTime.Now);

        }
        public void WriteFile(string filename, string content)
        {
            FileStream fs = new FileStream(@"d:\" + filename + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.BaseStream.Seek(0, SeekOrigin.End);
            sw.WriteLine(DateTime.Now.ToString() + content + "\n");

            sw.Flush();
            sw.Close();
            fs.Close();

            /*文件过大删除文件*/
            string path = @"d:\" + filename + ".txt";
            System.IO.FileInfo fileInfo = null;
            fileInfo = new System.IO.FileInfo(path);
            /*单位KB*/
            string fileSize = System.Math.Ceiling(fileInfo.Length / 1024.0) + " KB";
            /*单位转换成MB*/
            double fileSizeNum = System.Math.Ceiling(fileInfo.Length / (1024.0 * 1024.0));
            /*大于等于2mb删除日志文件*/
            if (fileSizeNum >= 2)
            {
                File.Delete(path);
            }


        }
        public void Start()
        {
            RunService();
       
            //  _timer.Start(); 
        }

        public void Stop()
        {
            //  _timer.Stop(); 
        }

        public void RunService()
        {
            try
            {
                string Host = ConfigurationSettings.AppSettings["Host"].ToString();
                // string baseAddress = "http://192.168.0.11:9000/";
                string baseAddress = "http://localhost:9000/";
                baseAddress = Host;
                //string baseAddress = "http://+:9000/"; //绑定所有地址，外网可以用ip访问 需管理员权限
                // 启动 OWIN host 
                WebApp.Start<Startup>(url: baseAddress);
                Console.WriteLine("程序已启动,按任意键退出II");
                WriteFile("OwinBlogService", "程序已启动,按任意键退出" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                Console.Write(ex);
                Console.ReadLine();
            }
        }
    }
}
