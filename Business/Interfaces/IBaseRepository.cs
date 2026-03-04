namespace StudentsManagement.Business.Interfaces
{
  public interface IBaseRepository<T> where T : class
  {
    List<T> GetAll();
    T? GetById(Guid id);
    T Create(T entity);
    void Update(T entity);
    void Delete(T entity);
  }
}
