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
    }
}
