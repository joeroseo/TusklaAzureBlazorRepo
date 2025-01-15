using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TusklaBlazor.Server.Models
{
    public class VehicleOrderItems
    {
        [Key]
        public int Id { get; set; } // Assuming Id is the primary key
        public int OrderId { get; set; }
        public string Description { get; set; } = null!;
        public int Price { get; set; }
    }
}
