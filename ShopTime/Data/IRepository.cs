using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JasonSoft.ShopTime.Domain;

namespace JasonSoft.ShopTime.Data
{
    public partial interface IRepository<T>
    {
        T GetById(object id);
        Task<IResult> InsertAsync(T entity);
        Task<IResult> UpdateAsync(T entity);
        Task<IResult> UpdateAsync(IList<T> entity);
        Task<IResult> DeleteAsync(T entity);
        IQueryable<T> Table { get; }
    }
}
