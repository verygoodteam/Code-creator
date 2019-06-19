using System.Collections.Generic;

namespace HR.Hospital.Client.Common
{
    public class PageDto<T> where T : class
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public PageHelper<T> PageList { get; set; }
    }
}
