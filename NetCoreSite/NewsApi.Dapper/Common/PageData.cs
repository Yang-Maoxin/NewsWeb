using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApi.Common
{
    public class PageData<T>
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int PageCount { get; private set; }

        public int TotalCount { get; private set; }

        public IEnumerable<T> DataSource { get; private set; }

        /// <summary>
        /// 分页数据集合
        /// </summary>
        /// <param name="Source">数据源</param>
        /// <param name="CurrentPage">当前页</param>
        /// <param name="PageSzie">一页几条</param>
        /// <param name="TotalCount">总条数</param>
        public PageData(IEnumerable<T> Source, int CurrentPage, int PageSzie, int TotalCount)
        {
            this.PageIndex = CurrentPage;
            this.PageSize = PageSzie;
            this.TotalCount = TotalCount;
            this.PageCount = (int)Math.Ceiling((double)TotalCount / (double)PageSize);
            this.DataSource = Source;
        }
    }
}
