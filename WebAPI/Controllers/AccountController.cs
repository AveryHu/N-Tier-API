using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Enum;
using WebAPI.Domain.Interfaces.Logics;

namespace WebAPI.ServiceLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {       
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountLogic _logic;

        public AccountController(ILogger<AccountController> logger, IAccountLogic logic)
        {
            _logger = logger;
            _logic = logic;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AccountDetail>> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new AccountDetail
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now.AddDays(index),
                Name = "Testone",
                MemberGender = Gender.Unknown,
            }).ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<AccountDetail> Get(int id)
        {
            return Ok(new AccountDetail());
        }

        [HttpPost]
        public ActionResult Post([FromBody] AccountCreation value)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] AccountUpdate value)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id, [FromBody] AccountDelete value)
        {
            return Ok();
        }
    }
}
