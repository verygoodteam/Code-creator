using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    public class PageDto<T>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 分页数据
        /// </summary>
        public List<T> PageList { get; set; }
    }
}
