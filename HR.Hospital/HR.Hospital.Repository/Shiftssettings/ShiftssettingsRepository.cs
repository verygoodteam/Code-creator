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
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<Shiftssetting> GetShiftssettings()
        {
            using (Model.hospitaldbContext ef = new hospitaldbContext())
            {
                List<Model.Shiftssetting> list = ef.Shiftssetting.ToList();
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
    }
}
