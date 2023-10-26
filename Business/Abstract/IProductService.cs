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
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);    
        List<Product> GetAll();
        List<Product> GetAllCategoryId(int id);
        List<ProductDto> GetProductsDetails();
        Product GetById (int productİd);



    }
}
