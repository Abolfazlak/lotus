using System;
using lotus.Models.Products;
using lotus.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lotus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
            _productService = productService;
		}

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddProduct(AddProductDto dto)
        {
            try
            {
                if (!IsAdminsRequest(true))
                    return Unauthorized();

                var res = await _productService.AddProductService(dto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddProductDetail")]
        public async Task<IActionResult> AddProductDetail(AddProductDetailDto dto)
        {
            try
            {
                if (!IsAdminsRequest(true))
                    return Unauthorized();

                var res = await _productService.AddProductDetailService(dto);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProductsDetails()
        {
            try
            {
                if (!IsAdminsRequest(true))
                    return Unauthorized();

                var res = await _productService.GetAllProducts();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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

