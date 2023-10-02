using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
    [Table("tour_toupackage")]
    public class Tour_TourPackage
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long TourId { get; set; }
        [Required]
        [JsonIgnore]
        public Tour Tour { get; set; }
        public long TourPackageId { get; set; }
        [Required]
        [JsonIgnore]
        public TourPackage TourPackage { get; set; }
    }
}
