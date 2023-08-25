using OnlineShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecificationsParameters PSP)
            :base(x=> 
            (string.IsNullOrEmpty(PSP.Search) || x.Name.ToLower().Contains(PSP.Search)) &&

            (!PSP.BrandId.HasValue ||x.ProductBrandId == PSP.BrandId) && 
            (!PSP.TypeId.HasValue || x.ProductTypeId == PSP.TypeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            ApplyPaging(PSP.PageSize * (PSP.PageIndex - 1), PSP.PageSize);

            if (!string.IsNullOrEmpty(PSP.sort))
            {
                switch (PSP.sort)
                {
                    case "IdAsc": AddOrderby(p => p.Id);
                        break;
                    case "IdDesc": AddOrderbyDescending(p => p.Id);
                        break;
                    case "NameAsc": AddOrderby(p => p.Name);
                        break;
                    case "NameDesc": AddOrderbyDescending(p => p.Name);
                        break;
                    case "PriceAsc": AddOrderby(p => p.Price);
                        break;
                    case "PriceDesc": AddOrderbyDescending(p => p.Price);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) 
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}
