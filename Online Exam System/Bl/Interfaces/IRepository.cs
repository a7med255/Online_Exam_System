using System.Linq.Expressions;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetSingleAsync(Expression<Func<T, bool>> filter);

        Task<T> AddAsync(T Entity);

        Task RemoveAsync(Expression<Func<T, bool>> filter);
    }
}
