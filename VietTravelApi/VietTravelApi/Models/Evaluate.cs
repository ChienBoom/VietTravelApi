using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("evaluate")]
	public class Evaluate
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(2000)]
		public string Content { get; set; }
		[Required]
        [DataType(DataType.DateTime)]
        public DateTime DateOfEvaluate { get; set; }
		[Required]
		public int NumberOfInteractions { get; set; }
		public float MediumStar { get; set; }
		public long TourId { get; set; }
		[JsonIgnore]
		public Tour Tour { get; set; }
		public long UserId { get; set; }
		public User User { get; set; }
	}
}
