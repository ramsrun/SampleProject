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
    public class ProductCostHistoryService
    {
        private readonly AeriContext _aeriContext;
        private readonly IMapper _mapper;

        public ProductCostHistoryService(AeriContext ctx, IMapper mapper, IServiceProvider serviceProvider)
        {
            _aeriContext = ctx;
            _mapper = mapper;

        }
        public async Task<List<ProductCostHistoryDTO>> GetProductCostHistory(int id)
        {
            return await _aeriContext.Products.Where(x => x.ProductID == id).ProjectTo<ProductCostHistoryDTO>(_mapper.ConfigurationProvider)
                        .AsNoTracking().ToListAsync();
        }
    }
}
