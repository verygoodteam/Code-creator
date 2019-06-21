using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Detail
{
    public interface IDetailRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        PageHelper<AttendanceDetail> GetPagedList(int pageIndex, int pageSize, string time, string name);

    }
}
