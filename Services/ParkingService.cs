// Services/ParkingService.cs
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
            // Validasi jenis kendaraan
            if (type != "Mobil" && type != "Motor")
            {
                Console.WriteLine("Invalid vehicle type. Only Mobil or Motor allowed.");
                return;
            }

            // Cek apakah kendaraan sudah terparkir
            var existingVehicle = _parkingLots.FirstOrDefault(s => s.IsOccupied && 
                s.Vehicle?.RegistrationNumber == registrationNumber);
            if (existingVehicle != null)
            {
                Console.WriteLine($"Vehicle {registrationNumber} is already parked in slot {existingVehicle.SlotNumber}");
                return;
            }

            // Cari slot yang tersedia
            var availableSlot = _parkingLots.FirstOrDefault(slot => !slot.IsOccupied);
            if (availableSlot == null)
            {
                Console.WriteLine("Sorry, parking lot is full");
                return;
            }

            // Park kendaraan
            availableSlot.Vehicle = new Vehicle(registrationNumber, type, color);
            Console.WriteLine($"Allocated slot number: {availableSlot.SlotNumber}");
        }

        public void LeaveVehicle(int slotNumber)
        {
            var slot = _parkingLots.FirstOrDefault(s => s.SlotNumber == slotNumber);
            if (slot == null)
            {
                Console.WriteLine($"Invalid slot number: {slotNumber}");
                return;
            }

            if (!slot.IsOccupied)
            {
                Console.WriteLine($"Slot number {slotNumber} is already free");
                return;
            }

            var vehicle = slot.Vehicle!;
            slot.Vehicle = null;
            Console.WriteLine($"Vehicle {vehicle.RegistrationNumber} has left the parking lot");
            Console.WriteLine($"Slot number {slotNumber} is free");
        }

        public void Status()
        {
            var occupiedSlots = _parkingLots.Where(s => s.IsOccupied && s.Vehicle != null).ToList();
            
            if (occupiedSlots.Count == 0)
            {
                Console.WriteLine("Parking lot is empty");
                return;
            }

            Console.WriteLine("Slot \tRegistration No\tType\tColour");
            foreach (var slot in occupiedSlots.OrderBy(s => s.SlotNumber))
            {
                var vehicle = slot.Vehicle!;
                Console.WriteLine($"{slot.SlotNumber}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Color}");
            }
        }

        public void TypeOfVehicles(string type)
        {
            int count = _parkingLots.Count(s => s.IsOccupied && s.Vehicle != null && 
                string.Equals(s.Vehicle.Type, type, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(count);
        }

        public void RegistrationNumbersForVehiclesWithOddPlate()
        {
            var oddPlates = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && IsOddPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle!.RegistrationNumber)
                .OrderBy(x => x);
            
            if (oddPlates.Any())
                Console.WriteLine(string.Join(", ", oddPlates));
            else
                Console.WriteLine("No vehicles with odd plate numbers found");
        }

        public void RegistrationNumbersForVehiclesWithEvenPlate()
        {
            var evenPlates = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && IsEvenPlate(s.Vehicle.RegistrationNumber))
                .Select(s => s.Vehicle!.RegistrationNumber)
                .OrderBy(x => x);
            
            if (evenPlates.Any())
                Console.WriteLine(string.Join(", ", evenPlates));
            else
                Console.WriteLine("No vehicles with even plate numbers found");
        }

        public void RegistrationNumbersForVehiclesWithColour(string color)
        {
            var vehicles = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && 
                    string.Equals(s.Vehicle.Color, color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.Vehicle!.RegistrationNumber)
                .OrderBy(x => x);
            
            if (vehicles.Any())
                Console.WriteLine(string.Join(", ", vehicles));
            else
                Console.WriteLine($"No vehicles with color {color} found");
        }

        public void SlotNumbersForVehiclesWithColour(string color)
        {
            var slots = _parkingLots
                .Where(s => s.IsOccupied && s.Vehicle != null && 
                    string.Equals(s.Vehicle.Color, color, StringComparison.OrdinalIgnoreCase))
                .Select(s => s.SlotNumber)
                .OrderBy(x => x);
            
            if (slots.Any())
                Console.WriteLine(string.Join(", ", slots));
            else
                Console.WriteLine($"No vehicles with color {color} found");
        }

        public void SlotNumberForRegistrationNumber(string registrationNumber)
        {
            var slot = _parkingLots
                .FirstOrDefault(s => s.IsOccupied && s.Vehicle != null && 
                    string.Equals(s.Vehicle.RegistrationNumber, registrationNumber, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(slot != null ? slot.SlotNumber.ToString() : "Not found");
        }

        public void ShowAvailableSlots()
        {
            var availableCount = _parkingLots.Count(s => !s.IsOccupied);
            var occupiedCount = _parkingLots.Count(s => s.IsOccupied);
            
            Console.WriteLine($"Total slots: {_parkingLots.Count}");
            Console.WriteLine($"Occupied slots: {occupiedCount}");
            Console.WriteLine($"Available slots: {availableCount}");
        }

        private static bool IsOddPlate(string registrationNumber)
        {
            var numberPart = GetNumberPart(registrationNumber);
            if (int.TryParse(numberPart, out int number))
            {
                return number % 2 != 0;
            }
            return false;
        }

        private static bool IsEvenPlate(string registrationNumber)
        {
            var numberPart = GetNumberPart(registrationNumber);
            if (int.TryParse(numberPart, out int number))
            {
                return number % 2 == 0;
            }
            return false;
        }

        private static string GetNumberPart(string registrationNumber)
        {
            var parts = registrationNumber.Split('-');
            if (parts.Length >= 2)
            {
                return parts[1];
            }
            return string.Empty;
        }
    }
}