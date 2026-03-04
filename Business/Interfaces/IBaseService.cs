namespace StudentsManagement.Business.Interfaces
{
  public interface IBaseService<T> where T : class
  {
    List<T> GetAll();
    T GetById(Guid id);
    T Create(T entity);
    void Delete(Guid id);
  }
}
