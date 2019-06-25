using System;
using System.Collections.Generic;
using System.Linq;
using HR.Hospital.IRepository.OoperationUser;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;

namespace HR.Hospital.Repository.OoperationUser
{
    public class OoperationUserRepository : IOoperationUserRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();


        /// <summary>
        /// 添加手术室用户
        /// </summary>
        /// <param name="operuser"></param>
        /// <returns></returns>
        public int AddOoperationUser(Ooperationuser operuser)
        {
            db.Ooperationuser.Add(operuser);
            var addOoperationUser = db.SaveChanges();
            return addOoperationUser;
        }


        /// <summary>
        ///能级下拉 
        /// </summary>
        /// <returns></returns>
        public List<Hierarchy> GetHierarchies()
        {
            var gethierarchies = db.Hierarchy.ToList();
            return gethierarchies;
        }

        /// <summary>
        /// 职务下拉
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPositions()
        {
            var getpositions = db.Position.ToList();
            return getpositions;
        }

        /// <summary>
        /// 职称下拉
        /// </summary>
        /// <returns></returns>
        public List<Professional> GetProfessionals()
        {
            var getprofessionals = db.Professional.ToList();
            return getprofessionals;
        }

        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRoles()
        {
            var getroles = db.Role.ToList();
            return getroles;
        }


        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Model.Ooperationuser RefillUser(int id)
        {
            var refillUser = db.Ooperationuser.FirstOrDefault(p => p.Id == id);
            return refillUser;
        }

