using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelApi.Models
{
    [NotMapped]
    public class ScheduleTourPackage
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public long ScheduleId { get; set; }
    }
}
