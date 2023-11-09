using System;
using lotus.Models.Orders;

namespace lotus.Services.Orders
{
    public interface IOrderService
    {
        public Task<bool> AddProductToCartService(AddToCartDto dto, string user);
        public Task<bool> SendOrderService(string user);
        public Task<OrderDto> GetUsersCartItemsService(string user);
        public Task<InvoiceDto> GetInvoiceByIdService(int id, string user);
        public Task<List<InvoiceDto>> GetInvoiceList(string user);
        public Task<string> GetDebit(string user);
    }
}

