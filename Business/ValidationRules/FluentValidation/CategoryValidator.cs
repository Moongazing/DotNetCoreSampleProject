using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class CategoryValidator:AbstractValidator<Category>
  {
    public CategoryValidator()
    {
      /*Rules Here*/

      /*Not Empty*/
      RuleFor(c => c.CategoryName).NotEmpty();

      /*Length*/
      RuleFor(c => c.CategoryName).MinimumLength(3);
    }
  }
}
