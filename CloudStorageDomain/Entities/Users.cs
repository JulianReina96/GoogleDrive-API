using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStorageDomain.Entities
{
	public class Users
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string AcessToken { get; set; } = string.Empty;
		public string RefreshToken { get; set; } = string.Empty;


    }
}
