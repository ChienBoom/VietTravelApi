using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelApi.Models
{
	[Table("city")]
	public class City
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		[StringLength(255)]
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
		public List<Tour> Tours { get; set; }
		public string UniCodeName { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
		public int NumberOfEvaluate { get; set; }
		public float MediumStar { get; set; }
		public string CoordLat { get; set; } //vĩ độ
		public string CoordLon { get; set; } //kinh độ
	}
}
