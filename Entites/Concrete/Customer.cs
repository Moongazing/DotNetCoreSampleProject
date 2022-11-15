using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entites.Concrete
{
  public class Customer:IEntity
  {
    public string CustomerId { get; set; } //Because of string in db
    public string ContactName { get; set; }
    public string CompanyName { get; set; }
    public string City { get; set; }
  }
}
