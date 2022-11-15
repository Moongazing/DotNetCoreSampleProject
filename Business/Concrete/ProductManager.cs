using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.log4net.Loggers;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using Entites.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class ProductManager : IProductService
  {

    IProductDal _productDal;
    ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
      _productDal = productDal;
      _categoryService = categoryService;
    }
    [SecuredOperation("product.add,admin")]
    [LogAspect(typeof(FileLogger))]
    [ValidationAspect(typeof(ProductValidator))]
    public IResult Add(Product product)
    {
      IResult result = BusinessRules.Run(
                        CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                        CheckIfProductNameExists(product.ProductName),
                        CheckIfCategoryLimitExceded());
      if (result != null)
      {
        return result;
      }
      _productDal.Add(product);
      return new SuccessResult(Messages.ProductAdded);
    }
    [CacheAspect]
    public IDataResult<List<Product>> GetAll()
    {
      if (DateTime.Now.Hour == 23)
      {
        return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

      }
      //Business Codes Here
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
    }
    [CacheAspect]
    public IDataResult<List<Product>> GetAllByCategory(int id)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
    }
    [CacheAspect]
    [PerformanceAspect(5)]
    public IDataResult<Product> GetById(int productId)
    {
      return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }
    public IDataResult<List<Product>> GetByUnitsInStock(short min, short max)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitsInStock >= min && p.UnitsInStock <= max));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
      if (DateTime.Now.Hour >= 13)
      {
        return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
      }
      return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }
    //Claim
    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]
    [CacheRemoveAspect("IProductService.Get")]
    public IResult Update(Product product)
    {
      IResult result = BusinessRules.Run(
                       CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                       CheckIfProductNameExists(product.ProductName),
                       CheckIfCategoryLimitExceded());
      if (result != null)
      {
        return result;
      }
      _productDal.Update(product);
        return new SuccessResult(Messages.ProductUpdated);
      

    }

    private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
    {
      var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
      if (result >= 10)
      {
        return new ErrorResult(Messages.ProductCountOfCategoryError);
      }
      return new SuccessResult();
    }
    /*Rules*/
    private IResult CheckIfProductNameExists(string productName)
    {
      var result = _productDal.GetAll(p => p.ProductName == productName).Count;
      if (result > 0)
      {
        return new ErrorResult(Messages.ProductNameAlreadyExists);
      }
      return new SuccessResult();
    }
    private IResult CheckIfCategoryLimitExceded()
    {
      var result = _categoryService.GetAll();
      if (result.Data.Count > 15)
      {
        return new ErrorResult(Messages.CheckIfCategoryLimitExceded);

      }
      return new SuccessResult();
    }
    [TransactionScopeAspect]
    public IResult AddTransactionalTest(Product product)
    {
      _productDal.Update(product);
      _productDal.Add(product);
      return new SuccessResult(Messages.ProductUpdated);
    }
  }
}
