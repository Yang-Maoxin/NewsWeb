using System;
using System.Data;
using System.Data.SqlClient;
using StackExchange.Redis;

namespace NewsApi.Dapper
{
    public class DataBaseConfig
    {
        #region SqlServer 链接配置
        private static string DefaultSqlConnectionString = @"Data Source=localhost;Initial Catalog=News;User ID=sa;Password=123456;";
        public static IDbConnection GetSqlConnection(string sqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(sqlConnectionString))
            {
                sqlConnectionString = DefaultSqlConnectionString;
            }
            IDbConnection conn = new SqlConnection(sqlConnectionString);
            conn.Open();
            return conn;
        }
        #endregion

        #region Redis链接配置
        //private static string DefaultRedisString = "localhost, abortConnect=false";
        //private static ConnectionMultiplexer redis;
        //private static ConnectionMultiplexer GetRedis(string redisString = null)
        //{
        //    if (string.IsNullOrWhiteSpace(redisString))
        //    {
        //        redisString = DefaultRedisString;
        //    }
        //    if (redis == null || redis.IsConnected)
        //    {
        //        redis = ConnectionMultiplexer.Connect(redisString);
        //    }
        //    return redis;
        //}

        #endregion


    }
}
