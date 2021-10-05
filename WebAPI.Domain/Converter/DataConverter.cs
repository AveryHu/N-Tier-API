using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.DTO;
using WebAPI.Domain.Entities;

namespace WebAPI.Domain.Converter
{
    public static class DataConverter
    {
        public static AccountDetail AccounttoAccountDetail(Account account)
        {
            return new AccountDetail
            {
                Id = account.Id,
                CreationDate = account.CreationDate,
                Name = account.Name,
                UserGender = account.UserGender,
            };
        }
        public static Account AccountCreationtoAccount(AccountCreation account)
        {
            return new Account
            {
                CreationDate = DateTime.UtcNow,
                Name = account.Name,
                Password = account.Password_hash,
                UserGender = account.UserGender,
            };
        }
    }
}
