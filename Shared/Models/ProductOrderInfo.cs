using System;
using System.Collections.Generic;

namespace TusklaBlazor.Server.Models
{
    public class ProductOrderInfo
    {

        public int OrderId { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string Zip { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
