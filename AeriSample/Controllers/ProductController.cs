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
    public class ProductController : ControllerBase
    {
        ProductService productService;
        public ProductController(ProductService _productService)
        {
            productService = _productService;
        }
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetProducts()
        {
            return await productService.GetProducts();
        }


        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            return await productService.GetProduct(id);
        }

    }
}
