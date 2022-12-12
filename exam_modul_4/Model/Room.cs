
namespace exam_modul_4.Model;

public class Room
{
    public int Id { get; set; }
    public int RoomNumber { get; set; } 
    public int CountSeats { get; set; }
    public Room(int id, int roomNumber, int countSeats)
    {
        Id = id;
        RoomNumber = roomNumber;
        CountSeats = countSeats;
    }

    public override string ToString()
    {
        return $"room number -> {RoomNumber}  seats count -> {CountSeats}";
    }
}
