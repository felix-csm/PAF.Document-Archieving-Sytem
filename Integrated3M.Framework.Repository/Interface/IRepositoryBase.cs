using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Integrated3M.Framework.Repository.Interface
{
    interface IRepositoryBase<T>
    {

        void Update(T item);

        void Add(T item);

        void Delete(T item);

        IList<T> Search(Expression<Func<T, bool>> predicate);


    }
}
