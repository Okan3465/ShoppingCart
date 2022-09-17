using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.UnitTest
{
    public class ProductServiceFake : IProductService
    {
        private readonly List<Product> _shoppingCart;

        public ProductServiceFake()
        {
            _shoppingCart = new List<Product>()
            {
                new Product() { ProductId = 100,
                    Name = "Apple", Price = 15000,Description="iPhone 11",Quantity=50,ImageUrl="",Status=""  },

                 new Product() { ProductId = 101,
                    Name = "Samsung", Price = 12000,Description="S20",Quantity=40,ImageUrl="",Status=""  },

                  new Product() { ProductId = 102,
                    Name = "Xiaomi", Price = 16000,Description=" Redmi Note10 Pro",Quantity=30,ImageUrl="",Status=""  },

            };
        }

        public void TAdd(Product t)
        {
                   
            _shoppingCart.Add(t);
          
        }

        public void TDelete(Product t)
        {
            var existing = _shoppingCart.First(a => a.ProductId == t.ProductId);
            _shoppingCart.Remove(existing);
        }

        public void TUpdate(Product product)
        {
           var value = _shoppingCart.FirstOrDefault(i => i.ProductId == product.ProductId);
            value.ProductId = product.ProductId;
            value.ImageUrl = product.ImageUrl;
            value.Name = product.Name;
            value.Price = product.Price;
            value.Quantity = product.Quantity;
            value.Status = product.Status;
            value.Description = product.Description;
            _shoppingCart.Add(value);
           
        }

        public List<Product> TGetList()
        {
            return _shoppingCart;
        }

        public Product TGetByID(int id)
        {
            return _shoppingCart.Where(a => a.ProductId == id)
               .FirstOrDefault();
        }
    }
}

