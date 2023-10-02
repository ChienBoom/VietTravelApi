using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("tourpackage")]
	public class TourPackage
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[StringLength(255)]
		public string Description { get; set; }
		public List<Tour_TourPackage> Tour_TourPackages { get; set; }
		public List<TicketDetail> TicketDetails { get; set; }
	}
}
