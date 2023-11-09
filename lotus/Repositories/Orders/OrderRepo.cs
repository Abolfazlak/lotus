using System;
using lotus.DataProvide;
using lotus.Models.Orders;
using Microsoft.EntityFrameworkCore;

namespace lotus.Repositories.Orders
{
	public class OrderRepo : IOrderRepo
	{
		private readonly ApplicationDbContext _lotusContext;
		private readonly UserDbContext _userContext;

		public OrderRepo(ApplicationDbContext lotusContext, UserDbContext userContext)
		{
			_lotusContext = lotusContext;
			_userContext = userContext;
		}

        public async Task<bool> AddProductToCartDb(AddToCartDto dto, string user)
        {
            try
            {
                var cartItem = new Cart
                {
                    ProductId = dto.ProductId,
                    Count = dto.Count,
                    UserId = user
                };

                await _lotusContext.Cart.AddAsync(cartItem);
                await _lotusContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        public async Task<List<ProductItemModel>> GetUsersCartItemsFromDb(string user)
        {
            try
            {
                var items = await (from cartItem in _lotusContext.Cart
                                   join product in _lotusContext.Products
                                   on cartItem.ProductId equals product.Id
                                   where cartItem.UserId == user
                                   select new ProductItemModel
                                   {
                                       ProductId = product.Id,
                                       ProductName = product.Name,
                                       Count = cartItem.Count,
                                       BaseFee = product.Price,
                                       Price = (cartItem.Count * long.Parse(product.Price)).ToString()
                                   }).ToListAsync();
                if (items != null)
                    return items;
                return new List<ProductItemModel>();
            }
            catch (Exception ex)
            {
                return new List<ProductItemModel>();
            }
        }


        public async Task<bool> AdditemToOrder(OrderDto dto)
        {
            try
            {
                var order = new Order
                {
                    UserId = dto.UserId,
                    Products = dto.ProductsItems,
                    TotalPrice = dto.TotalPrice,
                    IsPaid = dto.IsPaid
                };

                await _lotusContext.Orders.AddAsync(order);
                await _lotusContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public void RemoveItemsFromCart(string user)
        {
            try
            {
                var items = _lotusContext.Cart.Where(a => a.UserId == user);
                _lotusContext.Cart.RemoveRange(items);
                _lotusContext.SaveChanges();
            }
            catch(Exception ex)
            {
                     
            }
        }


        public async Task<OrderOfUserDto> GetInvoiceByIdFromDb(int id, string userId)
        {
            try
            {
                var user = await _userContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
                var order = await (from o in _lotusContext.Orders
                                   where o.Id == id
                                   select new OrderOfUserDto
                                   {
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       ProductsItems = o.Products,
                                       TotalPrice = o.TotalPrice,
                                       IsPaid = o.IsPaid
                                   }).FirstOrDefaultAsync();
                if (order != null)
                    return order;
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        public async Task<List<OrderOfUserDto>> GetListOfOrders(string userId)
        {
            try
            {
                var user = await _userContext.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
                var order = await (from o in _lotusContext.Orders
                                   select new OrderOfUserDto
                                   {
                                       FirstName = user.FirstName,
                                       LastName = user.LastName,
                                       ProductsItems = o.Products,
                                       TotalPrice = o.TotalPrice,
                                       IsPaid = o.IsPaid
                                   }).ToListAsync();
                if (order != null)
                    return order;
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



    }
}

