using HR.Hospital.Common;
using HR.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.IRepository.Areas
{
    public interface IAreaRepository
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        int AddArea(Area area);

        /// <summary>
        /// 显示分页查询
        /// </summary>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页面大小</param>
        /// <param name="areaProperty">条件查询</param>
        /// <param name="areaName">模糊查询</param>
        /// <returns></returns>
        PageHelper<Area> ShowArea(int pageIndex, int pageSize, string areaName = "", int areaProperty = 3);

        /// <summary>
        /// 获取单个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Area GetArea(int id);

        /// <summary>
        /// 禁用院区
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int EnableArea(int id);

        /// <summary>
        /// 修改院区
        /// </summary>
        /// <param name="area"></param>
        /// <returns></returns>
        int UpdateArea(Area area);

    }
}
