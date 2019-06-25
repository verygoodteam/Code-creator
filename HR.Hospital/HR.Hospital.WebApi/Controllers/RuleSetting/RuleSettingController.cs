using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Model.Dto;
using HR.Hospital.Model;
using HR.Hospital.IRepository.RuleSetting;

namespace HR.Hospital.WebApi.Controllers.RuleSetting
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleSettingController : ControllerBase
    {
        public IRuleSettingRepository RuleSettingRepository { get; set; }

        //构造函数注入
        public RuleSettingController(IRuleSettingRepository ruleSettingRepository)
        {
            RuleSettingRepository = ruleSettingRepository;                                                                                                   
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        [HttpPost("AddRulesettings")]
        public int AddRulesettings([FromBody]List<Rulesettings> rulesettings)
        {
            var addruleset = RuleSettingRepository.AddRuleSetting(rulesettings);
            return addruleset;
        }

        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetRulesettings")]
        public List<RulesettingsDto> GetRulesettings()
        {
            var getruleset = RuleSettingRepository.GetRulesettings();
            return getruleset;
        }

        /// <summary>
        /// 班次下拉
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetShiftssettings")]
        public List<Shiftssetting> GetShiftssettings()
        {
            var getshiftsset = RuleSettingRepository.GetShiftssettings();
            return getshiftsset;
        }

        /// <summary>
        /// 是否生效
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Iseffec")]
        public int Iseffec(int id)
        {
            var iseffec = RuleSettingRepository.Iseffec(id);
            return iseffec;
        }
    }
}