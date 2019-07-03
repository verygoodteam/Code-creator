using System;
using System.Collections.Generic;
using System.Text;
using HR.Hospital.Model.Dto;
using HR.Hospital.Model;
using HR.Hospital.IRepository.ApplicationSurgerys;
using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;

namespace HR.Hospital.Repository.ApplicationSurgerys
{
    public class ApplicationRepository : IApplicationRepository
    {
        //连接数据库
        string _conn = "Server=169.254.224.180;User Id=root;Password=123456;Database=hospitaldb";

        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 添加手术申请
        /// </summary>
        /// <param name="applicationsurgery"></param>
        /// <returns></returns>
        public int AddApplication(ApplicationSurgery applicationsurgery)
        {
            throw new NotImplementedException();
        }

        public List<ApplicationSurgeryDto> ApplicationList(int pageIndex = 1, int pageSize = 3)
        {
            throw new NotImplementedException();
        }

        ///// <summary>
        ///// 手术申请显示
        ///// </summary>
        ///// <returns></returns>
        //public List<ApplicationSurgeryDto> ApplicationList(int pageIndex = 1, int pageSize = 3)
        //{
        //    using (MySqlConnection con = new MySqlConnection(_conn))
        //    {
        //        string str1 = @"SELECT COUNT(*) from applicationsurgery LEFT JOIN patient ON patient.Id=applicationsurgery.Id
        //                      LEFT JOIN Operations on Operations.Id=applicationsurgery.OperationsId
        //                      LEFT JOIN ooperationuser s ON s.Id=applicationsurgery.ApplyPersonId
        //                      LEFT JOIN Administrative ON applicationsurgery.AdministrativeId=administrative.Id
        //                      LEFT JOIN ooperationuser m on m.Id=applicationsurgery.AnesthesiologistId
        //                      LEFT JOIN ooperationuser x ON x.Id=applicationsurgery.TourUserId
        //                      LEFT JOIN ooperationuser q ON q.Id=applicationsurgery.ApparatusUserId
        //                      LEFT JOIN ooperationuser z ON z.Id=applicationsurgery.OperationUserId";
        //        var total = con.Query<int>(str1);

        //        string str2 = @"SELECT applicationsurgery.Id,patient.PatientName,Operations.OperationName,s.OoperationUserName ApplyPersonName,
        //                       m.OoperationUserName AnesthesiologistName,x.OoperationUserName TourUserName,
        //                       q.OoperationUserName ApparatusUserName,z.OoperationUserName OperationUserName,
        //                       Administrative.AdministrativeName
        //                       from applicationsurgery LEFT JOIN patient ON patient.Id=applicationsurgery.Id
        //                       LEFT JOIN Operations on Operations.Id=applicationsurgery.OperationsId
        //                       LEFT JOIN ooperationuser s ON s.Id=applicationsurgery.ApplyPersonId
        //                       LEFT JOIN Administrative ON applicationsurgery.AdministrativeId=administrative.Id
        //                       LEFT JOIN ooperationuser m on m.Id=applicationsurgery.AnesthesiologistId
        //                       LEFT JOIN ooperationuser x ON x.Id=applicationsurgery.TourUserId
        //                       LEFT JOIN ooperationuser q ON q.Id=applicationsurgery.ApparatusUserId
        //                       LEFT JOIN ooperationuser z ON z.Id=applicationsurgery.OperationUserId";

        //        var perList = str2.OrderBy(p => p).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        //        var GetCollect = con.Query<Collect>(str);


        //        var collectDto = new CollectDto
        //        {
        //            CollectList = GetCollect.ToList(),
        //            Total = total.First<int>()
        //        };

        //        return collectDto;
        //    }
        //}

        /// <summary>
        /// 手术申请修改
        /// </summary>
        /// <param name="applicationsurgery"></param>
        /// <returns></returns>
        public int UpdateApplication(ApplicationSurgery applicationsurgery)
        {
            throw new NotImplementedException();
        }
    }
}
