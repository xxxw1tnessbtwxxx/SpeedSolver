namespace SpeedSolverDatabase.Repo.abc;

public interface IRepository<T> where T : class
{
    public void Insert(T entity);
    public List<T> FindAll();
    public T FindById(int id);
    
}