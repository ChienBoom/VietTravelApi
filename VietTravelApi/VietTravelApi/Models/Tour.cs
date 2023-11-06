using Microsoft.Extensions.Logging;
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
        [StringLength(1000)]
        public string Pictures { get; set; }
        [Required]
        [StringLength(2000)]
        public string TitleIntroduct { get; set; }
        [Required]
        [StringLength(2000)]
        public string ContentIntroduct { get; set; }
		public long CityId { get; set; }
        public int NumberOfEvaluate { get; set; }
        public float MediumStar { get; set; }
        public string UniCodeName { get; set; }
        public decimal PriceTourGuide { get; set; }
        public decimal PriceBase { get; set; }
        public decimal TotalPrice { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
        public string CoordLat { get; set; } //vĩ độ
        public string CoordLon { get; set; } //kinh độ
    }
}
