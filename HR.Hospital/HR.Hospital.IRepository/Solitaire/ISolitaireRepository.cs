using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Solitaire
{
    public interface ISolitaireRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        PageHelper<SolitaireSet> GetPagedList(int pageIndex, int pageSize, string shift);

        /// <summary>
        /// 获取班次
        /// </summary>
        /// <returns></returns>
        List<Shiftssetting> GetShift();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        int Add(SolitaireSet model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        int Delete(int id);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SolitaireSet GetModel(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        int Update(SolitaireSet model);

    }
}
