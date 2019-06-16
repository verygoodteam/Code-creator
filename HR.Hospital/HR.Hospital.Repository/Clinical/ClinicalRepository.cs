using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository.Clinical;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Clinical
{
    public class ClinicalRepository : IClinicalRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<Clinicuser> GetPagedList(int pageIndex, int pageSize, int administrativeId, string englishName)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<Clinicuser>();
            var list = db.Clinicuser.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.Clinicuser.Count();

            if (administrativeId != 0)
            {
                list = db.Clinicuser.OrderBy(p => p.Id).Where(p => p.Aadministrativeid == administrativeId).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Clinicuser.Count(p => p.Aadministrativeid == administrativeId);
            }

            if (englishName != null)
            {
                list = db.Clinicuser.OrderBy(p => p.Id).Where(p => p.ClinicUserName.Contains(englishName)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Clinicuser.Count(p => p.ClinicUserName.Contains(englishName));
            }

            if (administrativeId != 0 && englishName != null)
            {
                list = db.Clinicuser.OrderBy(p => p.Id).Where(p => p.ClinicUserName.Contains(englishName) && p.Aadministrativeid.Equals(administrativeId)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Clinicuser.Count(p => p.Aadministrativeid == administrativeId && p.ClinicUserName.Contains(englishName));
            }

            pageList.PageSizes = total;//总页数
            pageList.PageList = list;//数据
            pageList.PageNum = (pageList.PageSizes / pageSize);//总条数

            return pageList;
        }

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        public List<Administrative> GetAdminList()
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                List<Administrative> list = db.Administrative.ToList();
                return list;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public int Add(Clinicuser model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                db.Clinicuser.Add(model);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="id"></param>
        public int Delete(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var user = db.Clinicuser.FirstOrDefault(p => p.Id == id);
                if (user != null) user.IsEnable = 1; //禁用
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        public int Enable(int id)
        { 
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var user = db.Clinicuser.FirstOrDefault(p => p.Id == id);
                if (user != null) user.IsEnable = 0; //启用
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Clinicuser GetModel(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var model = db.Clinicuser.FirstOrDefault(p => p.Id == id);
                return model;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public int Update(Clinicuser model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var info = db.Clinicuser.FirstOrDefault(p => p.Id == model.Id);
                info.ClinicUserName = model.ClinicUserName; //名称
                info.Aadministrativeid = model.Aadministrativeid; //所属科室
                info.Jobnumber = model.Jobnumber; //工号
                info.Sex = model.Sex; //性别
                info.ClinicUserRemark = model.ClinicUserRemark; //备注
                info.IsEnable = model.IsEnable; //状态
                return db.SaveChanges();
            }
        }


    }
}
