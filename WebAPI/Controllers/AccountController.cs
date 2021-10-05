﻿using Microsoft.AspNetCore.Mvc;
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
            return Ok(account);
        }

        [HttpPost]
        public ActionResult Post([FromBody] AccountCreation value)
        {
            _logic.CreateAccount(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] AccountUpdate value)
        {
            _logic.UpdateAccountInfo(id, value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id, [FromBody] AccountDelete value)
        {
            _logic.DeleteAccount(id, value);
            return Ok();
        }
    }
}
