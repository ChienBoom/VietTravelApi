using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("ticket_detail")]
	public class TicketDetail
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime StartDay { get; set; }
		[Required]
		[DataType(DataType.DateTime)]
		public DateTime EndDay { get; set; }
		public Decimal Price { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		public long HotelId { get; set; }
		[JsonIgnore]
		public Hotel Hotel { get; set; }
		public List<TourGuide> TourGuides { get; set;}
		public long TourPackageId { get; set; }
		[JsonIgnore]
		public TourPackage TourPackage { get; set;}
		public List<Schedule> Schedules { get; set;}
        [Required]
        [JsonIgnore]
        public Ticket Ticket { get; set; }
    }
}
