using System;
using System.Collections.Generic;

namespace TusklaBlazor.Shared.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; } 
        public string Category { get; set; } = null!;
        public string imageSource { get; set; } = null!;
        public bool isAvailable { get; set; } = true;


    }
}
