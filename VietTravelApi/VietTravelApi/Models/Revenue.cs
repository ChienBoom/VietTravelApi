using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VietTravelApi.Models
{
    public class Revenue
    {
        public string Label { get; set; }
        public List<string> Labels { get; set; }
        public List<List<Ticket>> Data { get; set; }
    }
}
