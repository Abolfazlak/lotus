using System;
namespace lotus.DataProvide
{
	public class Cart
	{
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public string? UserId { get; set; }
        public virtual Product Product { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}

