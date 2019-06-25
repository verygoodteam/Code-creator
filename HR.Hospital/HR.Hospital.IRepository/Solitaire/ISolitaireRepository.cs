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
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        PageHelper<Clinicuser> GetPerson(int pageIndex, int pageSize, string name);

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

        /// <summary>
        /// 更改排序id 向前
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool UpdateSortId(int id);


        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <returns></returns>
        int GetMaxId();


        /// <summary>
        /// 更改排序id 向后
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DownSortId(int id);
    }
}
