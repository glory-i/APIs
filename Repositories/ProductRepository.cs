using System;
using ProductsApi.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.Data;
namespace ProductsApi.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataContext _context; //ask why you need to make it readonly

        public ProductRepository(IDataContext context)
        {
            _context = context;
        }
        public async Task<Product> Get(int id)
        {
            return await _context.Products.FindAsync(id);


            //again we a returning a single product from the products list property in our context finish
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            //we are adding the product parameter entered(which is of type Product) to the Products property(which is a list, see
            //the datacontext interface which has a list of products property. We add to that products list

        }
        public async Task Delete(int id)
        {
            //now to delete by id we use 3 steps...
            //1. retrieve the Product by its id from our context's products list and store in a variable
            //2. we we remove the product from the list of Products in our context's Products list(if product is found)
            //3. we save changes
            //ALWAYS USE AWAIT WITH ASYNC 

            var ProductToDelete = await _context.Products.FindAsync(id);
            if (ProductToDelete == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Products.Remove(ProductToDelete);
                await _context.SaveChangesAsync();
            }

        }
        public async Task Update(Product product)
        {
            //now for updating it is in 2 steps: we will firstly take in the product to update and search for it using id
            // then we will assign the new values of that product to be updated to be the value of the new product instance 

            var ProductToUpdate = await _context.Products.FindAsync(product.ProductId);
            if (ProductToUpdate == null)
            {
                throw new NullReferenceException();

            }
            else
            {
                ProductToUpdate.Price = product.Price;
                ProductToUpdate.Name = product.Name;
                await _context.SaveChangesAsync();
            }

        }
    }
}
