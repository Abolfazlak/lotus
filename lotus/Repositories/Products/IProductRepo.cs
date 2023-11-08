using System;
using lotus.DataProvide;
using lotus.Models.Products;

namespace lotus.Repositories.Products
{
    public interface IProductRepo
    {
        public Task<bool> AddProductToDb(AddProductDto dto, string path);
        public Task<bool> AddProductDetailToDb(AddProductDetailDto dto);
        public Task<List<ProductDto>> GetAllProductsFromDb();
        public Task<Product> FindProductById(int Id);
    }
}

