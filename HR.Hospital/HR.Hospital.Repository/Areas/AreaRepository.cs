using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Areas;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Areas
{
    public class AreaRepository : IAreaRepository
    {
        private readonly hospitaldbContext _context = new hospitaldbContext();

        /// <inheritdoc />
        /// <summary>
        /// 添加院区信息
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        public int AddArea(Area area)
        {
            _context.Add(area);
            var result = _context.SaveChanges();
            return result;
        }

        /// <inheritdoc />
        /// <summary>
        /// 院区分页查询模糊查询 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="areaProperty"></param>
        /// <param name="areaName"></param>
        /// <returns></returns>
        public PageHelper<Area> ShowArea(int pageIndex, int pageSize, int areaProperty, string areaName)
        {
            var pageHelperArea = new PageHelper<Area>();
            if (areaProperty == 0)
            {
                var listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.AreaName.Contains(areaName)).Take((pageIndex - 1) * pageSize).Skip(pageSize).ToList();
                pageHelperArea.Pagesizes = listArea.Count();
                pageHelperArea.Pagelist = listArea;
            }
            else
            {
                var listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.AreaName.Contains(areaName) || p.AreaProperty.Equals(areaProperty)).Take((pageIndex - 1) * pageSize).Skip(pageSize).ToList();
                pageHelperArea.Pagesizes = listArea.Count();
                pageHelperArea.Pagelist = listArea;
            }
            return pageHelperArea;
        }


        /// <summary>
        /// 获取单个Model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Area GetArea(int id)
        {
            var area = _context.Area.FirstOrDefault(p => p.Id == id);
            return area;
        }

        /// <inheritdoc />
        /// <summary>
        /// 进行禁用院区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EnableArea(int id)
        {
            var area = _context.Area.FirstOrDefault(p => p.Id == id);
            if (area != null) area.AreaProperty = 1;
            var result = _context.SaveChanges();
            return result;
        }

        /// <inheritdoc />
        ///  <summary>
        /// 修改院区 
        ///  </summary>
        ///  <param name="area"></param>
        ///  <returns></returns>
        public int UpdateArea(Area area)
        {
            var firstOrDefault = _context.Area.FirstOrDefault(p => p.Id == area.Id);
            if (firstOrDefault != null)
            {
                firstOrDefault.AreaName = area.AreaName;
                firstOrDefault.AreaProperty = area.AreaProperty;
                firstOrDefault.AreaRemark = area.AreaRemark;
                firstOrDefault.Isnable = area.Isnable;
                firstOrDefault.OperatingNum = area.OperatingNum;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}
