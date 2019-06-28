using HR.Hospital.IRepository.ShiftDutys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.ShiftDutys
{
    public class ShiftDutyRepository : IShiftDutyRepository
    {
        private readonly hospitaldbContext _context = new hospitaldbContext();
        public List<Ooperationuser> GetUserList(int roleId)
        {
            var userList = _context.Ooperationuser.Where(p => p.Roleid == roleId).ToList();
            return userList;
        }
    }
}
