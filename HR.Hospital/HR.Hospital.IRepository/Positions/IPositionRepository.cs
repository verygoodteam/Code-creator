using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.IRepository.Positions;
using HR.Hospital.Model;

namespace HR.Hospital.IRepository.Positions
{
   public interface IPositionRepository
    {
        /// <summary>
        /// 职务添加
        /// </summary>
        /// <param name="hierarchy"></param>
        /// <returns></returns>
        int AddPosition(Position position);

        /// <summary>
        /// 职务显示
        /// </summary>
        /// <returns></returns>
        List<Position> GetPosition();

        /// <summary>
        /// 删除职务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeletePosition(int id);
    }
}
