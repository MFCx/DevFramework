﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Core.Aspects.ValidationAspect;
using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using DevFramework.Northwind.Business.Abstract;
using DevFramework.Northwind.Business.ValidationRules.FluentValidation;
using DevFramework.Northwind.DataAccess.Abstract;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.Business.Concrete.Manager
{
  public  class ProductManager:IProductService
  {
      private IProductDal _productDal;

      public ProductManager(IProductDal productDal)
      {
          _productDal = productDal;
      }

      public List<Product> GetAll()
      {
          return _productDal.GetAll();
      }
         
        public Product Get(int id)
        {
            return _productDal.Get(P => P.ProductID == id);
        }
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Add(Product product)
        {
            //ValidatorTool.Validate(new ProductValidator(), product);
            return _productDal.Add(product);
        }
        //Bu aspecti nasıl bir validator ile validate etmesini istiyorum.
        //Yani:ProductValidator Product ı valide ediyor.
        //bende dicemki ProdactValidator'a parametre olarak senin validate etmen gereken(product)
        //bulduğun zaman onu benim yerime validete et...
        [FluentValidationAspect(typeof(ProductValidator))]
        public Product Update(Product product)
        {
            //ValidatorTool.Validate(new ProductValidator(), product);
            return _productDal.Update(product);
        }
  }
}
