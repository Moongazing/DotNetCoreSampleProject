using Core.Entities.Concrete;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
  public static class Messages
  {
    /*Product*/
    public static string ProductAdded = "Product added.";
    public static string InvalidProductName = "Invalid product name.";
    public static string MaintenanceTime = "System in maintenance.";
    public static string ProductListed = "Product listed.";

    /*Category*/
    public static string CategoriesListed = "CategoriesListed";
    public static string CategoryAdded = "Category Added.";
    public static string ProductCountOfCategoryError = "One category has max 1 product";
    public static string ProductUpdated = "Product Updated.";
    public static string ProductNameAlreadyExists = "Product name already exists.";
    public static string CheckIfCategoryLimitExceded = "Category limit exceded.";
    public static string CustomerAdded = "";
    public static string CustomersListed;
    public static string AuthorizationDenied="";
    public static string UserRegistered;
    public static string UserNotFound;
    public static string PasswordError;
    public static string SuccessfulLogin;
    public static string UserAlreadyExists;
    public static string AccessTokenCreated;
  }
}
