using System;
namespace lotus.Models.Products
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Price { get; set; }
		public string? ImagePath { get; set; }
		public List<ProductDetailDto> ProductDetailsList { get; set; }

    }
}

