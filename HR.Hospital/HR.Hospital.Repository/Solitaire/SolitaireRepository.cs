using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.IRepository.Solitaire;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Solitaire
{
    public class SolitaireRepository: ISolitaireRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        public PageHelper<SolitaireSet> GetPagedList(int pageIndex, int pageSize, string shift)
        {
            hospitaldbContext db = new hospitaldbContext();
            var pageList = new PageHelper<SolitaireSet>();

            var list = db.SolitaireSet.OrderBy(p => p.Id).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var total = db.SolitaireSet.Count();

            //根据人名称查询
            if (shift != null)
            {
                list = db.SolitaireSet.OrderBy(p => p.Id).Where(p => p.Shift.Contains(shift)).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
                total = db.SolitaireSet.Count(p => p.Shift.Contains(shift));
            }

            pageList.PageSizes = total;//总条数
            pageList.PageList = list;//查询数据集合
            pageList.PageNum = (pageList.PageSizes / pageSize);//总页数

            return pageList;
        }
    }
}
