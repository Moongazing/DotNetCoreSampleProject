using Entites.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
  public class OrderValidator:AbstractValidator<Order>
  {
    public OrderValidator()
    {
      /*Rules Here*/
      RuleFor(o => o.OrderDate).NotEmpty();
      RuleFor(o => o.ShipCity).NotEmpty();
    }
  }
}
