using System;
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

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("AddToCart")]
        public async Task<IActionResult> AddProductToCart(AddToCartDto dto)
        {
            try
            {
                if (!IsAdminsRequest(false))
                    return Unauthorized();

                var user = GetUserId();
                var res = await _orderService.AddProductToCartService(dto, user);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("SendOrder")]
        public async Task<IActionResult> SendOrder()
        {
            try
            {
                if (!IsAdminsRequest(false))
                    return Unauthorized();

                var user = GetUserId();

                var res = await _orderService.SendOrderService(user);

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet]
        [Route("GetInvoiceById/{id}")]
        public async Task<IActionResult> GetInvoiceById(string id)
        {
            try
            {
                if (!IsAdminsRequest(false))
                    return Unauthorized();

                var user = GetUserId(); 

                var res = await _orderService.GetInvoiceByIdService(int.Parse(id), user);

                if (res == null)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetInvoiceList")]
        public async Task<IActionResult> GetInvoiceList()
        {
            try
            {
                if (!IsAdminsRequest(false))
                    return Unauthorized();

                var user = GetUserId();

                var res = await _orderService.GetInvoiceList(user);

                if (res == null)
                    return NotFound();

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDebit")]
        public async Task<IActionResult> GetDebit()
        {
            try
            {
                if (!IsAdminsRequest(false))
                    return Unauthorized();

                var user = GetUserId();

                var res = await _orderService.GetDebit(user);

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


        private string GetUserId()
        {
            var claim = HttpContext.User.Claims.Where(x => x.Type == "user_id").FirstOrDefault();
            if (claim == null)
                return "";
            return claim.Value;
        }

    }
}

