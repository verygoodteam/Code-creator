using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using HR.Hospital.IRepository.Login;

namespace HR.Hospital.Repository.Login
{
    public class UserRepository : IUserRepository
    {
        public int Login(string name, string pwd)
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {
                Model.Ooperationuser ooperationuser = context.Ooperationuser.Where(u => u.OoperationUserName == name && u.Pwd == pwd).FirstOrDefault();
                if (ooperationuser != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
