﻿using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
	[Table("tour")]
	public class Tour
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(100)]
		public string Name { get; set; }
		[Required]
		[StringLength(100)]
		public string Address { get; set; }
		[StringLength(1000)]
		public string Description { get; set; }
		[Required]
        [StringLength(1000)]
        public string Pictures { get; set; }
        [Required]
        [StringLength(2000)]
        public string TitleIntroduct { get; set; }
        [Required]
        [StringLength(2000)]
        public string ContentIntroduct { get; set; }
		public long CityId { get; set; }
		[JsonIgnore]
		public City City { get; set; }
		public long EvaluateId { get; set; }
		public Evaluate Evaluate { get; set; }
		public List<TourPackage> TourPackages { get; set; }
    }
}