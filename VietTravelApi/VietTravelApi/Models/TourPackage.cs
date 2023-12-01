using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VietTravelApi.Models
{
    [Table("tourpackage")]
    public class TourPackage
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal BasePrice { get; set; }
        public float Discount { get; set; }
        public decimal LastPrice { get; set; }
        public long TourId { get; set; }
        public long HotelId { get; set; }
        public long RestaurantId { get; set; }
        public long TimePackageId { get; set; }
        public string CreateBy { get; set; }
        public string ListScheduleTourPackage { get; set; }
        [NotMapped]
        public List<Schedule> ScheduleTourPackages { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Hotel Hotel { get; set; }
        [NotMapped]
        [JsonIgnore]
        public Restaurant Restaurant { get; set; }
        public int IsDelete { get; set; } // 1 là đã xóa, 0 là chưa xóa
        //
        [NotMapped]
        [JsonIgnore]
        public Tour Tour { get; set; }
        [NotMapped]
        public List<Ticket> Tickets { get; set; }
        [NotMapped]
        [JsonIgnore]
        public TimePackage TimePackage { get; set; }
    }
}
