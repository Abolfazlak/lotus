using System;
using lotus.DataProvide;
using lotus.Models.Products;
using lotus.Models.UserManagement;
using Microsoft.EntityFrameworkCore;

namespace lotus.Repositories.Products
{ 
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationDbContext _lotusContext;

        public ProductRepo(ApplicationDbContext lotusContext)
        {
            _lotusContext = lotusContext;
        }

        public async Task<bool> AddProductToDb(AddProductDto dto, string path)
        {
            try
            {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                PhotoUrl = path,
            };

            await _lotusContext.Products.AddAsync(product);
                await _lotusContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                }
        }


        public async Task<bool> AddProductDetailToDb(AddProductDetailDto dto)
        { 
            try
            {
                var detail = new ProductDetail
                {
                    Name = dto.Name,
                    ProductId = dto.ProductId
                };

                await _lotusContext.ProductDetails.AddAsync(detail);
                await _lotusContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<Product> FindProductById(int Id)
        {
            try
            {
                var product = await _lotusContext.Products.Where(p => p.Id == Id).FirstOrDefaultAsync();
                if (product != null)
                    return product;
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<ProductDto>> GetAllProductsFromDb()
        {
            try
            {
                var users = await ( from product in _lotusContext.Products
                                    select new ProductDto
                                    {
                                        Id = product.Id,
                                        Name = product.Name,
                                        Price = product.Price,
                                        ImagePath = product.PhotoUrl,
                                        ProductDetailsList = ( from detail in _lotusContext.ProductDetails
                                                                where detail.ProductId == product.Id
                                                                select new ProductDetailDto
                                                                {
                                                                    Id = detail.Id,
                                                                    Name = detail.Name
                                                                }).ToList()
                                    }).ToListAsync();
                if (users != null)
                {
                    return users;
                }
                return new List<ProductDto>();

            }
            catch (Exception ex)
            {
                return new List<ProductDto>();
            }


        }


    }
}

