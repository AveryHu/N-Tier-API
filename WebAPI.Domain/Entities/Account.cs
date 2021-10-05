using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Enum;

namespace WebAPI.Domain.Entities
{
    public class Account
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public DateTime CreationDate { get; set; }
		public Gender UserGender { get; set; }
	}
}
