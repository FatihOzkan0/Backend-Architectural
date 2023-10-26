using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Concrete.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepository<Product, Context>, IProductDal
    {
        public List<ProductDto> GetProductsDto()
        {
            using(Context context = new Context())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDto
                             { ProductId = p.ProductId, ProductName = p.ProductName, CategoryName = c.CategoryName, UnitsStock = p.UnitsInStock };

                return result.ToList();
            }
        }
    }
}
