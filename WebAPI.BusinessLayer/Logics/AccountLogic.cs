﻿using System;
using System.Collections.Generic;
using WebAPI.Domain.Converter;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Entities;
using WebAPI.Domain.Enum;
using WebAPI.Domain.Interfaces.Logics;
using WebAPI.Domain.Interfaces.UnitofWork;

namespace WebAPI.BusinessLayer.Logics
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<AccountDetail> GetAllAccountDetail()
        {
            List<Account> accounts = _unitOfWork.Accounts.GetAll() as List<Account>;  
            return accounts.ConvertAll(new Converter<Account, AccountDetail>
                (DataConverter.AccounttoAccountDetail));
        }
        public AccountDetail GetAccountDetail(int id)
        {
            Account account = _unitOfWork.Accounts.GetById(id) as Account;
            return DataConverter.AccounttoAccountDetail(account);
        }
        public bool CreateAccount(AccountCreation account)
        {
            Account newaccount = DataConverter.AccountCreationtoAccount(account);
            _unitOfWork.Accounts.Add(newaccount);
            return _unitOfWork.Complete() == 1;
        }

        public bool UpdateAccountInfo(int id, AccountUpdate account)
        {
            _unitOfWork.Accounts.UpdateAccount(id, account);
            _unitOfWork.Complete();
            return true;
        }

        public bool DeleteAccount(int id, AccountDelete account)
        {
            Account dbaccount = _unitOfWork.Accounts.GetById(id) as Account;
            _unitOfWork.Accounts.Remove(dbaccount);
            _unitOfWork.Complete();
            return true;
        }
    }
}
