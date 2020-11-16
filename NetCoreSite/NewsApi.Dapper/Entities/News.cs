using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Dapper.Entities
{
    public class News
    {
        public int id { get; set; }
        public Boolean havePic { get; set; }
        public string link { get; set; }
         public string imgUrl { get; set; }
        public string title { get; set; }
        public int channelId { get; set; }
        public string source { get; set; }
        public DateTime pubDate { get; set; }
        public string content { get; set; }
        public string insertUser { get; set; }
        public DateTime insertTime { get; set; }
        public string channelName { get; set; }

    }
}
