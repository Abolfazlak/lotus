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
		private readonly ILogger<ProductService> _logger;

        public ProductService(IProductRepo productRepo, IConfiguration configuration,
							  ILogger<ProductService> logger)
		{
			_productRepo = productRepo;
			_configuration = configuration;
			_logger = logger;
		}


		public async Task<bool> AddProductService(AddProductDto dto)
		{
			try
			{
				var imagePath = SaveImageToServer(dto.Image, dto.Name);

				return await _productRepo.AddProductToDb(dto, imagePath);
			}
			catch(Exception ex)
			{
                _logger.LogError($"exception occured in AddProductService: {ex.Message}");
                return false;

            }
        }

        public async Task<bool> AddProductDetailService(AddProductDetailDto dto)
		{
			try
			{
				var product = await _productRepo.FindProductById(dto.ProductId);
				if (product != null)
				{
					return await _productRepo.AddProductDetailToDb(dto);
				}
				return false;
			}
			catch(Exception ex)
			{
                _logger.LogError($"exception occured in AddProductDetailService: {ex.Message}");
				return false;
            }
        }

        public async Task<List<ProductDto>> GetAllProducts()
        {
			try
			{
				var products = await _productRepo.GetAllProductsFromDb();
				return products;
			}
			catch(Exception ex)
			{
                _logger.LogError($"exception occured in GetAllProducts: {ex.Message}");
				return null;
            }
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
                _logger.LogError($"exception occured in SaveImageToServer: {ex.Message}");
                return "";
			}

        }


	}
}

