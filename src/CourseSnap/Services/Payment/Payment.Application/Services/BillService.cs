using Amazon.Runtime.Internal.Auth;
using AutoMapper;
using Payment.Application.Contracts;
using Payment.Application.Models;
using Payment.Domain.Entities;
using Payment.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace Payment.Application.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepo _repo;
        private readonly IMapper _mapper;

        public BillService(IBillRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillModel>> GetByUserName(string userName)
        {
            var billList = await _repo.GetByUserName(userName);
            return _mapper.Map<IEnumerable<BillModel>>(billList);
        }

        public async Task<BillModel> GetByBillId(string billId)
        {
            var bill = await _repo.GetByBillId(billId);
            return _mapper.Map<BillModel>(bill);
        }

        public async Task<bool> Delete(string billId)
        {
            var bill = await _repo.GetByBillId(billId);
            if (bill == null) throw new NotFoundException($"Bill with id : {billId} does not exist");
            var result = await _repo.Delete(billId);
            return result;
        }
    }
}