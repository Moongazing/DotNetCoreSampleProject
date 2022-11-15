
using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IProductService
  {
    IDataResult<List<Product>> GetAll();
    IDataResult<List<Product>> GetAllByCategory(int id);
    IDataResult<Product> GetById(int productId);
    IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
    IDataResult<List<Product>> GetByUnitsInStock(short min, short max);
    IDataResult<List<ProductDetailDto>> GetProductDetails();
    IResult Add(Product product);
    IResult Update(Product product);
    IResult AddTransactionalTest(Product product);


  }
}
