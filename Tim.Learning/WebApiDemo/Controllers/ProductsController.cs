using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[]
       {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
       };

        /// <summary>
        /// 直接返回Product类型
        /// </summary>
        /// <returns></returns>
        [ActionName("AllProducts")]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }


        /// <summary>
        /// 直接返回Product类型，请求参数也是Request
        /// </summary>
        /// <returns></returns>
        [Route("api/product/request_dto")]
        public IEnumerable<Product> GetAllProducts(ProductRequestDto request)
        {
            return products;
        }

        /// <summary>
        /// IHttpActionResult
        /// Essentially, it defines an HttpResponseMessage factory
        /// 本质是定义了HttpResponseMessage的工厂
        /// 语义清晰、便于单元测试、便于写公共逻辑
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        /// <summary>
        /// HttpResponseMessage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage Product(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);


            var response= Request.CreateResponse(HttpStatusCode.OK, product);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }


        /// <summary>
        /// Content Negotitate
        /// 内容协商机制（怎么选择序列化方式） 
        /// https://docs.microsoft.com/en-us/aspnet/web-api/overview/formats-and-model-binding/content-negotiation
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/product/content_negotitate")]
        public HttpResponseMessage GetProductWithContentNegotitate(int id)
        {
            var product = new Product()
            { Id = id, Name = "Gizmo", Category = "Widgets", Price = 1.99M };

            IContentNegotiator negotiator = this.Configuration.Services.GetContentNegotiator();

            ContentNegotiationResult result = negotiator.Negotiate(
                typeof(Product), this.Request, this.Configuration.Formatters);
            if (result == null)
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
                throw new HttpResponseException(response);
            }

            return new HttpResponseMessage()
            {
                Content = new ObjectContent<Product>(
                    product,                // What we are serializing 
                    result.Formatter,           // The media formatter
                    result.MediaType.MediaType  // The MIME type
                )
            };
        }
    }
}
