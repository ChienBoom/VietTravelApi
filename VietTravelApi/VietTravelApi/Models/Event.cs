using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace VietTravelApi.Models
{
    [Table("event")]
    public class Event
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public long TourId { get; set; }
        public string Pictures { get; set; }
    }
}
