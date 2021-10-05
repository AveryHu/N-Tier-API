using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Interfaces.Repositorys;

namespace WebAPI.Domain.Interfaces.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        int Complete();
    }
}
