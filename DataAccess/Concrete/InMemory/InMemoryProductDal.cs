using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
  public class InMemoryProductDal : IProductDal
  {
    List<Product> _products;
    public InMemoryProductDal()
    {
      _products = new List<Product>
      {
        new Product
        {
          ProductId = 1,
          CategoryId = 1,
          ProductName = "Laptop",
          UnitPrice = 8000,
          UnitsInStock = 10
        },
        new Product
        {
          ProductId = 2,
          CategoryId = 1,
          ProductName = "Phone",
          UnitPrice = 6000,
          UnitsInStock = 12
        },
        new Product
        {
          ProductId = 3,
          CategoryId = 1,
          ProductName = "Keyboard",
          UnitPrice = 500,
          UnitsInStock = 100
        },
        new Product
        {
          ProductId = 4,
          CategoryId = 2,
          ProductName = "Mouse",
          UnitPrice = 60,
          UnitsInStock = 20
        }
      };
    }
    public void Add(Product product)
    {
      _products.Add(product);
    }

    public void Delete(Product product)
    {

      Product productToDelete = null;

      productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

      _products.Remove(productToDelete);
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
      return _products;
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
      throw new NotImplementedException();
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
      return _products.Where(p => p.CategoryId == categoryId).ToList();
    }

    public List<ProductDetailDto> GetProductDetails()
    {
      throw new NotImplementedException();
    }

    public void Update(Product product)
    {
      Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
      productToUpdate.ProductName = product.ProductName;
      productToUpdate.UnitPrice = product.UnitPrice;
      productToUpdate.CategoryId = product.CategoryId;
      productToUpdate.UnitsInStock = product.UnitsInStock;


    }
  }
}
