using MongoDB.Bson.Serialization.IdGenerators;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Contracts
{
    public interface IBillRepo
    {
        Task<IEnumerable<Bill>> GetByUserId(Guid userId);
        Task<Bill> GetByBillId(string billId);
        Task Add(Bill bill);
        Task<bool> Delete(string billId);
    }
}
