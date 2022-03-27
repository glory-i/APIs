using Microsoft.AspNetCore.Mvc;
using ProductsApi.Repositories;
using System.Threading.Tasks;
using ProductsApi.Models;
using ProductsApi.DTOS;
using System.Collections.Generic;
using System;
namespace ProductsApi.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        //my head is hot sha butttttt
        //you create your _productrepositiory instance which is inheriting from product repositroy where we defined our functions
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //now we get the product, and return the result finish
            var producttoget = await _productRepository.Get(id);


            if (producttoget == null)
            {
                return NotFound();
            }
            return Ok(producttoget);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            var productslist = await _productRepository.GetAll();
            return Ok(productslist);

        }

        //we cannot pass the entire Product like that, we will pass as DTO. so let us create a DTO(Data transfer object)
        //class and continue to work magic

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(CreateProductDto createProductDto)
        {
            //we create an instance of the product class but we use the values of the createproduct dto 
            Product my_product = new Product();
            my_product.Name = createProductDto.Name;
            my_product.Price = createProductDto.Price;
            my_product.DateCreated = DateTime.Now;

            //then we use our product repository function to add product
            await _productRepository.Add(my_product);
            return Ok(my_product);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
            return Ok();


        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, UpdateProductDto updateproductdto)
        {
            //same energy with the httppost
            //no date created cause we are not creating it now, it already existed
            Product my_product = new Product();
            my_product.Name = updateproductdto.Name;
            my_product.Price = updateproductdto.Price;

            my_product.ProductId = id;




            await _productRepository.Update(my_product);
            return Ok();
        }

    }
}