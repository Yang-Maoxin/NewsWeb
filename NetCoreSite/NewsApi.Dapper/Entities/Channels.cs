using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Dapper.Entities
{
    public class Channels
    {
        public int channelId { get; set; }

        public string name { get; set; }
        public string insertUser { get; set; }
        public DateTime insertTime { get; set; }
        public string updateUser { get; set; }
        public DateTime updateTime { get; set; }
    }
}
