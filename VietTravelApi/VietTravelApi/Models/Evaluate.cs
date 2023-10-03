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
		public int NumberOfEvaluate { get; set; }
		public float MediumStar { get; set; }
		[JsonIgnore]
		public Tour Tour { get; set; }
    }
}
