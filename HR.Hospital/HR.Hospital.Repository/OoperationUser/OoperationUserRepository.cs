using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository;
using HR.Hospital.IRepository.OoperationUser;
using HR.Hospital.Model;


namespace HR.Hospital.Repository.OoperationUser
{
    public class OoperationUserRepository : IOoperationUserRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        //添加手术室用户
        public int AddOoperationUser(Ooperationuser operuser)
        {
            db.Ooperationuser.Add(operuser);
            var addOoperationUser = db.SaveChanges();
            return addOoperationUser;
        }

        //能级下拉
        public List<Hierarchy> GetHierarchies()
        {
           var list= db.Hierarchy.ToList();
           return list;
        }

        //返填
        public Ooperationuser RefillUser(int id)
        {
            var refillUser = db.Ooperationuser.FirstOrDefault(p => p.Id == id);
            return refillUser;
        }

        //显示
        public List<Ooperationuser> ShowOoperationUser(int hierarchyid = 0, string name = "", string englishname = "")
        {
            if (hierarchyid == 0 && name == "" || name == null && englishname == "" || englishname == null)
            {
                var query = from o1 in db.Ooperationuser
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
                            join o2 in db.Ooperationuser on o1.Id equals o2.Userid
                            into JoinedEmpDept5
                            from o2 in JoinedEmpDept5.DefaultIfEmpty()
                            select new Ooperationuser()
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
                                Userid = o2.Userid
                            };

                return query.ToList();
            }
            else
            {
                var query = from o1 in db.Ooperationuser
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
                            join o2 in db.Ooperationuser on o1.Id equals o2.Userid
                            into JoinedEmpDept5
                            from o2 in JoinedEmpDept5.DefaultIfEmpty()
                            where o1.HierarchyId == hierarchyid || o1.OoperationUserName == name || o1.Simplename == englishname
                            select new Ooperationuser()
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
                                Userid = o2.Userid
                            };

                return query.ToList();
            }

        }

        //修改
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
