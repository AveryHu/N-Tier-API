using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Interfaces.Repositorys
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
    }
}
