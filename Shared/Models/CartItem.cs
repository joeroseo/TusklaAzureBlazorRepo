using System;
using System.Collections.Generic;

namespace TusklaBlazor.Shared.Models;

public class CartItem
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
}
