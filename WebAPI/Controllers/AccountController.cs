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
            IEnumerable<AccountDetail> accounts = _logic.GetAllAccountDetail();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public ActionResult<AccountDetail> Get(int id)
        {
            AccountDetail account = _logic.GetAccountDetail(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AccountCreation value)
        {
            bool success = _logic.CreateAccount(value);
            if(success)
                return Ok();
            return BadRequest();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] AccountUpdate value)
        {
            bool success = _logic.UpdateAccountInfo(id, value);
            if (success)
                return Ok();
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id, [FromBody] AccountDelete value)
        {
            bool success = _logic.DeleteAccount(id, value);
            if(success)
                return Ok();
            return NotFound();
        }
    }
}
