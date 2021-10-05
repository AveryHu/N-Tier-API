using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPI.DataLayer.DatabaseContext;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Interfaces.Repositorys;

namespace WebAPI.DataLayer.Repositorys
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(LocalContext context) : base(context)
        {
        }
        public bool UpdateAccount(int id, AccountUpdate account)
        {
            Account dbaccount = this.GetById(id);
            dbaccount.Name = account.Name;
            dbaccount.UserGender = account.UserGender;
            return true;
        }
    }
}
