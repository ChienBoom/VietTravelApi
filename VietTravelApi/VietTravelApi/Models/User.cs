using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using VietTravelApi.Models;

namespace VietTravelApi.Models
{
	[Table("user")]
	public class User: Account
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime DateOfBirth { get; set; }
		[Required]
		[StringLength(10)]
		public string Sex { get; set; }
		[Required]
		[StringLength(100)]
		[Index(IsUnique = true)]
		public string Email { get; set; }
		[Required]
		[StringLength(12)]
		public string PhoneNumber { get; set; }
		[Required]
		[StringLength(255)]
		public string Address { get; set; }
		[Required]
		[StringLength(50)]
		public string Role { get; set; }
		[NotMapped]
		public List<Ticket> Tickets { get; set; }
        public string UniCodeName { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
		public string Picture { get; set; }
	}
}
