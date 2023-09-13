using Discount.Domain.Contracts;
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
                result += coupon.Quantity;
            }

            var specialSale = await _repo.SpecSale.GetByCategory(request.Category);
            if (specialSale != null && (DateTime.Today < specialSale.ExpiredAt.Date))
            {
                result += specialSale.Quantity;
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
