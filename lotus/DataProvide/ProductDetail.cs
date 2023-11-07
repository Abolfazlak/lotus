using System;
namespace lotus.DataProvide
{
	public partial class ProductDetail
	{
        
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public virtual Product Product { get; set; }


    }
}

