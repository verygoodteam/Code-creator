using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;
using HR.Hospital.IRepository.Hierarchys;
using System.Linq;

namespace HR.Hospital.Repository.Hierarchys
{
    public class HierarchyRepository : IHierarchyRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 添加能级
        /// </summary>
        /// <param name="hierarchy"></param>
        /// <returns></returns>
        public int AddHierarchy(Hierarchy hierarchy)
        {
            var addhierarchy = db.Hierarchy.Add(hierarchy);
            var i = db.SaveChanges();
            return i; ;
        }

        /// <summary>
        /// 删除能级
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>      
        public int DeleteHierarchy(int id)
        {
            var gethierarchy = db.Hierarchy.FirstOrDefault(p => p.Id == id);
            var deletehierarchy = db.Hierarchy.Remove(gethierarchy);
            var i = db.SaveChanges();
            return i;
        }

        /// <summary>
        /// 显示能级
        /// </summary>
        /// <returns></returns>
        public List<Hierarchy> GetHierarchie()
        {
            var gethierarchy = db.Hierarchy;
            return gethierarchy.ToList();
        }
    }
}
