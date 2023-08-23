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
        public ProductsWithTypesAndBrandsSpecification(string sort,int? brandId, int? typeId)
            :base(x=> 
            (!brandId.HasValue ||x.ProductBrandId == brandId) && 
            (!typeId.HasValue || x.ProductTypeId == typeId))
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            if(!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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
