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
