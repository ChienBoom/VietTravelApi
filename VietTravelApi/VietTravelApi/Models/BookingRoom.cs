using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    [Table("bookingroom")]
    public class BookingRoom
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserId { get; set; }
        public User User { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime BookingTime { get; set; }
        public long RoomId { get; set; }
        public Room Room { get; set; }
    }
}
