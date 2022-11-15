using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class ProductValidator : AbstractValidator<Product>
  {
    public ProductValidator()
    {
      /*Not Empty*/
      RuleFor(p => p.ProductName).NotEmpty();
      RuleFor(p => p.UnitsInStock).NotEmpty();
      RuleFor(p => p.UnitPrice).NotEmpty();
      RuleFor(P => P.CategoryId).NotEmpty();



      /*Min Length*/
      RuleFor(p => p.ProductName).MinimumLength(2);

      /*Greater Than*/
      RuleFor(p => p.UnitPrice).GreaterThan(0);

      RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

      RuleFor(p => p.ProductName).Must(StartWithA).When(p => p.CategoryId == 2);

    }
    private bool StartWithA(string arg)
    {
      return arg.StartsWith("A");
      
    }
  }
}
