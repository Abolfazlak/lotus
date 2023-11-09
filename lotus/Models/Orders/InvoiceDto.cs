using System;
namespace lotus.Models.Orders
{
	public class InvoiceDto
	{
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public List<ProductItemModel> ProductListInInvoice { get; set; }
		public string? TotalPrice { get; set; }
		public string? PayState { get; set; }
    }
}

