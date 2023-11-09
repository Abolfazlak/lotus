﻿using System;
using lotus.DataProvide;
using lotus.Models.Orders;
using lotus.Repositories.Orders;
using Newtonsoft.Json;

namespace lotus.Services.Orders
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepo _orderRepo;
		public OrderService(IOrderRepo orderRepo)
		{
			_orderRepo = orderRepo;
		}

        public async Task<bool> AddProductToCartService(AddToCartDto dto, string user)
		{
			var IsItemAddedToCart = await _orderRepo.AddProductToCartDb(dto, user);
			return IsItemAddedToCart;
		}

        public async Task<bool> SendOrderService(string user)
		{
			var item = await GetUsersCartItemsService(user);
			var isAdded = await _orderRepo.AdditemToOrder(item);
			_orderRepo.RemoveItemsFromCart(user);


            return isAdded;
		}

        public async Task<OrderDto> GetUsersCartItemsService(string user)
		{
			try
			{
				var userCartItems = await _orderRepo.GetUsersCartItemsFromDb(user);
				long totalPrice = 0;
				foreach (var i in userCartItems)
				{
					totalPrice += long.Parse(i.Price);
				}
				var serializedItems = JsonConvert.SerializeObject(userCartItems).ToString();
				var OrderItem = new OrderDto
				{
					ProductsItems = serializedItems,
					TotalPrice = totalPrice.ToString(),
					IsPaid = false,
					UserId = user
				};

				if(OrderItem != null)
					return OrderItem;

                return null;
            }
			catch(Exception ex)
			{
				return null;
			}
		}

		public async Task<InvoiceDto> GetInvoiceByIdService(int id, string user)
		{
			var orderDetail = await _orderRepo.GetInvoiceByIdFromDb(id, user);

			if (orderDetail == null)
				return null;

			var invoice = new InvoiceDto
			{
				FirstName = orderDetail.FirstName,
				LastName = orderDetail.LastName,
				ProductListInInvoice = JsonConvert.DeserializeObject<List<ProductItemModel>>(orderDetail.ProductsItems),
				TotalPrice = orderDetail.TotalPrice,
				PayState = orderDetail.IsPaid ? "paid" : "not paid"

			};

			return invoice;
		}

        public async Task<List<InvoiceDto>> GetInvoiceList(string user)
		{
            var orderList = await _orderRepo.GetListOfOrders(user);

            if (orderList == null || orderList.Count == 0)
                return null;

            var invoice = (from order in orderList select new InvoiceDto
            {
                FirstName = order.FirstName,
                LastName = order.LastName,
                ProductListInInvoice = JsonConvert.DeserializeObject<List<ProductItemModel>>(order.ProductsItems),
                TotalPrice = order.TotalPrice,
                PayState = order.IsPaid ? "paid" : "not paid"

            });

            return invoice.ToList();
        }

        public async Task<string> GetDebit(string user)
		{
			try
			{
				var orderList = await _orderRepo.GetListOfOrders(user);
				long debit = 0;

				foreach (var order in orderList)
				{
					debit += order.IsPaid ? 0 : long.Parse(order.TotalPrice);
				}

				return debit.ToString();
			}
			catch(Exception ex)
			{
				return "";
			}
        }




    }
}

