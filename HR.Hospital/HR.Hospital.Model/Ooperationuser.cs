using System;
using System.Collections.Generic;

namespace HR.Hospital.Model
{
    /// <summary>
    /// 手术用户类
    /// </summary>
    public partial class Ooperationuser
    {
        public Ooperationuser()
        {

        }
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 姓名
        /// </summary>
        public string OoperationUserName { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        public string Jobnumber { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 简称
        /// </summary>
        public string Simplename { get; set; }

        /// <summary>
        /// 是否排班
        /// </summary>
        public int? Isarrange { get; set; }

        //角色Id
        public int? Roleid { get; set; }
        //角色名称
        public string RoleName { get; set; }
        //主管id
        public int? Userid { get; set; }
        //主管名称
        public string UserName { get; set; }
        //职务id
        public int? PositionId { get; set; }
        //职务名称
        public string PositionName { get; set; }
        //职称Id
        public int? ProfessionalId { get; set; }
        //职称名称
        public string ProfessionalName { get; set; }
        //能级id
        public int? HierarchyId { get; set; }
        //能级名称
        public string HierarchyName { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        public int? Workage { get; set; }

        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? Enrollmentdate { get; set; }

        /// <summary>
        /// 年假天数
        /// </summary>
        public int? Annualdays { get; set; }

        /// <summary>
        /// 绩效分数
        /// </summary>
        public string Grade { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string OoperationUserRemark { get; set; }
    }
}
