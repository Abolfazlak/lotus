using System;
using lotus.Models.Products;
using lotus.Repositories.Products;
using lotus.DataProvide;
using System.Text.RegularExpressions;
using lotus.Models.UserManagement;

namespace lotus.Services.Products
{
	public class ProductService : IProductService
	{
		private readonly IProductRepo _productRepo;
        private readonly IConfiguration _configuration;

        public ProductService(IProductRepo productRepo, IConfiguration configuration)
		{
			_productRepo = productRepo;
			_configuration = configuration;
		}


		public async Task<bool> AddProductService(AddProductDto dto)
		{
			var imagePath = SaveImageToServer(dto.Image, dto.Name);

			return await _productRepo.AddProductToDb(dto, imagePath);
        }

        public async Task<bool> AddProductDetailService(AddProductDetailDto dto)
		{
			var product = await _productRepo.FindProductById(dto.ProductId);
			if (product != null)
			{
                return await _productRepo.AddProductDetailToDb(dto);
            }
			return false;
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
            var products = await _productRepo.GetAllProductsFromDb();
            return products;
        }

        public string SaveImageToServer(string base64Image, string Name)
		{
			try
			{
				Regex rg = new Regex(@"(?<=/)(.*)(?=;)");

				var img = base64Image.Split(',');
				var type = rg.Matches(img[0])[0];
				var filePath = _configuration["ImagePath"] + Name + $".{type}";

				File.WriteAllBytes(filePath, Convert.FromBase64String(img[1]));

                return filePath;
            }
			catch(Exception ex)
			{
				return "";
			}

        }


	}
}

