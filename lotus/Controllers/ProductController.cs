using System;
using lotus.Models.Products;
using lotus.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lotus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
		{
            _productService = productService;
            _logger = logger;
		}

        [HttpPost]
        [Authorize]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            try
            {
                if (!IsAdminsRequest(true))
                {
                    _logger.LogError("user does not have a permission to add a product");

                    return Unauthorized();
                }

                var res = await _productService.AddProductService(dto);

                _logger.LogInformation($"admin add product");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in AddProduct: {ex.Message}");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize]
        [Route("AddProductDetail")]
        public async Task<IActionResult> AddProductDetail(AddProductDetailDto dto)
        {
            try
            {
                if (!IsAdminsRequest(true))
                {
                    _logger.LogError("user does not have a permission to add a product detail");

                    return Unauthorized();
                }

                var res = await _productService.AddProductDetailService(dto);

                _logger.LogInformation($"admin add product detail for product: {dto.ProductId}");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in AddProductDetail: {ex.Message}");

                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsDetails()
        {
            try
            {
                var res = await _productService.GetAllProducts();

                _logger.LogInformation($"user get product list");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in GetAllProducts: {ex.Message}");

                return Problem(ex.Message);
            }
        }



        private bool IsAdminsRequest(bool IsAdmin)
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "user_role");
            if (claim == null)
                return false;
            return claim.Value == IsAdmin.ToString();
        }

    }
}

