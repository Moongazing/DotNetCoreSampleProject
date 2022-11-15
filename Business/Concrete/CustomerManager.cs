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
  internal class CustomerManager : ICustomerService
  {
    ICustomerDal _customerDal;
    public CustomerManager(ICustomerDal customerDal)
    {
      _customerDal = customerDal;
    }

    [ValidationAspect(typeof(CustomerValidator))]
    public IResult Add(Customer customer)
    {
      _customerDal.Add(customer);
      return new SuccessResult(Messages.CustomerAdded);
    }

    public IDataResult<List<Customer>> GetAll()
    {
      return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomersListed);
    }
    /*Business Rules*/
  }
}
