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
        /// <param name="name"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        int Login(string name, string pwd);
    }
}
