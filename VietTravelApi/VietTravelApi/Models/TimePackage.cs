using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelApi.Models
{
    [Table("timepackage")]
    public class TimePackage
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HourNumber { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
        //
        [NotMapped]
        public List<TourPackage> TourPackages { get; set; }
    }
}
