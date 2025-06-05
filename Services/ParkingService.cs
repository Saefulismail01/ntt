using ParkingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem.Services
{
    public class ParkingService
    {
        private readonly List<ParkingLot> _parkingLots;

        public ParkingService(int totalSlots)
        {
            _parkingLots = Enumerable.Range(1, totalSlots)
                .Select(i => new ParkingLot(i))
                .ToList();
            Console.WriteLine($"Created a parking lot with {totalSlots} slots");
        }

        public void ParkVehicle(string registrationNumber, string color, string type)
        {
            if (type != "Mobil" && type != "Motor")
            {
                Console.WriteLine("Invalid vehicle type. Only Mobil or Motor allowed.");
                return;
            }

            var availableSlot = _parkingLots.FirstOrDefault(slot => !slot.IsOccupied);
            if (availableSlot == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            availableSlot.Vehicle = new Vehicle(registrationNumber, type, color);
            Console.WriteLine($"Allocated slot number: {availableSlot.SlotNumber}");
        }

        public void LeaveVehicle(int slotNumber)
        {
            var slot = _parkingLots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            if (slot == null || !slot.IsOccupied)
            {
                Console.WriteLine($"Slot number {slotNumber} is already free or invalid");
                return;
            }

            slot.Vehicle = null;
            Console.WriteLine($"Slot number {slotNumber} is free");
        }

        public void Status()
        {
            Console.WriteLine("| Slot | Registration No | Type | Colour |");
            Console.WriteLine("|------|-----------------|------|--------|");
            foreach (var slot in _parkingLots.Where(s => s.IsOccupied && s.Vehicle != null))
            {
                var vehicle = slot.Vehicle!;
                Console.WriteLine($"| {slot.SlotNumber} | {vehicle.RegistrationNumber} | {vehicle.Type} | {vehicle.Color} |");
            }
        }

        public void TypeOfVehicles(string type)
        {
            int count = _parkingLots.Count(s => s.IsOccupied && s.Vehicle != null && s.Vehicle.Type == type);
            Console.WriteLine(count);
        }

        public void RegistrationNumbersForVehiclesWithOddPlate()
        {
            var oddPlates = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && IsOddPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle!.RegistrationNumber);
            Console.WriteLine(string.Join(", ", oddPlates));
        }

        public void RegistrationNumbersForVehiclesWithEvenPlate()
        {
            var evenPlates = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && !IsOddPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle!.RegistrationNumber);
            Console.WriteLine(string.Join(", ", evenPlates));
        }

        public void RegistrationNumbersForVehiclesWithColour(string color)
        {
            var vehicles = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && 
                    string.Equals(s.Vehicle.Color, color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Vehicle!.RegistrationNumber);
            Console.WriteLine(string.Join(", ", vehicles));
        }

        public void SlotNumbersForVehiclesWithColour(string color)
        {
            var slots = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && 
                    string.Equals(s.Vehicle.Color, color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.SlotNumber.ToString());
            Console.WriteLine(string.Join(", ", slots));
        }

        public void SlotNumberForRegistrationNumber(string registrationNumber)
        {
            var slot = _parkingLots
                .FirstOrDefault(s => s.IsOccupied && s.Vehicle != null && 
                    s.Vehicle.RegistrationNumber == registrationNumber);
            Console.WriteLine(slot != null ? slot.SlotNumber.ToString() : "Not found");
        }

        private static bool IsOddPlate(string registrationNumber)
        {
            var numberPart = GetNumberPart(registrationNumber);
            if (int.TryParse(numberPart, out int number))
            {
                return number % 2 != 0;
            }
            return false; // Default to false if number can't be parsed
        }

        private static string GetNumberPart(string registrationNumber)
        {
            try
            {
                // Assume format is like "B-1234-XYZ" or "D-0001-HIJ"
                var parts = registrationNumber.Split('-');
                if (parts.Length >= 2)
                {
                    // Return the middle part, which should be the numeric part
                    return parts[1];
                }
            }
            catch
            {
                // Return empty string if parsing fails
            }
            return string.Empty;
        }
    }
}