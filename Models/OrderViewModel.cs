using Shop.Models;
using System.Collections.Generic;

public class OrderViewModel
{
    public string CustomerName { get; set; } = "";
    public string Email { get; set; } = "";
    public string Address { get; set; } = "";
    public List<CartItem> Items { get; set; } = new();
    public decimal Total { get; set; }
}
