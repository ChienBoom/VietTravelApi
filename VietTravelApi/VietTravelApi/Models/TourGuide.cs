using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VietTravelApi.Models
{
    [Table("tourguide")]
    public class TourGuide
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Sex { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(12)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        public long TourId { get; set; }
        [Required]
        [JsonIgnore]
        public Tour Tour { get; set; }
        public long TicketDetailId { get; set; }
        [JsonIgnore]
        public TicketDetail TicketDetail { get; set;}
    }
}
