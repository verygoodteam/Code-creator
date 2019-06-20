using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Common;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Solitaire
{
    public interface ISolitaireRepository
    {
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <returns></returns>  
        PageHelper<SolitaireSet> GetPagedList(int pageIndex, int pageSize, string shift);
    }
}
