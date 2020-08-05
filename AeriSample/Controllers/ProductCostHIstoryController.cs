using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeriSample.Service;
using AeriSample.Service.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeriSample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCostHistoryController : ControllerBase
    {
        ProductCostHistoryService productCostHistoryService;
        public ProductCostHistoryController(ProductCostHistoryService _productCostHistoryService)
        {
            productCostHistoryService = _productCostHistoryService;
        }
        // GET: api/Product/5
        [HttpGet]
        public async Task<ActionResult<List<ProductCostHistoryDTO>>> GetProductCostHistory(int id)
        {
            return await productCostHistoryService.GetProductCostHistory(id);
        }

    }
}