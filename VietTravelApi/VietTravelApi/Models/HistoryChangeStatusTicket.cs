using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    [Table("historyChangeStatusTicket")]
    public class HistoryChangeStatusTicket
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime TimeChange { get; set; }
        public long ChangeBy { get; set; }
        [NotMapped]
        public User User { get; set; }
        public long TicketId { get; set; }
        [NotMapped]
        public Ticket Ticket { get; set; }
        public int oldStatus { get; set; }
        public int newStatus { get; set; }
    }
}
