using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.Entities;

namespace API.Data.Base.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(){
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }
    }
}