using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace VietTravelApi.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        public string Content { get; set; }
        public int TicketEnable { get; set; }
        public decimal PriceTicketKid { get; set; }
        public decimal PriceTicketAdult { get; set; }
        public long TourId { get; set; }
        public string Pictures { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
    }
}
