using System.Collections.Generic;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.ApprovalFunction
{
    //活动类型表查询绑定下拉
    public interface IActivityRepository
    {
        List<ActivityTable> GetListActivity();
    }
}
