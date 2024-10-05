using System.Collections;

namespace GarageConsoleApp.Entities.Garage;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private T?[] _vehicles;

    public Garage(uint garageSize)
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

    public T? RemoveByRegNumber(string regNr)
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i]?.RegistrationNumber == regNr)
            {
                T removedVehicle = _vehicles[i];
                _vehicles[i] = null;
                return removedVehicle;
            }
        }

        return null;
    }

    public bool HasEmptySpots()
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] == null)
                return true;
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < _vehicles.Length; i++)
        {
            if (_vehicles[i] != null)
            {
                yield return _vehicles[i]; // Exclude null values
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}