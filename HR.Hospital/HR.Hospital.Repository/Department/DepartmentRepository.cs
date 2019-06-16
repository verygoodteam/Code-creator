using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Department;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Department
{
    public class DepartmentRepository: IDepartmentRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<Administrative> GetPagedList(int pageIndex, int pageSize, int isOperation, string name)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<Administrative>();
            var list = db.Administrative.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.Administrative.Count();
            //根据是否为手术间查询
            if (isOperation != 0)
            {
                list = db.Administrative.OrderBy(p => p.Id).Where(p => p.Isoperation == isOperation).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Administrative.Count(p => p.Isoperation == isOperation);
            }
            //根据科室名称查询
            if (name != null)
            {
                list = db.Administrative.OrderBy(p => p.Id).Where(p => p.AdministrativeName.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Administrative.Count(p => p.AdministrativeName.Contains(name));
            }
            //双条件查询
            if (isOperation != 0 && name != null)
            {
                list = db.Administrative.OrderBy(p => p.Id).Where(p =>p.Isoperation.Equals(isOperation) && p.AdministrativeName.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Administrative.Count(p => p.Isoperation == isOperation && p.AdministrativeName.Contains(name));
            }
            
            pageList.PageSizes = total;//总页数
            pageList.PageList = list;//数据
            pageList.PageNum = (pageList.PageSizes / pageSize);//总条数

            return pageList;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public int Add(Administrative model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                db.Administrative.Add(model);
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
                var user = db.Administrative.FirstOrDefault(p => p.Id == id);
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
                var user = db.Administrative.FirstOrDefault(p => p.Id == id);
                if (user != null) user.IsEnable = 0; //启用
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Administrative GetModel(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var model = db.Administrative.FirstOrDefault(p => p.Id == id);
                return model;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public int Update(Administrative model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var info = db.Administrative.FirstOrDefault(p => p.Id == model.Id);
                info.AdministrativeName = model.AdministrativeName; //名称
                info.Isoperation = model.Isoperation;        //是否为手术间
                info.AdministrativeRemark = model.AdministrativeRemark; //备注
                return db.SaveChanges();
            }
        }
    }
}
