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
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Clinicuser> GetList(int administrativeId, string englishName)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                List<Clinicuser> list = db.Clinicuser.Where(p => p.Aadministrativeid == administrativeId || p.ClinicUserRemark== englishName).ToList();
                return list;
            }
        }
        
        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="englishName"></param>
        /// <param name="administrativeId"></param>
        /// <returns></returns>
        public PageDto<Clinicuser> GetPagedList(int pageIndex, int pageSize, int administrativeId, string englishName)
        {
            PageDto<Clinicuser> pageList = new PageDto<Clinicuser>();
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var list = db.Clinicuser.OrderBy(p => p.Id).Where(p => p.Aadministrativeid == administrativeId).Where(m => m.ClinicUserRemark.Contains(englishName)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                pageList.Total = list.Count();
                pageList.PageList = list;
            }
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
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        public int Delete(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var model = db.Clinicuser.FirstOrDefault(p => p.Id == id);
                db.Clinicuser.Remove(model);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取单个
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
                return db.SaveChanges();
            }
        }


    }
}
