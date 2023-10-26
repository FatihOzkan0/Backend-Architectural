using Core.DataAccess;
using Entities.Concrete;
using Entities.Concrete.DTO_s;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDto> GetProductsDto();
    }
}
