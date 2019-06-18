using System.Collections.Generic;


namespace HR.Hospital.Client.Common
{
    /// <summary>
    /// 分页类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class List<T> where T : class
    {
        public List()
        {
            PageList = new List<T>();
        }
        /// <summary>
        /// 当前页
        /// </summary>
        public int PageIndex { get; set; }


        /// <summary>
        /// 总页数
        /// </summary>
        public int PageNum { get; set; }


        /// <summary>
        /// 每页显示几条
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// 数据总条数
        /// </summary>
        public int PageSizes { get; set; }


        /// <summary>
        /// 查询数据集合
        /// </summary>
        public List<T> PageList { get; set; }
    }
}
