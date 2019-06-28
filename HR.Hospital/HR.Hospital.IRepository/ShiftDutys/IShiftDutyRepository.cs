using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.ShiftDutys
{
    public interface IShiftDutyRepository
    {
        List<Ooperationuser> GetUserList(int roleId);
    }
}
