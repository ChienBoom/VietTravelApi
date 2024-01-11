using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    [Table("table")]
    public class Table
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int IsActive { get; set; }
        public int IsDelete { get; set; }
    }
}
