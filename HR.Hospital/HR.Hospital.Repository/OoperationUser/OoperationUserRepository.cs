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
            return db.SaveChanges();         
        }

        //返填
        public Ooperationuser RefillUser(int id)
        {
            return db.Ooperationuser.FirstOrDefault(p=>p.Id==id);
        }

        //显示
        public List<Ooperationuser> ShowOoperationUser(int administrativeid, string name,string englishname)
        {
            return db.Ooperationuser.Where(p=>p.Id== administrativeid || p.OoperationUserName == name||p.Simplename==englishname).ToList();
        }

        //修改
        public int UpdateOoperationUser(Ooperationuser operuser)
        {
            var oopuserinfo = db.Ooperationuser.FirstOrDefault(p=>p.Id==operuser.Id);
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
            return db.SaveChanges();
        }
    }
}
