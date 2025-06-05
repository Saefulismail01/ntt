namespace ParkingSystem.Models;

public class ParkingLot(int slotNumber)
{
    public int SlotNumber { get; } = slotNumber;
    public Vehicle? Vehicle { get; set; }
    public bool IsOccupied => Vehicle != null;
}