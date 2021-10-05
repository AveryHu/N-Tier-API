using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.DTO;

namespace WebAPI.Domain.Interfaces.Logics
{
    public interface IAccountLogic
    {
        IEnumerable<AccountDetail> GetAllAccountDetail();
        AccountDetail GetAccountDetail(int Id);
        bool CreateAccount(AccountCreation account);
        bool UpdateAccountInfo(int id, AccountUpdate account);
        bool DeleteAccount(int id, AccountDelete account);
    }
}
