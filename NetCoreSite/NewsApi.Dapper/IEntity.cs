using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApi.Dapper
{
    //实体的接口IEntity
    public interface IEntity<TPrimaryKey>
    {
        TPrimaryKey id { get; set; }
    }
}