        /// <summary>
        /// 主管下拉
        /// </summary>
        /// <returns></returns>
        public List<Model.Ooperationuser> GetOoperationusers()
        {

            var operationusers = from o1 in db.Ooperationuser
                                 select new Model.Ooperationuser()
                                 {
                                     Id = o1.Id,
                                     OoperationUserName = o1.OoperationUserName
                                 };

            var getoperationusers = operationusers.ToList();
            return getoperationusers;
        }


        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="hierarchyid"></param>
        /// <param name="name"></param>
        /// <param name="englishname"></param>
        /// <returns></returns>
        public List<Ooperationuserview> ShowOoperationUser(int hierarchyid = 0, string name = "", string englishname = "")
        {

            if (hierarchyid == 0 && (name == "" || name == null) && (englishname == "" || englishname == null))
            {
                var operation = from o1 in db.Ooperationuser
                                join r in db.Role on o1.Roleid equals r.Id
                                into JoinedEmpDept1
                                from r in JoinedEmpDept1.DefaultIfEmpty()
                                join p in db.Position on o1.PositionId equals p.Id
                                into JoinedEmpDept2
                                from p in JoinedEmpDept2.DefaultIfEmpty()
                                join pro in db.Professional on o1.ProfessionalId equals pro.Id
                                into JoinedEmpDept3
                                from pro in JoinedEmpDept3.DefaultIfEmpty()
                                join h in db.Hierarchy on o1.HierarchyId equals h.Id
                                into JoinedEmpDept4
                                from h in JoinedEmpDept4.DefaultIfEmpty()
                                join o2 in db.Ooperationuser on o1.Userid equals o2.Id
                                into JoinedEmpDept5
                                from o2 in JoinedEmpDept5.DefaultIfEmpty()
                                select new Ooperationuserview
                                {
                                    Id = o1.Id,
                                    Jobnumber = o1.Jobnumber,
                                    OoperationUserName = o1.OoperationUserName,
                                    Phone = o1.Phone,
                                    Sex = o1.Sex,
                                    PositionName = p.PositionName,
                                    ProfessionalName = pro.ProfessionalName,
                                    HierarchyName = h.HierarchyName,
                                    UserName = o2.OoperationUserName,
                                    Enrollmentdate = DateTime.Now,
                                    HierarchyId = o1.HierarchyId,
                                    Simplename = o1.Simplename
                                };

                return operation.ToList();
            }

            string chinese = "";
            string english = "";
            //判断是汉字还是拼音
            if (name != null && name != "")
            {
                bool res = System.Text.RegularExpressions.Regex.IsMatch(name, @"[\u4e00-\u9fbb]");
                if (res)
                {
                    chinese = name;
                }
                else
                {
                    english = name;
                }
            }

            var operations = from o1 in db.Ooperationuser
                             join r in db.Role on o1.Roleid equals r.Id
                             into JoinedEmpDept1
                             from r in JoinedEmpDept1.DefaultIfEmpty()
                             join p in db.Position on o1.PositionId equals p.Id
                             into JoinedEmpDept2
                             from p in JoinedEmpDept2.DefaultIfEmpty()
                             join pro in db.Professional on o1.ProfessionalId equals pro.Id
                             into JoinedEmpDept3
                             from pro in JoinedEmpDept3.DefaultIfEmpty()
                             join h in db.Hierarchy on o1.HierarchyId equals h.Id
                             into JoinedEmpDept4
                             from h in JoinedEmpDept4.DefaultIfEmpty()
                             join o2 in db.Ooperationuser on o1.Userid equals o2.Id
                             into JoinedEmpDept5
                             from o2 in JoinedEmpDept5.DefaultIfEmpty()
                             where (o1.HierarchyId == hierarchyid && o1.OoperationUserName == name) || (o1.Simplename == englishname && o1.HierarchyId == hierarchyid)
                             select new Ooperationuserview()
                             {
                                 Id = o1.Id,
                                 Jobnumber = o1.Jobnumber,
                                 OoperationUserName = o1.OoperationUserName,
                                 Phone = o1.Phone,
                                 Sex = o1.Sex,
                                 PositionName = p.PositionName,
                                 ProfessionalName = pro.ProfessionalName,
                                 HierarchyName = h.HierarchyName,
                                 UserName = o2.OoperationUserName,
                                 HierarchyId = o1.HierarchyId,
                                 Simplename = o1.Simplename
                             };

            //中文查询
            if (!string.IsNullOrEmpty(chinese))
            {
                operations = operations.Where(p => p.OoperationUserName.Contains(chinese));
            }
            //拼音查询
            if (!string.IsNullOrEmpty(english))
            {
                operations = operations.Where(p => p.Simplename.Contains(english));
            }
            //能级下拉查询
            if (hierarchyid != 0)
            {
                operations = operations.Where(p => p.HierarchyId == hierarchyid);
            }

            return operations.ToList();

        }


    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="operuser"></param>
    /// <returns></returns>
    public int UpdateOoperationUser(Ooperationuser operuser)
    {
        var oopuserinfo = db.Ooperationuser.FirstOrDefault(p => p.Id == operuser.Id);
        oopuserinfo.OoperationUserName = operuser.OoperationUserName;
        oopuserinfo.Account = operuser.Account;
        oopuserinfo.Jobnumber = operuser.Jobnumber;
        oopuserinfo.Pwd = operuser.Pwd;
        oopuserinfo.Sex = operuser.Sex;
        oopuserinfo.Phone = operuser.Phone;
        oopuserinfo.Simplename = operuser.Simplename;
        oopuserinfo.Isarrange = operuser.Isarrange;
        oopuserinfo.Roleid = operuser.Roleid;
        oopuserinfo.Userid = operuser.Userid;
        oopuserinfo.PositionId = operuser.PositionId;
        oopuserinfo.ProfessionalId = operuser.ProfessionalId;
        oopuserinfo.HierarchyId = operuser.HierarchyId;
        oopuserinfo.Workage = operuser.Workage;
        oopuserinfo.Enrollmentdate = operuser.Enrollmentdate;
        oopuserinfo.Annualdays = operuser.Annualdays;
        oopuserinfo.Grade = operuser.Grade;
        oopuserinfo.OoperationUserRemark = operuser.OoperationUserRemark;
        var updateOoperationUser = db.SaveChanges();
        return updateOoperationUser;
    }

}
}
