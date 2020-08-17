using DemoWebApi.Models;
using DemoWebApi.Models.Product;
using DemoWebApi.Services;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace DemoWebApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly ProductService _service;

        public ProductController()
        {
            // todo : DI
            _service = new ProductService();
        }
        [HttpGet]
        [Route("")]
        public async  Task<IHttpActionResult> Query([FromUri]ProductQueryRequest request)
        {
            var result = await _service.QueryAsync(request.CategoryId, request.PageNumber, request.PageSize);
            return Ok(new SuccessResponseModel<List<Products>>(result));
        }
        [HttpGet]
        [Route("{productId}")]
        public async Task<IHttpActionResult> InQuiry(int productId)
        {
            var result =await _service.InquiryAsync(productId);
            return Ok(new SuccessResponseModel<Products>(result));
        }
        [HttpPut]
        [Route("{productId}")]
        public async Task<IHttpActionResult> Update(int productId,UpdateProductRequest request)
        {
            await _service.UpdateProductAsync(productId, request.Name);
            return Ok(new SuccessResponseModel());
        }
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> Create(CreateProductRequest request)
        {
            await _service.CreateAsync(request.CategoryId,request.Name);
            return Ok(new SuccessResponseModel());
        }
        [HttpDelete]
        [Route("{productId}")]
        public async Task<IHttpActionResult> Delete(int productId)
        {
            await _service.DeleteAsync(productId);
            return Ok(new SuccessResponseModel());
        }

    }
}
