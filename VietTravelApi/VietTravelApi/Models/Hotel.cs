using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("hotel")]
	public class Hotel
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		[Required]
		[StringLength(255)]
		public string Address { get; set; }
		[Required]
		[StringLength(12)]
		public string PhoneNumber { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		[StringLength(1000)]
		public string TitleIntroduct { get; set; }
		[StringLength(2000)]
		public string ContentIntroduct { get; set; }
		public long CityId { get; set; }
		public string Pictures { get; set; }
	}
}
