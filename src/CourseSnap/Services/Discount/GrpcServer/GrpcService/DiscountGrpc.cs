using Discount.Application.Contracts;
using Grpc.Core;
using GrpcServer.Protos;

namespace GrpcServer.GrpcService
{
    public class DiscountGrpc : GrpcDiscountService.GrpcDiscountServiceBase
    {
        private readonly IRepoManager _repo;
        private readonly ILogger<DiscountGrpc> _logger;

        public DiscountGrpc(IRepoManager repo, ILogger<DiscountGrpc> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public override async Task<DiscountResponse> DiscountRequest(DiscountModel request, ServerCallContext context)
        {
            _logger.LogInformation("--> Start Grpc Call");
            int result = 0;
            var coupon = await _repo.Coupon.GetByNameAndCode(request.CourseName, request.Code);
            if (coupon != null && (DateTime.Today < coupon.ExpiredAt.Date))
            {
                _logger.LogInformation("Get coupon ...");
                result += coupon.Quantity;
            }

            var categorySale = await _repo.CategorySale.GetByCategory(request.Category);
            if (categorySale != null && (DateTime.Today < categorySale.ExpiredAt.Date))
            {
                _logger.LogInformation("Get CategorySale");
                result += categorySale.Quantity;
            }

            var response = new DiscountResponse
            {
                Quantity = result
            };
            _logger.LogInformation("--> Grpc Call Finished");
            return response;
        }
    }
}
