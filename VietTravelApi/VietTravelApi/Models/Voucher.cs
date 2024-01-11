using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    [Table("voucher")]
    public class Voucher
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Active { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        [Required]
        public float Sale { get; set; }
        public int IsDelete { get; set; }
    }
}
