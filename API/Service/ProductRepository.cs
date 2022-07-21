using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;

using API.Dtos;
using API.Entities;
using API.Helper;
using API.Interface;
using AutoMapper;
using E_Commerce_App_Practices_1.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace API.Service
{
    public class ProductRepository :IProductRepository
    {
        private readonly StoreContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(StoreContext storeContext, IMapper mapper)
        {

            _context = storeContext;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
           return await _context.ProductBrands.ToListAsync();
        }

        public async Task<ProductToReturnDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Product
                    .Include( b => b.ProductBrand)
                    .Include( t => t.ProductType)
                    .FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<ProductToReturnDto>(product);
        }

        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync (ProductSpecParams param)
        {
            var products =  _context.Product
                    .Include(b => b.ProductBrand)
                    .Include(t => t.ProductType).AsQueryable();
            
           
            if(param.Sort == "sortAsc"){
                products = products.OrderBy(p => p.Price);
            }
            else if(param.Sort == "sortDesc"){
                products = products.OrderByDescending(p => p.Price);
            }
            else {
                products = products.OrderBy(x => x.Name);
            }

            if(param.BrandId != null) products = products.Where(x => x.ProductBrand.Id == param.BrandId);
            if(param.TypeId != null) products = products.Where(x => x.ProductType.Id == param.TypeId);

            if(param.Search != null) products = products.Where(x => x.Name.Contains(param.Search));
            var _res = await products
                .Skip((param.PageIndex-1) * param.PageSize)
                .Take(param.PageSize)
                .ToListAsync();
            
            var total = await products.CountAsync();

            var result = new Pagination<ProductToReturnDto>()
            {
                Data = _mapper.Map<List<ProductToReturnDto>>(_res),
                PageIndex = param.PageIndex,
                PageSize = (param.PageSize > total) ? total : param.PageSize,
                Count = total
            };
                    
            return result;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<int> TotallCount()
        {
            return await _context.Product.CountAsync();
        }
    }
}