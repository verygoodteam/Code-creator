using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Detail;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Detail
{
    public class DetailRepository: IDetailRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<AttendanceDetail> GetPagedList(int pageIndex, int pageSize, string time, string name)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<AttendanceDetail>();
            var list = db.AttendanceDetail.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.AttendanceDetail.Count();

            //根据排班日期查询
            if (time != null)
            {
                list = db.AttendanceDetail.OrderBy(p => p.Id).Where(p => p.AttendanceTime == time).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.AttendanceDetail.Count(p => p.AttendanceTime == time);
            }
            //根据人员名称查询
            if (name != null)
            {
                list = db.AttendanceDetail.OrderBy(p => p.Id).Where(p => p.Person.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.AttendanceDetail.Count(p => p.Person.Contains(name));
            }
            //双条件查询
            if (time != null && name != null)
            {
                list = db.AttendanceDetail.OrderBy(p => p.Id).Where(p =>p.AttendanceTime.Equals(time) && p.Person.Contains(name)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.AttendanceDetail.Count(p => p.AttendanceTime == time && p.Person.Contains(name));
            }

            pageList.PageSizes = total;//总条数
            pageList.PageList = list;//查询数据集合
            pageList.PageNum = (pageList.PageSizes / pageSize);//总页数

            return pageList;
        }
    }
}
