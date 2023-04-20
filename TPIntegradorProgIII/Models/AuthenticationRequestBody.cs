using System.ComponentModel.DataAnnotations;

namespace TPIntegradorProgIII.Models
{
	public class AuthenticationRequestBody
	{
		public string Password { get; set; }
		public string UserName { get; set; }
	}
}

