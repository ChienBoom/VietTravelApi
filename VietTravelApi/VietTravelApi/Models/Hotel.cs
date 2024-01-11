﻿using System.Collections.Generic;
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
        public string UniCodeName { get; set; }
        public decimal PriceHour { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
		public int NumberOfEvaluate { get; set; }
		public int NumberOfEvaluateStar { get; set; }
		public float MediumStar { get; set; }
		//
		[NotMapped]
		[JsonIgnore]
		public City City { get; set; }
		[NotMapped]
		public List<Evaluate> Evaluates { get; set; }
		[NotMapped]
		public List<EvaluateStar> EvaluateStars { get; set; }
		[NotMapped]
		public List<TourPackage> TourPackages { get; set; }

		//
		//public int TotalRoom { get; set; }
		//public int VipRoom { get; set; }
		//public int NormalRoom { get; set; }
		////public int RemainingVipRoom { get; set; }
		////public int RemainingNormalRoom { get; set; }
		//public decimal PriceVipRoom { get; set; }
		//public decimal PriceNormalRoom { get; set; }
	}
}
