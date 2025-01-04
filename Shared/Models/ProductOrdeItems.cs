using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TusklaBlazor.Server.Models
{
    public class ProductOrderItems
    {
        [Key]
        public int Id { get; set; } // Assuming Id is the primary key
        public int OrderId { get; set; }
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int Quantity { get; set; }

    }
}
