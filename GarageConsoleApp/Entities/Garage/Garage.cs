using System.Collections;

namespace GarageConsoleApp.Entities.Garage;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T[] _vehicles;

    public Garage(int garageSize)
    {
        _vehicles = new T[garageSize];
    }

    public bool Add(T vehicle)
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] == null) // Find the first empty spot
            {
                _vehicles[i] = vehicle;
                return true;
            }
        }

        return false; // Garage is full
    }


    public T Remove(uint index)
    {
        if (index >= _vehicles.Length || _vehicles[index] == null)
        {
            return null; // Invalid index or no vehicle at the specified index
        }

        T removedVehicle = _vehicles[index];
        _vehicles[index] = null; // Mark the spot as empty
        return removedVehicle;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            yield return _vehicles[i]; // Include null values
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}