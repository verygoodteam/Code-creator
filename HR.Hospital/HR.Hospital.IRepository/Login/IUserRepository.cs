using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.IRepository.Login
{
    public interface IUserRepository
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <returns></returns>
        int Login(Model.Ooperationuser ooperationuser);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        List<Model.Ooperationuser> ooperationusers();

        /// <summary>
        /// 获取角色权限列表
        /// </summary>
        /// <returns></returns>
        List<Model.Dto.UserRolePermissionDto> userRolePermissionDtos(int id);




    }
}
