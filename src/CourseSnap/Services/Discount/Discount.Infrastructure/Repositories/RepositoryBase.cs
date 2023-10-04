using Discount.Application.Contracts;
using Discount.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IBaseRepo<T> where T : class
    {
        protected DiscountContext _context;
        public RepositoryBase(DiscountContext context)
        {
            _context = context; 
        }
        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
