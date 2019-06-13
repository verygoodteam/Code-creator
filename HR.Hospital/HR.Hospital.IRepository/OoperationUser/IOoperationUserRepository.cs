using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.OoperationUser
{
    public interface IOoperationUserRepository
    {
        //手术室用户添加
        int AddOoperationUser(Ooperationuser operuser);
        ////手术室用户编辑
        int UpdateOoperationUser(Ooperationuser operuser);
        //返填
        Ooperationuser RefillUser(int id);
        //手术室用户显示
        List<Ooperationuser> ShowOoperationUser(int hierarchyid = 0, string name = "", string englishname = "");
        //能级下拉
        List<Hierarchy> GetHierarchies();
    }
}
