using System;
namespace lotus.Models.Orders
{
	public class OrderDto
	{
		public string? ProductsItems { get; set; }
		public string? TotalPrice { get; set; }
		public bool IsPaid { get; set; } = false;
		public string? UserId { get; set; }
	}
}

