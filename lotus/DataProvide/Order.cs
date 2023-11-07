using System;
namespace lotus.DataProvide
{
	public class Order
	{
		public string? Id { get; set; }
		public string? Products { get; set; }
		public string? TotalPrice { get; set; }
		public bool IsPaid { get; set; }
		public string? UserId { get; set; }

		public virtual ApplicationUser User { get; set; }

	}
}

