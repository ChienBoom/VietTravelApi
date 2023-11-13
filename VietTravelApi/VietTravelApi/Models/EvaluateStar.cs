using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    [Table("evaluateStar")]
    public class EvaluateStar
    {
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; }
		[Required]
		public int Eva { get; set; } //Đánh giá Thành Phố/ Tour/ Khách sạn/ Nhà hàng theo thứ tự 1/2/3/4 - 0 là không đánh giá
		[Required]
		public int NumberStar { get; set; }
		[Required]
		public long EvaId { get; set; } // Id của Thành phố/ Tour/ Khách sạn/ Nhà hàng được đánh giá
		[Required]
		public long UserId { get; set; }
		[NotMapped]
		public User User { get; set; }
		public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
	}
}
