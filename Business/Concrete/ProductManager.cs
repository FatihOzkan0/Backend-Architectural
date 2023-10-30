using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
           IResult result = BusinessRules.Run(CategorySınır(product), ProductDontRepat(product));
           if(result != null) //result boş değilse içnde hatalı iş kodu varsa döndür.
            {
                return result;
            }

           _productDal.Add(product);
            return new SuccessResult(Message.ProducAdded);




            // ValidationContext.Validate(new ProductValidator(),product);       Validate işlemini bu şekilde çağırmak yerine AOP attribute kullanarak yapıcam.

            
           /*if (CategorySınır(product).Success)                      iş kodlarını yukarıda yazdığımız iş kodları ile çağırıyoruz bunun yerine.
            //{
            //    if(ProductDontRepat(product).Success)
            //    {
            //        _productDal.Add(product);
            //        return new SuccessResult(Message.ProducAdded);
            //    }
                
            }*/

            return new ErrorResult();
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Message.MaintenanceTime);
            }

           return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Message.ProductsListed);   //DataResult newledik türümüz List product döndürüyor sonra gelenler data,success,message
        }

        public IDataResult<List<Product>> GetAllCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<Product> GetById(int productİd)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productİd));
        }

        public IDataResult<List<ProductDto>> GetProductsDetails()
        {
            return new SuccessDataResult<List<ProductDto>>(_productDal.GetProductsDto());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult();
        }

                                                      //İŞ KURALI

        private IResult CategorySınır(Product product)
        {
            var result = _productDal.GetAll(p=>p.CategoryId==product.CategoryId).Count;
            if (result > 10)
            {
                return new ErrorResult(Message.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult ProductDontRepat(Product product)
        {
            var result = _productDal.GetAll(p => p.ProductName == product.ProductName).Any();
            if(result==true)
            {
                return new ErrorResult(Message.ProductNameRepeatError);
            }

            return new SuccessResult();

        }

        
    }
}
