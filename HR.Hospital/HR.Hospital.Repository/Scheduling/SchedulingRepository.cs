using HR.Hospital.IRepository.Scheduling;
using HR.Hospital.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.Hospital.Repository.Scheduling
{
    public class SchedulingRepository : ISchedulingRepository
    {
        //连接数据库
        string _conn = "Server=169.254.224.180;User Id=root;Password=123456;Database=hospitaldb";

        public bool Add(Model.Scheduling scheduling)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 显示排班列表
        /// </summary>
        /// <returns></returns>
        public List<Model.Scheduling> GetSchedulings()
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                return null;
            }
        }
    }
}
