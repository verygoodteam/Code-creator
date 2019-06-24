using System;
using System.Collections.Generic;
using System.Text;

using HR.Hospital.Model;
using HR.Hospital.Model.Dto;

namespace HR.Hospital.IRepository.RuleSetting
{
   public interface IRuleSettingRepository
    {
        /// <summary>
        /// 排班规则添加
        /// </summary>
        /// <returns></returns>
        int AddRuleSetting(List<Rulesettings> rulesettings);

        /// <summary>
        /// 显示规则
        /// </summary>
        /// <returns></returns>
        List<RulesettingsDto> GetRulesettings();

        /// <summary>
        /// 班次下拉
        /// </summary>
        /// <returns></returns>
        List<Shiftssetting> GetShiftssettings();

        /// <summary>
        /// 是否生效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Iseffec(int id);
    }
}
