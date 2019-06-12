using HR.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;

namespace HR.Hospital.IRepository.Clinical
{
    public interface IClinicalRepository
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<Clinicuser> GetList();


        /// <summary>
        /// 分页
        /// </summary>
        /// <returns></returns>
        PageDto<Clinicuser> GetPagedList(int pageIndex, int pageSize, int administrativeId, string englishName);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model"></param>
        int Add(Clinicuser model);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        int Delete(int id);


        /// <summary>
        /// 获取单个
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
