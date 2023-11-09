using System;
using lotus.Models.Orders;

namespace lotus.Repositories.Orders
{
	public interface IOrderRepo
	{
        public Task<bool> AdditemToOrder(OrderDto item);
        public Task<bool> AddProductToCartDb(AddToCartDto dto, string user);
        public Task<OrderOfUserDto> GetInvoiceByIdFromDb(int id, string user);
        public Task<List<OrderOfUserDto>> GetListOfOrders(string user);
        public Task<List<ProductItemModel>> GetUsersCartItemsFromDb(string user);
        public void RemoveItemsFromCart(string user);
    }
}

