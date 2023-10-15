﻿using System.ComponentModel.DataAnnotations.Schema;
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
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public int TicketEnable { get; set; }
        public decimal PriceTicketKid { get; set; }
        public decimal PriceTicketAdult { get; set; }
        public long TourPackageId { get; set; }
        public string Pictures { get; set; }
    }
}
