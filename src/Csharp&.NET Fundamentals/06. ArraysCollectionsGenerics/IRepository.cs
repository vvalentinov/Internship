namespace ArraysCollectionsGenerics;

public interface IRepository<T> where T : IEntity
{
    T? GetById(int id);

    void Add(T item);

    bool Delete(T item);

    T? Update(T item);

    IEnumerable<T> GetAll();
}
