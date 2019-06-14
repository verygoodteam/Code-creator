using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;
using HR.Hospital.Model.Dto;

namespace HR.Hospital.IRepository.OoperationUser
{
    public interface IOoperationUserRepository
    {
        /// <summary>
        /// 手术室用户添加
        /// </summary>
        /// <param name="operuser"></param>
        /// <returns></returns>
        int AddOoperationUser(Model.Ooperationuser operuser);
     
        /// <summary>
        /// 手术室用户编辑
        /// </summary>
        /// <param name="operuser"></param>
        /// <returns></returns>
        int UpdateOoperationUser(Model.Ooperationuser operuser);

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Model.Ooperationuser RefillUser(int id);
        
        /// <summary>
        /// 手术室用户显示
        /// </summary>
        /// <param name="hierarchyid"></param>
        /// <param name="name"></param>
        /// <param name="englishname"></param>
        /// <returns></returns>
        List<Model.Dto.Ooperationuserview> ShowOoperationUser(int hierarchyid = 0, string name = "", string englishname = "");
        
        /// <summary>
        /// 能级下拉
        /// </summary>
        /// <returns></returns>
        List<Hierarchy> GetHierarchies();

        /// <summary>
        /// 角色下拉
        /// </summary>
        /// <returns></returns>
        List<Role> GetRoles();

        /// <summary>
        /// 主管下拉
        /// </summary>
        /// <returns></returns>
        List<Model.Ooperationuser> GetOoperationusers();

        /// <summary>
        /// 职务下拉
        /// </summary>
        /// <returns></returns>
        List<Position> GetPositions();

        /// <summary>
        /// 职称下拉
        /// </summary>
        /// <returns></returns>
        List<Professional> GetProfessionals();
    }
}
