using System;
using lotus.Models.Products;

namespace lotus.Services.Products
{
	public interface IProductService
	{
        public Task<bool> AddProductDetailService(AddProductDetailDto dto);
        public Task<bool> AddProductService(AddProductDto dto);
		public Task<List<ProductDto>> GetAllProducts();
		public string SaveImageToServer(string base64Image, string Name);

    }
}

