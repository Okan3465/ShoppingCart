using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService1;
        public ProductController(IProductService productService)
        {
            productService1 = productService;
        }
        [HttpGet]
        public IActionResult GetAllProductsList()
        {
          var values=  productService1.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddProductToCart(Product product)
        {
            productService1.TAdd(product);

            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult GetProduct(int id)
        {
            var product = productService1.TGetByID(id);

            if (product==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteProductFromCart(int id)
        {
           var product= productService1.TGetByID(id);
            if (product==null)
            {
                return NotFound();
            }
            else
            {
                productService1.TDelete(product);
                return Ok();
            }
           
        }

        [HttpPut]

        public IActionResult UpdateProduct(Product product)
        {
            var value = productService1.TGetByID(product.ProductId);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                value.ImageUrl = product.ImageUrl;
                value.Name = product.Name;
                value.Price = product.Price;
                value.Quantity = product.Quantity;
                value.Status = product.Status;
                value.Description = product.Description;
                productService1.TUpdate(value);
                return Ok();
            }
        }
    }
}
