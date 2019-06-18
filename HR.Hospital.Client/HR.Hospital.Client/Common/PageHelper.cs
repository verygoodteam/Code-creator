using System.Collections.Generic;


namespace HR.Hospital.Client.Common
{
    /// <summary>
    /// ��ҳ��
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class List<T> where T : class
    {
        public List()
        {
            PageList = new List<T>();
        }
        /// <summary>
        /// ��ǰҳ
        /// </summary>
        public int PageIndex { get; set; }


        /// <summary>
        /// ��ҳ��
        /// </summary>
        public int PageNum { get; set; }


        /// <summary>
        /// ÿҳ��ʾ����
        /// </summary>
        public int PageSize { get; set; }


        /// <summary>
        /// ����������
        /// </summary>
        public int PageSizes { get; set; }


        /// <summary>
        /// ��ѯ���ݼ���
        /// </summary>
        public List<T> PageList { get; set; }
    }
}
