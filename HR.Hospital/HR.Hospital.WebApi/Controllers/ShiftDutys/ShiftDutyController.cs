using System.Collections.Generic;
using HR.Hospital.IRepository.ShiftDutys;
using Microsoft.AspNetCore.Mvc;
namespace HR.Hospital.WebApi.Controllers.ShiftDutys
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShiftDutyController : ControllerBase
    {
        public IShiftDutyRepository ShiftDutyRepository { get; set; }

        public ShiftDutyController(IShiftDutyRepository shiftDutyRepository)
        {
            ShiftDutyRepository = shiftDutyRepository;
        }


        // GET: api/ShiftDuty
        [HttpGet]
        public List<Model.Ooperationuser> GetUserList(int roleId)
        {
            var userList = ShiftDutyRepository.GetUserList(roleId);
            return userList;
        }

        // GET: api/ShiftDuty/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ShiftDuty
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/ShiftDuty/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
