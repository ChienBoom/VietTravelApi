using Org.BouncyCastle.Bcpg.OpenPgp;
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
		public int Eva { get; set; } //Đánh giá Thành Phố/ Tour/ Khách sạn/ Nhà hàng theo thứ tự 1/2/3/4 - 0 là không đánh giá
        [Required]
        public string Content { get; set; }
        [Required]
        public long EvaId { get; set; } // Id của Thành phố/ Tour/ Khách sạn/ Nhà hàng được đánh giá
		[Required]
		public long UserId { get; set; }
		[NotMapped]
		public User User { get; set; }
    }
}
