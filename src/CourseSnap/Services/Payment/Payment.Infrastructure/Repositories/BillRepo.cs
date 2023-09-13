using MongoDB.Driver;
using Payment.Application.Contracts;
using Payment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class BillRepo : IBillRepo
    {
        private readonly IBillContext _context;
        public BillRepo(IBillContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetByUserId(Guid userId) 
            => await _context.Bills.Find(b => b.UserId == userId).ToListAsync();

        public async Task<Bill> GetByBillId(string billId) 
            => await _context.Bills.Find(b => b.BillId == billId).FirstOrDefaultAsync();

        public async Task Add(Bill bill) => await _context.Bills.InsertOneAsync(bill);

        public async Task<bool> Delete(string billId)
        {
            var result = await _context.Bills.DeleteOneAsync(b => b.BillId == billId);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
    }
}