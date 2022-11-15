using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class OrderManager : IOrderService
  {
    IOrderDal _orderDal;

    public OrderManager(IOrderDal orderDal)
    {
      _orderDal = orderDal;
    }

    public IDataResult<List<Order>> GetAll()
    {
      return new SuccessDataResult<List<Order>>(_orderDal.GetAll(), Messages.ProductListed);
    }

    public IResult GetById(int orderId)
    {
      return new SuccessDataResult<List<Order>>(_orderDal.GetAll(o => o.OrderId == orderId));
    }
  }
}
