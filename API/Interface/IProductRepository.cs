using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Helper;
using E_Commerce_App_Practices_1.Data.Base;

namespace API.Interface
{
    public interface IProductRepository
    {
        Task<ProductToReturnDto> GetProductByIdAsync(int id);

        Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductSpecParams param);

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypesAsync();
        
    }
}