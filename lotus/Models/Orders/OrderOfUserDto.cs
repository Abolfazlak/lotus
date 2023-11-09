using System;
namespace lotus.Models.Orders
{
	public class OrderOfUserDto
	{
        public string? ProductsItems { get; set; }
        public string? TotalPrice { get; set; }
        public bool IsPaid { get; set; } = false;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

    }
}

