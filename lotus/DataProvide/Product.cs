﻿using System;
namespace lotus.DataProvide
{
	public partial class Product
	{
     
        public int Id { get; set; }
		public string? Name { get; set; }
		public string? Price { get; set; }
		public string? PhotoUrl { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<Cart> CartItems { get; set; }


    }
}

