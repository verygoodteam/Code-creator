using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using HR.Hospital.IRepository.Login;

namespace HR.Hospital.Repository.Login
{
    public class UserRepository : IUserRepository
    {
        public int Login(Model.Ooperationuser ooperationuser)
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {
                Model.Ooperationuser uer = context.Ooperationuser.Where(u => u.OoperationUserName == ooperationuser.OoperationUserName && u.Pwd == ooperationuser.Pwd).FirstOrDefault();
                if (uer != null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Login(string name, string pwd)
        {
            throw new NotImplementedException();
        }

        public List<Model.Ooperationuser> ooperationusers()
        {
            using (Model.hospitaldbContext context = new Model.hospitaldbContext())
            {
                return context.Ooperationuser.ToList();
            }
        }
    }
}