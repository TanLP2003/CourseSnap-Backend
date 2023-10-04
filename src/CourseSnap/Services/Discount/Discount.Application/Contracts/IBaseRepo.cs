using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Contracts
{
    public interface IBaseRepo<T>
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
