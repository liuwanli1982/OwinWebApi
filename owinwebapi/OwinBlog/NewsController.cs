using Newtonsoft.Json;
using owinwebapi.Controllers;
using owinwebapi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinBlog
{
    public class NewsController : ApiController
    {
        /// <summary>
        /// GET获取全部新闻
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllNews()
        {
            var news = new NewsRepository().GetAllNews();
            return new HttpResponseMessage()
            {
                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument<News>(news, "NewsRoot"))
            };
        }

        /// <summary>
        /// GET获取指定ID新闻
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetNewsByID(int ID)
        {
            var news = new NewsRepository().GetAllNews().Where((p) => p.Id == ID);
            string json = JsonConvert.SerializeObject(news);
            HttpResponseMessage result1 = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
            return result1;
            return new HttpResponseMessage()
            {

                RequestMessage = Request,
                Content = new XmlContent(SimpleXmlConverter.ToXmlDocument<News>(news, "NewsRoot"))
            };
        }


        /// <summary>
        /// GET获取指定ID新闻
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public string GetNewsByIDII(int ID)
        {
            var news = new NewsRepository().GetAllNews().Where((p) => p.Id == ID);
            string json = JsonConvert.SerializeObject(news);
            HttpResponseMessage result1 = new HttpResponseMessage { Content = new StringContent(json, Encoding.GetEncoding("UTF-8"), "application/json") };
            return json;

        }
    }
}
