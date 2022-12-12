namespace exam_modul_4.Model;

public class Aplications
{
    public int Id { get; set; }
    public int RoomId { get; set; } 
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }   
    public int CompanyId { get; set; }  
    public bool IsAllowed { get; set; }
    public Aplications(int id, int roomId, DateTime startTime, DateTime endTime, int companyId, bool isAllowed)
    {
        Id = id;
        RoomId = roomId;
        StartTime = startTime;
        EndTime = endTime;
        CompanyId = companyId;
        IsAllowed = isAllowed;
    }

    public override string ToString()
    {
        return $"id -> {Id}  roomId -> {RoomId} start Time -> {StartTime} end time -> {EndTime}";
    }
}
