namespace ParkingSystem.Models;

public class Vehicle(string registrationNumber, string type, string color)
{
    public string RegistrationNumber { get; } = registrationNumber;
    public string Type { get; } = type;
    public string Color { get; } = color;
}