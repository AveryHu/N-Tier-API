using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.DataLayer.DatabaseContext;
using WebAPI.DataLayer.Repositorys;
using WebAPI.Domain.Interfaces.Repositorys;
using WebAPI.Domain.Interfaces.UnitofWork;

namespace WebAPI.DataLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LocalContext _context;
        public UnitOfWork(LocalContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
        }
        public IAccountRepository Accounts { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
