using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Client.Models.Dto
{
   public class RulesettingsDto
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 班次1
        /// </summary>
        public int? OneShiftsId { get; set; }

        /// <summary>
        /// 班次2
        /// </summary>
        public int? TwoShiftsId { get; set; }

        /// <summary>
        /// 班次1名称
        /// </summary>
        public string OneShiftsIdName { get; set; }

        /// <summary>
        /// 班次2名称
        /// </summary>
        public string TwoShiftsName { get; set; }

        /// <summary>
        /// 时间一
        /// </summary>
        public string OneTime { get; set; }

        /// <summary>
        /// 时间二
        /// </summary>
        public string TwoTime { get; set; }

        /// <summary>
        /// 时间三
        /// </summary>
        public string ThreeTime { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        public int? Types { get; set; }

        /// <summary>
        /// 是否生效
        /// </summary>
        public int? Iseffec { get; set; }
    }
}
