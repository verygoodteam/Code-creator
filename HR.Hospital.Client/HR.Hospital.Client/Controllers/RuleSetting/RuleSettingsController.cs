using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using HR.Hospital.Client.Common;
using HR.Hospital.Client.Models;
using HR.Hospital.Client.Models.Dto;
using Newtonsoft.Json;

namespace HR.Hospital.Client.Controllers.RuleSetting
{
    public class RuleSettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 显示视图
        /// </summary>
        /// <returns></returns>
        public IActionResult Show()
        {
            var getrulesetting = HttpClientApi.GetAsync<List<RulesettingsDto>>("http://localhost:12345/api/RuleSetting/GetRulesettings");
            return View(getrulesetting);
        }

        /// <summary>
        /// 添加视图
        /// </summary>
        /// <returns></returns>
        public IActionResult AddView()
        {
            return View();
        }

        /// <summary>
        /// 添加方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public int AddRulesetting(string rulesettings)
        {
            var list = JsonConvert.DeserializeObject<List<Rulesettings>>(rulesettings);
            var addrulesetting = HttpClientApi.PostAsync<List<Rulesettings>, int>(list, "http://localhost:12345/api/RuleSetting/AddRulesettings");
            return addrulesetting;
        }

    }
}