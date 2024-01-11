using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
    [Table("restaurant")]
    public class Restaurant
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
        public decimal PriceDefault { get; set; }
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
        //public int TotalTable { get; set; }
        //public int TotalVipTable { get; set; }
        //public int TotalNormalTabel { get; set; }
        //public int VipTableSix { get; set; }
        //public int VipTableTen { get; set; }
        //public int NormalTabelSix { get; set; }
        //public int NormalTabelTen { get; set; }
        //public int RemainingVipTable { get; set; }
        //public int RemainingNormalTable { get; set; }
        //public decimal PriceVipTableSix { get; set; }
        //public decimal PriceVipTableTen { get; set; }
        //public decimal PriceNormalTableSix { get; set; }
        //public decimal PriceNormalTableTen { get; set; }
    }
}
