using exam_modul_4.Model;
namespace exam_modul_4.Broker;

public partial interface IDatabaseBroker
{
    /// <summary>
    /// insert user 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task InsertUserAsync(User user);
    //Task DeleteUserAsync(User user);
    /// <summary>
    /// insert room
    /// </summary>
    /// <param name="room"></param>
    /// <returns></returns>
    Task InsertRoomAsync(Room room);  
    //Task DeleteRoomAsync(int id);
    //Task UpdateRoomAsync(Room room);
    /// <summary>
    /// insert Aplication
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    Task InsertApplicationAsync(Aplications application);
    //Task DeleteApplicationAsync(Applications application);
    Task<int> GetLastUserIdAsync();
    Task<int> GetLastRoomIdAsync();
    Task<int> GetLastAplicationIdAsync();

    Task<List<User>> GetAllUsersAsync();
    Task<List<Aplications>> GetAllAplicationAsync();
    Task<List<Room>> GetAllRoomsAsync();
    Task<List<Room>> GetRoomsByDateAsync(DateTime time);
}
