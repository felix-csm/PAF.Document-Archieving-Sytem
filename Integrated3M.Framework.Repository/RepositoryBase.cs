using Integrated3M.Framework.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace Integrated3M.Framework.Repository
{
    public partial class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DbContext _dbContext;
        private DbSet<T> _dbSet;
        public RepositoryBase(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }
        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Delete(T item)
        {
            throw new NotImplementedException();
        }

        public IList<T> Search(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
