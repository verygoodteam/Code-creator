using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Solitaire;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Solitaire
{
    public class SolitaireRepository: ISolitaireRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<SolitaireSet> GetPagedList(int pageIndex, int pageSize, string shift)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<SolitaireSet>();

            var list = db.SolitaireSet.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.SolitaireSet.Count();

            //根据班次查询
            if (shift != null)
            {
                list = db.SolitaireSet.OrderBy(p => p.Id).Where(p => p.Shift.Contains(shift)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.SolitaireSet.Count(p => p.Shift.Contains(shift));
            }

            pageList.PageSizes = total;//总条数
            pageList.PageList = list;//查询数据集合
            pageList.PageNum = (pageList.PageSizes / pageSize);//总页数

            return pageList;
        }

        /// <summary>
        /// 获取班次
        /// </summary>
        /// <returns></returns>
        public List<Shiftssetting> GetShift()
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                List<Shiftssetting> list = db.Shiftssetting.ToList();
                return list;
            }
        }

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        public PageHelper<Clinicuser> GetPerson(int pageIndex, int pageSize, string name)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<Clinicuser>();
            var list = db.Clinicuser.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.Clinicuser.Count();
            //根据人员名称查询
            if (name != null)
            {
                list = db.Clinicuser.OrderBy(p => p.Id).Where(p => p.ClinicUserName.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.Clinicuser.Count(p => p.ClinicUserName.Contains(name));
            }
            pageList.PageSizes = total;//总条数
            pageList.PageList = list;//查询数据集合
            pageList.PageNum = (pageList.PageSizes / pageSize);//总页数

            return pageList;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        public int Add(SolitaireSet model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                db.SolitaireSet.Add(model);
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
                var model = db.SolitaireSet.FirstOrDefault(p => p.Id == id);
                db.SolitaireSet.Remove(model);
                return db.SaveChanges();
            }
        }
        
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SolitaireSet GetModel(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var model = db.SolitaireSet.FirstOrDefault(p => p.Id == id);
                return model;
            }
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        public int Update(SolitaireSet model)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                var info = db.SolitaireSet.FirstOrDefault(p => p.Id == model.Id);
                info.Shift = model.Shift; //班次
                info.SolitaireCycle = model.SolitaireCycle; //周期
                info.GroupMember = model.GroupMember; //成员
                info.GroupLeader = model.GroupLeader; //组长
                return db.SaveChanges();
            }
        }

        /// <summary>
        /// 更改排序id 向前
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateSortId(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                int sortId = db.SolitaireSet.Find(id).SortId;
                if (sortId <= 1)
                {
                    return false;
                }
                else
                {
                    int ids = db.SolitaireSet.OrderByDescending(u => u.SortId).First(u => u.SortId < sortId).SortId;

                    SolitaireSet solitaireSet = db.SolitaireSet.Find(id);
                    solitaireSet.SortId = ids;

                    SolitaireSet solitaireSete = db.SolitaireSet.FirstOrDefault(u => u.SortId == ids);
                    solitaireSete.SortId = sortId;
                    bool b1 = db.SaveChanges() > 0;
                    
                    if (b1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetMaxId()
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                int id = db.SolitaireSet.OrderBy(u => u.Id).FirstOrDefault().Id; 
                return id;
            }
        }

        /// <summary>
        /// 更改排序id 向后
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DownSortId(int id)
        {
            using (hospitaldbContext db = new hospitaldbContext())
            {
                int maxId = GetMaxId();
                int sortId = db.SolitaireSet.Find(id).SortId;
                if (sortId >= maxId)
                {
                    return false;
                }
                else
                {
                    int ids = db.SolitaireSet.OrderBy(u => u.SortId).First(u => u.SortId > sortId).SortId;

                    SolitaireSet solitaireSet = db.SolitaireSet.Find(id);
                    solitaireSet.SortId = ids;

                    SolitaireSet solitaireSete = db.SolitaireSet.FirstOrDefault(u => u.SortId == ids);
                    solitaireSete.SortId = sortId;
                    bool b2 = db.SaveChanges() > 0;

                    if (b2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
        }

    }
}
