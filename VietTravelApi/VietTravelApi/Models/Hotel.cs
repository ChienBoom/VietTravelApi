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
		public long TourId { get; set; }
		[Required]
        [JsonIgnore]
        public Tour Tour { get; set; }
		public List<TicketDetail> TicketDetails { get; set; }
		//[JsonIgnore]
		//public List<TicketDetail> TicketDetails { get; set; }
	}
}
