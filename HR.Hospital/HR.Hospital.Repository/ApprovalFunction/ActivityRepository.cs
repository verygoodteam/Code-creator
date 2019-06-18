using System.Collections.Generic;
using System.Linq;
using HR.Hospital.IRepository.ApprovalFunction;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.ApprovalFunction
{
    //活动类型表查询绑定下拉
    public class ActivityRepository : IActivityRepository
    {
        private readonly hospitaldbContext _context = new hospitaldbContext();
        public List<Activity> GetListActivity()
        {
            var listActivity = _context.Activity.ToList();
            return listActivity;
        }
    }
}
