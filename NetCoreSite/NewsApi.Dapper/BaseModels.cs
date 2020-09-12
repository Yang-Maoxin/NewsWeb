using System;

namespace NewsApi.Dapper
{
    /// <summary>
    /// 由于所有的数据库实体都是有主键的，所以这里定义一个BaseModel，这里我用的主键是Guid，可以换成其他
    /// </summary>
    public class BaseModels :IEntity<Guid>
    {
        public Guid id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
