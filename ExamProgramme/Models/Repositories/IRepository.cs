using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ExamProgramme.Models.Repositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
		IQueryable<T> GetWhere(Expression<Func<T, bool>> method); // will return List of values by specific condition
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method); // will return 1 value by specific condition
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> model);
        bool Remove(T model);
        bool RemoveRange(List<T> model);
        Task<bool> RemoveAsync(int id);
        bool Update(T model);
        Task<int> SaveAsync();
    }
}
