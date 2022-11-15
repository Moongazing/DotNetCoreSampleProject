using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IOrderService
  {
    IDataResult <List<Order>> GetAll();
    IResult GetById(int orderId);

  }
}
