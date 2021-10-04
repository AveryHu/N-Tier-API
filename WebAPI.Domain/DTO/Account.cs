using System;
using WebAPI.Domain.Enum;

namespace WebAPI.Domain.DTO
{
    public class AccountDetail
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public string Name { get; set; }

        public Gender MemberGender { get; set; }
    }

    public class AccountCreation
    {
        public string Name { get; set; }

        public string Password_hash { get; set; }
    }

    public class AccountUpdate
    {
        public string Name { get; set; }

        public Gender MemberGender { get; set; }
    }

    public class AccountDelete
    {
        public Guid Id { get; set; }

        public string Password_hash { get; set; }
    }
}
