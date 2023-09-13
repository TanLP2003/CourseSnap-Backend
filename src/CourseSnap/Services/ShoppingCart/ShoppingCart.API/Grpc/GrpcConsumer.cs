using GrpcServer.Protos;

namespace ShoppingCart.API.Grpc
{
    public class GrpcConsumer
    {
        private readonly GrpcDiscountService.GrpcDiscountServiceClient _client;

        public GrpcConsumer(GrpcDiscountService.GrpcDiscountServiceClient client)
        {
            _client = client;
        }

        public async Task<int> GetDiscount(string courseName, string code, string category)
        {
            var discountRequest = new DiscountModel
            {
                CourseName = courseName,
                Code = code,
                Category = category
            };
            var discountResponse = await _client.DiscountRequestAsync(discountRequest);
            return discountResponse.Quantity;
        }
    }
}
