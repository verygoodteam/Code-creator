﻿using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 手术间类
    /// </summary>
    public partial class OperationRoom
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 院区id
        /// </summary>
        public int? AreaId { get; set; }

        /// <summary>
        /// 手术间名称
        /// </summary>
        public string OperationName { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OperationRemark { get; set; }

        /// <summary>
        /// 是否开启手术间
        /// </summary>
        public int EnableOperation { get; set; }
        
    }
}
