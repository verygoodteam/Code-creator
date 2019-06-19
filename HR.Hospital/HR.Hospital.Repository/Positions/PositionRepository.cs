using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using HR.Hospital.IRepository.Positions;
using HR.Hospital.Model;

namespace HR.Hospital.Repository.Positions
{
    public class PositionRepository : IPositionRepository
    {
        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 添加职务
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public int AddPosition(Position position)
        {
            var addposition = db.Position.Add(position);
            var i = db.SaveChanges();
            return i; ;
        }

        /// <summary>
        /// 删除职务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeletePosition(int id)
        {
            var getposition = db.Position.FirstOrDefault(p => p.Id == id);
            var deleteposition = db.Position.Remove(getposition);
            var i = db.SaveChanges();
            return i;
        }

        /// <summary>
        /// 获取职务
        /// </summary>
        /// <returns></returns>
        public List<Position> GetPosition()
        {
            var getposition = db.Position;
            return getposition.ToList();
        }
    }
}
