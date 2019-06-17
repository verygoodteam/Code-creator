using HR.Hospital.IRepository.Shiftssettings;
using HR.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HR.Hospital.Repository.Shiftssettings
{
    public class ShiftssettingsRepository : IShiftssettingRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        public bool AddShiftssetting(Shiftssetting shiftssetting)
        {
            using (Model.hospitaldbContext ef = new hospitaldbContext())
            {
                ef.Add(shiftssetting);
                return ef.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteShiftssetting(int id)
        {
            using (Model.hospitaldbContext ef = new hospitaldbContext())
            {
                Model.Shiftssetting shiftssetting = ef.Shiftssetting.Find(id);
                ef.Remove(shiftssetting);
                return ef.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        public int GetId()
        {
            using (Model.hospitaldbContext eF = new hospitaldbContext())
            {
                int id = eF.Shiftssetting.OrderBy(u => u.Id).LastOrDefault().Id;
                return id;
            }
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>

        public List<Shiftssetting> GetShiftssettings(string name)
        {
            using (Model.hospitaldbContext ef = new hospitaldbContext())
            {
                List<Model.Shiftssetting> list = ef.Shiftssetting.Where(u => string.IsNullOrEmpty(name) || u.ShiftssettingName == name).OrderBy(u => u.Sortid).ToList();
                return list;
            }

        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        public bool UpdateShiftssetting(Shiftssetting shiftssetting)
        {
            using (Model.hospitaldbContext ef = new hospitaldbContext())
            {
                ef.Entry(shiftssetting).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return ef.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 更改排序id 向前
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateSortid(int id)
        {
            using (Model.hospitaldbContext eF = new hospitaldbContext())
            {
                int? sortid = eF.Shiftssetting.Find(id).Sortid;
                if (sortid <= 1)
                {
                    return false;
                }
                else
                {
                    int? ii = eF.Shiftssetting.OrderByDescending(u => u.Sortid).First(u => u.Sortid < sortid).Sortid;

                    Model.Shiftssetting shiftssetting = eF.Shiftssetting.Find(id);
                    shiftssetting.Sortid = ii;
                    //bool b1 = eF.SaveChanges() > 0;

                    Model.Shiftssetting shiftssetting2 = eF.Shiftssetting.FirstOrDefault(u => u.Sortid == ii);
                    shiftssetting2.Sortid = sortid;
                    bool b2 = eF.SaveChanges() > 0;

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

        /// <summary>
        /// 更改排序id 向后
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DownSortid(int id)
        {
            using (Model.hospitaldbContext eF = new hospitaldbContext())
            {
                int orldid = GetId();
                int? sortid = eF.Shiftssetting.Find(id).Sortid;
                if (sortid >= orldid)
                {
                    return false;
                }
                else
                {
                    int? ii = eF.Shiftssetting.OrderBy(u => u.Sortid).First(u => u.Sortid > sortid).Sortid;

                    Model.Shiftssetting shiftssetting = eF.Shiftssetting.Find(id);
                    shiftssetting.Sortid = ii;
                    //bool b1 = eF.SaveChanges() > 0;

                    Model.Shiftssetting shiftssetting2 = eF.Shiftssetting.FirstOrDefault(u => u.Sortid == ii);
                    shiftssetting2.Sortid = sortid;
                    bool b2 = eF.SaveChanges() > 0;

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
