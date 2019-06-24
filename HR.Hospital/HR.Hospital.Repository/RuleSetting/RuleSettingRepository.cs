using System;
using System.Collections.Generic;
using System.Text;

using HR.Hospital.IRepository.RuleSetting;
using HR.Hospital.Model;
using Dapper;
using MySql.Data.MySqlClient;
using HR.Hospital.Model.Dto;
using System.Linq;

namespace HR.Hospital.Repository.RuleSetting
{
    public class RuleSettingRepository : IRuleSettingRepository
    {
        //连接数据库
        string _conn = "Server=169.254.224.180;User Id=root;Password=123456;Database=hospitaldb";

        //实例化上下文类
        hospitaldbContext db = new hospitaldbContext();

        /// <summary>
        /// 添加规则
        /// </summary>
        /// <returns></returns>
        public int AddRuleSetting(List<Rulesettings> rulesettings)
        {
            int i = 0;
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                foreach (var item in rulesettings)
                {
                   string addrulesetting = $@"INSERT INTO rulesettings(OneShiftsId, TwoShiftsId, OneTime, TwoTime, ThreeTime, Types) VALUES
                                      ('{item.OneShiftsId}', '{item.TwoShiftsId}', '{item.OneTime}', '{item.TwoTime}', '{item.ThreeTime}', '{item.Types}')";
                    i=  con.Execute(addrulesetting);
                }
                
                return i;
            }                
        }

        /// <summary>
        /// 显示规则
        /// </summary>
        /// <returns></returns>
        public List<RulesettingsDto> GetRulesettings()
        {
            using (MySqlConnection con=new MySqlConnection(_conn))
            {
                var getruleset = @"SELECT r.Id,r.OneTime,r.TwoTime,r.ThreeTime,r.Types,r.Iseffec,r.OneShiftsId,r.TwoShiftsId,s1.ShiftssettingName OneShiftsIdName,
                                  s2.ShiftssettingName TwoShiftsName
                                  from rulesettings r JOIN shiftssetting s1
                                  on r.OneShiftsId = s1.Id
                                  JOIN shiftssetting s2 on r.TwoShiftsId = s2.Id";

                var getlist = con.Query<RulesettingsDto>(getruleset);
                return getlist.ToList();
            }
        }

        /// <summary>
        /// 班次下拉
        /// </summary>
        /// <returns></returns>
        public List<Shiftssetting> GetShiftssettings()
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var getshuftsset = " select * from shiftssetting";
                var getlist = con.Query<Shiftssetting>(getshuftsset);
                return getlist.ToList();
            }

        }

        /// <summary>
        /// 是否生效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Iseffec(int id)
        {
            using (MySqlConnection con = new MySqlConnection(_conn))
            {
                var iseffec = $"update rulesettings set Iseffec = (case Iseffec when  '1' then 0 else 1 end) where Id ={id}";
                var i = con.Execute(iseffec);
                return i;
            }
        }
    }
}
