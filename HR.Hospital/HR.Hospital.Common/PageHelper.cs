using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Common
{
    /// <summary>
    /// 分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageHelper<T> where T :class
    {
        public PageHelper()
        {
            Pagelist = new List<T>();
        }

        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int Pagenums { get; set; }

        /// <summary>
        /// 每页显示几条
        /// </summary>
        public int Pagesize { get; set; }

        /// <summary>
        /// 数据总条数
        /// </summary>
        public int Pagesizes { get; set; }

        /// <summary>
        /// 查询数据集合
        /// </summary>
        public virtual List<T> Pagelist { get; set; }
    }
}
