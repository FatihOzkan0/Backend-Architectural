using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Update(Product product);
        IResult Delete(Product product);    
        IDataResult<List<Product>>  GetAll();
        IDataResult<List<Product>>   GetAllCategoryId(int id);
        IDataResult<List<ProductDto>> GetProductsDetails();
        IDataResult<Product> GetById (int productİd);



    }
}
