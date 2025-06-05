using ParkingSystem.Services;
using System;

namespace ParkingSystem
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== PARKING SYSTEM ===");
            Console.WriteLine();

            ParkingService? parkingService = null;

            while (true)
            {
                var input = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(input)) continue;

                var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var command = parts[0].ToLower();

                try
                {
                    switch (command)
                    {
                        case "create_parking_lot":
                            if (parts.Length == 2 && int.TryParse(parts[1], out int slots))
                            {
                                parkingService = new ParkingService(slots);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: create_parking_lot <number_of_slots>");
                            }
                            break;

                        case "park":
                            if (parts.Length == 4 && parkingService != null)
                            {
                                parkingService.ParkVehicle(parts[1], parts[2], parts[3]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: park <registration_number> <color> <type>");
                            }
                            break;

                        case "leave":
                            if (parts.Length == 2 && int.TryParse(parts[1], out int slotNumber) && parkingService != null)
                            {
                                parkingService.LeaveVehicle(slotNumber);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: leave <slot_number>");
                            }
                            break;

                        case "status":
                            if (parkingService != null)
                            {
                                parkingService.Status();
                            }
                            else
                            {
                                Console.WriteLine("Parking lot not initialized");
                            }
                            break;

                        case "type_of_vehicles":
                            if (parts.Length == 2 && parkingService != null)
                            {
                                parkingService.TypeOfVehicles(parts[1]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: type_of_vehicles <type>");
                            }
                            break;

                        case "registration_numbers_for_vehicles_with_odd_plate":
                        case "registration_numbers_for_vehicles_with_ood_plate": // Handle typo
                            if (parkingService != null)
                            {
                                parkingService.RegistrationNumbersForVehiclesWithOddPlate();
                            }
                            else
                            {
                                Console.WriteLine("Parking lot not initialized");
                            }
                            break;

                        case "registration_numbers_for_vehicles_with_event_plate":
                            if (parkingService != null)
                            {
                                parkingService.RegistrationNumbersForVehiclesWithEvenPlate();
                            }
                            else
                            {
                                Console.WriteLine("Parking lot not initialized");
                            }
                            break;

                        case "registration_numbers_for_vehicles_with_colour":
                            if (parts.Length == 2 && parkingService != null)
                            {
                                parkingService.RegistrationNumbersForVehiclesWithColour(parts[1]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: registration_numbers_for_vehicles_with_colour <color>");
                            }
                            break;

                        case "slot_numbers_for_vehicles_with_colour":
                            if (parts.Length == 2 && parkingService != null)
                            {
                                parkingService.SlotNumbersForVehiclesWithColour(parts[1]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: slot_numbers_for_vehicles_with_colour <color>");
                            }
                            break;

                        case "slot_number_for_registration_number":
                            if (parts.Length == 2 && parkingService != null)
                            {
                                parkingService.SlotNumberForRegistrationNumber(parts[1]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid command. Usage: slot_number_for_registration_number <registration_number>");
                            }
                            break;

                        case "exit":
                            Console.WriteLine("Thank you for using Parking System!");
                            return;

                        default:
                            Console.WriteLine("Unknown command");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}