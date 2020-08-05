using AeriSample.Data;
using AeriSample.Service.Model.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeriSample.Service
{
    public class ProductService
    {
        private readonly AeriContext _aeriContext;
        private readonly IMapper _mapper;

        public ProductService(AeriContext ctx, IMapper mapper, IServiceProvider serviceProvider)
        {
            _aeriContext = ctx;
            _mapper = mapper;

        }
        public async Task<List<ProductDTO>> GetProducts()
        {
            return await _aeriContext.Products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking().ToListAsync();
        }
        public async Task<ProductDTO> GetProduct(int id)
        {
            return await _aeriContext.Products.Where(x => x.ProductID == id).ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking().FirstOrDefaultAsync();
        }
    }
}
