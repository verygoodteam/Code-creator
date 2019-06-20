using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Summary;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Summary
{
    public class SummaryRepository: ISummaryRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<AttendanceSummary> GetPagedList(int pageIndex, int pageSize, string name)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<AttendanceSummary>();
            var list = db.AttendanceSummary.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.AttendanceSummary.Count();

            //根据人员名称查询
            if (name != null)
            {
                list = db.AttendanceSummary.OrderBy(p => p.Id).Where(p => p.Person.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.AttendanceSummary.Count(p => p.Person.Contains(name));
            }

            pageList.PageSizes = total;//总条数
            pageList.PageList = list;//查询数据集合
            pageList.PageNum = (pageList.PageSizes / pageSize);//总页数

            return pageList;
        }
    }
}
