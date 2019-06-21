using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Summary
{
    public interface ISummaryRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        PageHelper<AttendanceSummary> GetPagedList(int pageIndex, int pageSize, string name);

    }
}
