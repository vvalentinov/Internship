namespace CSharp_DotNetBasics.Enumerable;

using System.Collections;

public class VehicleCollection : IEnumerable<Vehicle>
{
    public VehicleCollection(Vehicle[] vehicles)
    {
        Vehicles = vehicles;
    }

    public Vehicle[] Vehicles { get; }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerator<Vehicle> GetEnumerator() => new WordsEnumerator(Vehicles);
}

public class WordsEnumerator : IEnumerator<Vehicle>
{
    private const int InitialPosition = -1;
    private int _currentPosition = InitialPosition;
    private readonly Vehicle[] _vehicles;

    public WordsEnumerator(Vehicle[] vehicles)
    {
        _vehicles = vehicles;
    }

    object IEnumerator.Current => Current;

    public Vehicle Current
    {
        get
        {
            try
            {
                return _vehicles[_currentPosition];
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException($"{nameof(VehicleCollection)}'s end reached.", ex);
            }
        }
    }

    public bool MoveNext()
    {
        ++_currentPosition;
        return _currentPosition < _vehicles.Length;
    }

    public void Reset()
    {
        _currentPosition = InitialPosition;
    }

    public void Dispose()
    {
    }
}
