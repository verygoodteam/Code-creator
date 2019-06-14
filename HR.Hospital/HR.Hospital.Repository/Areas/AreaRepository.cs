using System.Linq;
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
        public PageHelper<Area> ShowArea(int pageIndex, int pageSize, string areaName = "", int areaProperty = 3)
        {

            var pageHelperArea = new PageHelper<Area>();
            var listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.Isnable == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = _context.Area.Count(p => p.Isnable == 0);
            if (areaProperty != 3)
            {
                listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.AreaProperty == areaProperty && p.Isnable == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = _context.Area.Count(p => p.AreaProperty == areaProperty && p.Isnable == 0);
            }

            if (areaName != null)
            {
                listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.AreaName.Contains(areaName) && p.Isnable == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = _context.Area.Count(p => p.AreaName.Contains(areaName) && p.Isnable == 0);
            }

            if (areaName != null && areaProperty != 3)
            {
                listArea = _context.Area.OrderBy(p => p.Id).Where(p => p.AreaName.Contains(areaName) && p.AreaProperty.Equals(areaProperty) && p.Isnable == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = _context.Area.Count(p => p.AreaProperty == areaProperty && p.AreaName.Contains(areaName) && p.Isnable == 0);
            }
            pageHelperArea.PageSizes = total;
            pageHelperArea.PageList = listArea;
            pageHelperArea.PageNum = (pageHelperArea.PageSizes / pageSize);

            return pageHelperArea;
        }

        /// <summary>
        /// 获取单个对象
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
            if (area != null) area.Isnable = 1;
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
                firstOrDefault.Isnable = 0;
                firstOrDefault.OperatingNum = area.OperatingNum;
            }
            var result = _context.SaveChanges();
            return result;
        }
    }
}
