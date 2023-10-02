using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelApi.Models
{
	public class Account
	{
		[Required]
		[Index(IsUnique = true)]
		[StringLength(50)]
		public string Username { get; set; }
		[Required]
		[StringLength(25)]
		public string Password { get; set; }
	}
}
