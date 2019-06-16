using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Department
{
    public interface IDepartmentRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        PageHelper<Administrative> GetPagedList(int pageIndex, int pageSize, int isOperation, string name);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        int Add(Administrative model);


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
        Administrative GetModel(int id);


        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        int Update(Administrative model);

    }
}
