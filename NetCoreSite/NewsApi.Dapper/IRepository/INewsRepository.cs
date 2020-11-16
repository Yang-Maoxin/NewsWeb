using NewsApi.Common;
using NewsApi.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Dapper.IRepository
{
    public interface INewsRepository:IRepositoryBase <News>
    {
        PageData<News> GetNewsList(int channelId , int pageIndex , int pageSize );
    }
}
