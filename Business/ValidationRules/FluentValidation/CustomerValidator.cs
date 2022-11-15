using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class CustomerValidator : AbstractValidator<Customer>
  {
    public CustomerValidator()
    {
      /*Rules Here*/

      /*NotEmpty*/
      RuleFor(c => c.ContactName).NotEmpty();
      RuleFor(c => c.CompanyName).NotEmpty();
      RuleFor(c => c.City).NotEmpty();

      /*Min Length*/
      RuleFor(c => c.ContactName).MinimumLength(2);
      RuleFor(c => c.CompanyName).MinimumLength(2);
      RuleFor(c => c.City).MaximumLength(3).MaximumLength(30);
    }
  }
}
