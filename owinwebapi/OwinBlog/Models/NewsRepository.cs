using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace owinwebapi.Models
{
    public class NewsRepository
    {
        public IEnumerable<News> GetAllNews()
        {
            News[] news = new News[] 
            { 
                new News { Id = 1, Title="新闻标题1", Content="新闻内容1", Author="xishuai", CreateTimeStr=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }, 
                new News { Id = 2, Title="新闻标题2", Content="新闻内容2", Author="xishuai", CreateTimeStr=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }, 
                new News { Id = 3, Title="新闻标题2", Content="新闻内容3", Author="xishuai", CreateTimeStr=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }
            };
            return news;
        }
    }
}