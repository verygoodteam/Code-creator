using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.IRepository.Group;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Group
{
    public class GroupRepository : IGroupRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Professionalgroup> GetPageList()
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                List<Professionalgroup> list = db.Professionalgroup.ToList();
                return list;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public int Add(Professionalgroup model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                db.Professionalgroup.Add(model);
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
                var model = db.Professionalgroup.FirstOrDefault(p => p.Id == id);
                db.Professionalgroup.Remove(model);
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取单个
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Professionalgroup GetModel(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var model = db.Professionalgroup.FirstOrDefault(p => p.Id == id);
                return model;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public int Update(Professionalgroup model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var info = db.Professionalgroup.FirstOrDefault(p => p.Id == model.Id);
                info.ProfessionalGroupName = model.ProfessionalGroupName; //专业组名称
                info.ProfessionalGroupColore = model.ProfessionalGroupColore; //颜色
                info.DepartmentId = model.DepartmentId; //关联科室
                info.TeachingId = model.TeachingId; //带教
                info.GroupLeader = model.GroupLeader; //组长
                info.TeamMember = model.TeamMember; //组员
                return db.SaveChanges();
            }
        }
    }
}
