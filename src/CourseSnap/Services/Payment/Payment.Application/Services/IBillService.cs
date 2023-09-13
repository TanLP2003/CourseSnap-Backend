using Payment.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Services
{
    public interface IBillService
    {
        Task<IEnumerable<BillModel>> GetByUserId(Guid userId);
        Task<BillModel> GetByBillId(string billId);
        Task<bool> Delete(string billId);
    }
}
