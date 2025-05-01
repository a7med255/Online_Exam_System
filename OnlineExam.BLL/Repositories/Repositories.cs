using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Online_Exam_System.Bl.Interfaces;

namespace Online_Exam_System.Bl.Repositories
{
    public class Repositories<T> : IRepository<T> where T : class
    {
        private readonly ExamContext _context;
        private readonly DbSet<T> _dbSet;

        public Repositories(ExamContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                var item = await _dbSet.ToListAsync();
                return item;
            }
            catch
            {

                return new List<T>();
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var item = await _dbSet.FindAsync(id);
                return item;
            }
            catch
            {
                return default;

            }
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> UpdateAsync(int id, T entity)
        {
            try
            {
                if (id != 0)
                {
                    _dbSet.Update(entity).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
