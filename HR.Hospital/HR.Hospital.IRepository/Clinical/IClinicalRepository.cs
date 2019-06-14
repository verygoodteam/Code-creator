using HR.Hospital.Model;
using System;
using System.Text;
using System.Collections.Generic;
using HR.Hospital.Common;

namespace HR.Hospital.IRepository.Clinical
{
    public interface IClinicalRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        PageHelper<Clinicuser> GetPagedList(int pageIndex, int pageSize, int administrativeId, string englishName);

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        List<Administrative> GetAdminList();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        int Add(Clinicuser model);

        /// <summary>
        /// 禁用
        /// </summary>
        /// <param name="id"></param>
        int Delete(int id);

        /// <summary>
        /// 启用
        /// </summary>
        /// <param name="id"></param>
        int Enable(int id);

        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Clinicuser GetModel(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        int Update(Clinicuser model);

    }
}
