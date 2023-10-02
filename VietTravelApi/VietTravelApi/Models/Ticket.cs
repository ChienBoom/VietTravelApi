using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("ticket")]
	public class Ticket
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime BookingDate { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		public long TourId { get; set; }
		[Required]
		public Tour Tour { get; set; }
		public long UserId { get; set; }
		[Required]
		[JsonIgnore]
		public User User { get; set; }
        public long TicketDetailId { get; set; }
        public TicketDetail TicketDetail { get; set; }
    }
}
