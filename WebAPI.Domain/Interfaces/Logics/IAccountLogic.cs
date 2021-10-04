using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.DTO;

namespace WebAPI.Domain.Interfaces.Logics
{
    public interface IAccountLogic
    {
        IEnumerable<AccountDetail> GetAllAccountDetail();
    }
}
