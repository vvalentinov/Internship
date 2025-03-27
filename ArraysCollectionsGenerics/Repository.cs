namespace ArraysCollectionsGenerics;

public class Repository<T> : IRepository<T>
    where T : class, IEntity
{
    private readonly List<T> _data = [];

    public void Add(T item)
    {
        _data.Add(item);
    }

    public bool Delete(T item) => _data.Remove(item);

    public T? GetById(int id) => _data.FirstOrDefault(x => x.Id == id);

    public T? Update(T item)
    {
        var index = _data.FindIndex(x => x.Id == item.Id);

        if (index >= 0)
        {
            _data[index] = item;
            return _data[index];
        }

        return null;
    }

    public IEnumerable<T> GetAll() => _data;
}
