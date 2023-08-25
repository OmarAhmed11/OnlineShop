using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecificationsParameters PSP) 
            : base(x =>
            (string.IsNullOrEmpty(PSP.Search) || x.Name.ToLower().Contains(PSP.Search)) &&
            (!PSP.BrandId.HasValue || x.ProductBrandId == PSP.BrandId) &&
            (!PSP.TypeId.HasValue || x.ProductTypeId == PSP.TypeId))
        {

        }
    }
}
