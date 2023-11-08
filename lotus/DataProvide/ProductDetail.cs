using System;
namespace lotus.DataProvide
{
	public partial class ProductDetail
	{
        
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public virtual Product Product { get; set; }


    }
}

