using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SysManager.Application.Contracts.Products.Request;
using SysManager.Application.Helpers;
using SysManager.Application.Services;
using System;
using System.Threading.Tasks;

namespace SysManager.API.Admin.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProductsController
    { 
        private readonly ProductsService _productsService;
        public ProductsController(ProductsService service)
        {
             this._productsService = service;
        }
        [HttpPost("insert")]
        public async Task<IActionResult> Post([FromBody] ProductsPostRequest request)
        {
            var response = await _productsService.PostAsync(request);
            return Utils.Convert(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] ProductsPutRequest request)
        {
            var response = await _productsService.PutAsync(request);
            return Utils.Convert(response);
        }
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var response = await _productsService.GetByIdAsync(id);
            return Utils.Convert(response);
        }

        [HttpGet("getbyfilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] ProductsGetFilterRequest request)
        {
            var response = await _productsService.GetByFilterAsync(request);
            return Utils.Convert(response);
        }

        [HttpDelete("id/{id}")]
        public async Task<IActionResult> DeleteById([FromRoute] Guid id)
        {
            var response = await _productsService.DeleteByIdAsync(id);
            return Utils.Convert(response);
        }

    }
}