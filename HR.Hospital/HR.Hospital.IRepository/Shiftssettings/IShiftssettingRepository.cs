using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.IRepository.Shiftssettings
{
    /// <summary>
    /// 班次设置接口
    /// </summary>
    public interface IShiftssettingRepository
    {
        /// <summary>
        /// 获取所有班次列表
        /// </summary>
        /// <returns></returns>
        List<Model.Shiftssetting> GetShiftssettings();

        /// <summary>
        /// 添加班次
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        bool AddShiftssetting(Model.Shiftssetting shiftssetting);

        /// <summary>
        /// 删除班次
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteShiftssetting(int id);

        /// <summary>
        /// 修改班次
        /// </summary>
        /// <param name="shiftssetting"></param>
        /// <returns></returns>
        bool UpdateShiftssetting(Model.Shiftssetting shiftssetting);

    }
}
