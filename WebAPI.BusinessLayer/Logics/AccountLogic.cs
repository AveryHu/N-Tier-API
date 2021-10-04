using System;
using System.Collections.Generic;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Enum;
using WebAPI.Domain.Interfaces.Logics;

namespace WebAPI.BusinessLayer.Logics
{
    public class AccountLogic : IAccountLogic
    {
        public IEnumerable<AccountDetail> GetAllAccountDetail()
        {
            List<AccountDetail> accountlist = new List<AccountDetail>();
            accountlist.Add(new AccountDetail
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow,
                Name = "Testone",
                MemberGender = Gender.Unknown,
            });
            accountlist.Add(new AccountDetail
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow.AddDays(-1),
                Name = "Testtwo",
                MemberGender = Gender.Female,
            });
            accountlist.Add(new AccountDetail
            {
                Id = Guid.NewGuid(),
                CreationDate = DateTime.UtcNow.AddDays(-5),
                Name = "Testthree",
                MemberGender = Gender.Male,
            });
            return accountlist;
        }
    }
}
