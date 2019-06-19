using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Group
{
    public interface IGroupRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>
        PageHelper<Professionalgroup> GetPagedList(int pageIndex, int pageSize, string name);

        /// <summary>
        /// 获取科室
        /// </summary>
        /// <returns></returns>
        List<Administrative> GetDepartment();

        /// <summary>
        /// 获取人员
        /// </summary>
        /// <returns></returns>
        List<Clinicuser> GetClinical();

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        int Add(Professionalgroup model);

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
        Professionalgroup GetModel(int id);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        int Update(Professionalgroup model);
    }
}
