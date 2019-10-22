using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OnlineStore.Business.Contracts;
using OnlineStore.GrpcService.Protos;

namespace OnlineStore.GrpcService.Services
{
    public class ProducService: ProducController.ProducControllerBase
    {
        private readonly IProductService _productService;
        public ProducService(IProductService productService)
        {
            _productService = productService;
        }

        public override Task<ProductResponse> GetAll(Empty request, ServerCallContext context)
        {
            ProductResponse productReply = new ProductResponse();
            var model = _productService.GetAll();
            foreach (var item in model)
            {
                ProductDTO productEnttiy = new ProductDTO()
                {
                    Id = item.Id,
                    CategoryId = item.CategoryId,
                    Details = item.Details,
                    Name = item.Name,
                    Price = Convert.ToDouble(item.Price),
                    StockQuantity = item.StockQuantity
                };
                productReply.Products.Add(productEnttiy);
            }

            return Task.FromResult(productReply);
        }
    }
}
