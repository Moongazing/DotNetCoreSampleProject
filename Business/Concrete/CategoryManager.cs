using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class CategoryManager : ICategoryService
  {
    ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
      _categoryDal = categoryDal;
    }

    [ValidationAspect(typeof(CategoryValidator))]
    public IResult Add(Category category)
    {
      _categoryDal.Add(category);
      return new SuccessDataResult<Category>(Messages.CategoryAdded);
    }

    public IDataResult<List<Category>> GetAll()
    {
      return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoriesListed);
    }

    public IResult GetById(int categoryId)
    {
      return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId));
    }

  
  }
}
