using NewsApi.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Dapper.IRepository
{
    public interface IChannelsRepository: IRepositoryBase<Channels>
    {
        /// <summary>
        /// 获取频道列表
        /// </summary>
        /// <returns></returns>
        Task<List<Channels>> GetChannels();
    }
}
