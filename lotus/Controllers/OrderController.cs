using System;
using JWTRefreshToken.NET6._0.Controllers;
using lotus.Models.Orders;
using lotus.Models.Products;
using lotus.Services.Orders;
using lotus.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lotus.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService orderService, ILogger<OrderController> logger)
        {
            _orderService = orderService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddProductToCart(AddToCartDto dto)
        {
            try
            {
                if (!IsAdminsRequest(false))
                {
                    _logger.LogError("user does not have a permission to add a product in cart");

                    return Unauthorized();
                }



                var user = GetUserId();
                var res = await _orderService.AddProductToCartService(dto, user);

                _logger.LogInformation($"user: {user} add product to cart");


                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in AddToCart: {ex.Message}");
                return Problem(ex.Message);
            }
        }

        [HttpPost]
        [Route("SendOrder")]
        public async Task<IActionResult> SendOrder()
        {
            try
            {
                if (!IsAdminsRequest(false))
                {
                    _logger.LogError("user does not have a permission to send order");
                    return Unauthorized();
                }

                var user = GetUserId();

                var res = await _orderService.SendOrderService(user);

                _logger.LogInformation($"user: {user} send an order");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in SendOrder: {ex.Message}");
                return Problem(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("GetInvoiceById/{id}")]
        public async Task<IActionResult> GetInvoiceById(string id)
        {
            try
            {
                if (!IsAdminsRequest(false))
                {
                    _logger.LogError("user does not have a permission to GetInvoiceById");
                    return Unauthorized();
                }

                var user = GetUserId(); 

                var res = await _orderService.GetInvoiceByIdService(int.Parse(id), user);

                _logger.LogInformation($"user: {user} get Invoice with id: {id}");


                if (res == null)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in GetInvoiceById: {ex.Message}");
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetInvoiceList")]
        public async Task<IActionResult> GetInvoiceList()
        {
            try
            {
                if (!IsAdminsRequest(false))
                {
                    _logger.LogError("user does not have a permission to GetInvoiceById");
                    return Unauthorized();
                }

                var user = GetUserId();

                var res = await _orderService.GetInvoiceList(user);

                _logger.LogInformation($"user: {user} get Invoice list");

                if (res == null)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in GetInvoiceList: {ex.Message}");
                return Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDebit")]
        public async Task<IActionResult> GetDebit()
        {
            try
            {
                if (!IsAdminsRequest(false))
                {
                    _logger.LogError("user does not have a permission to GetInvoiceById");
                    return Unauthorized();
                }

                var user = GetUserId();

                var res = await _orderService.GetDebit(user);

                _logger.LogInformation($"user: {user} get Debit History");

                return Ok(res);
            }
            catch (Exception ex)
            {
                _logger.LogError($"exception occured in GetDebit: {ex.Message}");
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


        private string GetUserId()
        {
            var claim = HttpContext.User.Claims.Where(x => x.Type == "user_id").FirstOrDefault();
            if (claim == null)
                return "";
            return claim.Value;
        }

    }
}

