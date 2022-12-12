using exam_modul_4.Model;

namespace exam_modul_4.Service;

public interface IService
{
    Task RegistrationAsync();
    Task<Extensions.Extensions.Role> LoginAsync();
    Task SendAplicationAsync();
    Task AddRoomAsync();

    Task PrintAllAplications();

    Task PrintRoomsByDate(DateTime time);
    Task PrintAllRoomsAsync();
}
