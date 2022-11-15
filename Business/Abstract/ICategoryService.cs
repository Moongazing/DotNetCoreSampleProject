using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface ICategoryService
  {
    IDataResult<List<Category>> GetAll();
    IResult GetById(int categoryId);

    IResult Add(Category category);
  }
}
