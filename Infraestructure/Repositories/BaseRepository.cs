using Microsoft.EntityFrameworkCore;
using StudentsManagement.Business.Interfaces;

namespace StudentsManagement.Infraestructure.Repositories
{
  public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
  {
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public List<T> GetAll()
    {
      return _dbSet.ToList();
    }

    public T? GetById(Guid id)
    {
      return _dbSet.Find(id);
    }

    public T Create(T entity)
    {
      _dbSet.Add(entity);
      _context.SaveChanges();
      return entity;
    }

    public void Update(T entity)
    {
      _dbSet.Update(entity);
      _context.SaveChanges();
    }

    public void Delete(T entity)
    {
      _dbSet.Remove(entity);
      _context.SaveChanges();
    }
  }
}
