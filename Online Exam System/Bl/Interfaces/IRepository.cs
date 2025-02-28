using System.Linq.Expressions;

namespace Online_Exam_System.Bl.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(int id,T entity);
        Task<bool> DeleteAsync(int id);
    }
}
