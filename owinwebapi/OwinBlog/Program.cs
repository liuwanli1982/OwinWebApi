using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace OwinBlog
{
    class Program
    {
        static void Main(string[] args)
        {
            //OwinBlogService bllOwinBlogService = new OwinBlogService();
            //bllOwinBlogService.RunService();
            //return;
            HostFactory.Run(x =>                                             //1.我们用HostFactory.Run来设置一个宿主主机。我们初始化一个新的lambda表达式X，来显示这个宿主主机的全部配置。
            {

                x.Service<OwinBlogService>(s =>                                 　　//2.告诉Topshelf ，有一个类型为“towncrier服务”,通过定义的lambda 表达式的方式，配置相关的参数。
                {

                    s.ConstructUsing(name => new OwinBlogService());      　　　　//3.告诉Topshelf如何创建这个服务的实例，目前的方式是通过new 的方式，但是也可以通过Ioc 容器的方式：getInstance<towncrier>()。

                    s.WhenStarted(tc => tc.Start());                       //4.开始 Topshelf 服务。

                    s.WhenStopped(tc => tc.Stop());                       //5.停止 Topshelf 服务。

                });

                x.RunAsLocalSystem();                                         //6.这里使用RunAsLocalSystem() 的方式运行，也可以使用命令行(RunAsPrompt())等方式运行。

                x.SetDescription("11Sample Topshelf Host and Owin");             　　　　 //7.设置towncrier服务在服务监控中的描述。

                x.SetDisplayName("11Topshelf_Owin");                                    //8.设置towncrier服务在服务监控中的显示名字。

                x.SetServiceName("11Topshelf_Owin");                                    //9.设置towncrier服务在服务监控中的服务名字。

            });

            //var host = HostFactory.New(x =>
            //{
            //   // x.EnableDashboard(); //有问题则注释掉该行
            //    x.Service<TownCrier>(s =>
            //    {
            //        s.ConstructUsing(name => new TownCrier());
            //        s.WhenStarted(tc =>
            //        {
            //         tc.start();
            //        });

            //        //s.SetServiceName("SampleService");//有问题则注释掉该行


            //        //s.WhenStopped(tc => tc.Stop());
            //    });
                
            //    x.RunAsLocalSystem();
            //    x.SetDescription("SampleService Description");
            //    x.SetDisplayName("SampleService");
            //    x.SetServiceName("SampleService");
            //});

            //host.Run();
            //try
            //{
            //    string Host = ConfigurationSettings.AppSettings["Host"].ToString();
            //    // string baseAddress = "http://192.168.0.11:9000/";
            //    string baseAddress = "http://localhost:9000/";
            //    baseAddress = Host;
            //    //string baseAddress = "http://+:9000/"; //绑定所有地址，外网可以用ip访问 需管理员权限
            //    // 启动 OWIN host 
            //    WebApp.Start<Startup>(url: baseAddress);
            //    Console.WriteLine("程序已启动,按任意键退出");
            //    Console.ReadLine(); 
            //}
            //catch (Exception ex )
            //{

            //    Console.Write(ex);
            //    Console.ReadLine();
            //}
          
        }
    }
}
