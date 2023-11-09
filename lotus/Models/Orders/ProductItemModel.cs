using System;
namespace lotus.Models.Orders
{
	public class ProductItemModel
	{
		public int ProductId { get; set; }
		public string? ProductName { get; set; }
		public int Count { get; set; }
		public string? BaseFee { get; set; }
        public string? Price { get; set; }
    }
}

