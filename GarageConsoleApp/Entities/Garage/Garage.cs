using System.Collections;

namespace GarageConsoleApp.Entities.Garage;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T[] _vehicles;
    private int currentIndex = 0;

    public Garage(int garageSize)
    {
        _vehicles = new T[garageSize];
    }

    public bool Add(T vehicle)
    {
        if (currentIndex < _vehicles.Length)
        {
            _vehicles[currentIndex] = vehicle;
            currentIndex++;
            return true;
        }

        return false;
    }

    public T[] GetAll()
    {
        // Make sure we send back a copy of the _vehicles so the reference doesn't get passed around
        // and keeping it isolated to the instance only.
        T[] vehiclesCopy = new T[currentIndex];
        Array.Copy(_vehicles, vehiclesCopy, currentIndex);
        return vehiclesCopy;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < currentIndex; i++)
        {
            yield return _vehicles[i]; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}