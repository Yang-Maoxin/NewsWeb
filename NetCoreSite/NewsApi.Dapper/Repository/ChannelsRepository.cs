using NewsApi.Dapper.Entities;
using NewsApi.Dapper.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Dapper.Repository
{
   public  class ChannelsRepository : RepositoryBase<Channels >, IChannelsRepository
    {
        public async Task<List<Channels>> GetChannels ()
        {
            string selectSql = @"SELECT * FROM [dbo].[Channels]";
            return await Select(selectSql);
        }

    }
}
