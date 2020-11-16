using Dapper;
using NewsApi.Common;
using NewsApi.Dapper.Entities;
using NewsApi.Dapper.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Dapper.Repository
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        public PageData<News> GetNewsList(int channelId, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize;
            using (IDbConnection conn = DataBaseConfig.GetSqlConnection())
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT  N.*,C.name as channelName FROM News N");
                sql.Append(" left join Channels C on N.channelId=C.channelId");
                if (channelId != -1)
                {
                    sql.Append(" where N.channelId=@channelId");
                }
                sql.Append(" ORDER BY N.id ");
                sql.Append(" OFFSET (@startIndex * @pageSize) ROWS");
                sql.Append(" FETCH NEXT @pageSize ROWS ONLY");
              
                var dataList = conn.Query<News>(sql.ToString(), new { channelId, startIndex, pageSize }).ToList();
                StringBuilder sqlCount = new StringBuilder();
                sqlCount.Append(" select count(1) from News N");
                sqlCount.Append(" left join Channels C  on N.channelId=C.channelId ");
                if (channelId != -1)
                {
                    sql.Append(" and N.channelId=@channelId");
                }
                var count = conn.QueryFirstOrDefault<int>(sqlCount.ToString(), new { channelId });
                return new PageData<News>(dataList, pageIndex, pageSize, count);
            }

        }
    }
}
