using System;
using WebAPI.Domain.Enum;

namespace WebAPI.Domain.DTO
{
    public class AccountDetail
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public Gender UserGender { get; set; }
    }

    public class AccountCreation
    {
        public string Name { get; set; }

        public string Password_hash { get; set; }

        public Gender UserGender { get; set; }
    }

    public class AccountUpdate
    {
        public string Name { get; set; }

        public Gender UserGender { get; set; }
    }

    public class AccountDelete
    {
        public int Id { get; set; }

        public string Password_hash { get; set; }
    }
}
