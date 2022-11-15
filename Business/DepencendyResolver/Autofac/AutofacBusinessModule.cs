using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entites.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Business.DepencendyResolver.Autofac
{
  public class AutofacBusinessModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
      builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

      builder.RegisterType<OrderManager>().As<IOrderService>();
      builder.RegisterType<EfOrderDal>().As<IOrderDal>();

      builder.RegisterType<CategoryManager>().As<ICategoryService>();
      builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

      builder.RegisterType<UserManager>().As<IUserService>();
      builder.RegisterType<EfUserDal>().As<IUserDal>();

      builder.RegisterType<AuthManager>().As<IAuthService>();
      builder.RegisterType<JwtHelper>().As<ITokenHelper>();

      //builder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>();



      var assembly = System.Reflection.Assembly.GetExecutingAssembly();

      builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
          .EnableInterfaceInterceptors(new ProxyGenerationOptions()
          {
            Selector = new AspectInterceptorSelector()
          }).SingleInstance();


    }
  }
}


