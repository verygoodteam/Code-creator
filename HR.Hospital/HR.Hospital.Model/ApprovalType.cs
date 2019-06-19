using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 活动类型
    /// </summary>
    public class ApprovalType
    {
        public int Id { get; set; }
       
        /// <summary>
        /// 类别名称
        /// </summary>
        public string TypeName { get; set; }
    }
}
