using exam_modul_4.Broker;
using exam_modul_4.Model;
using static exam_modul_4.Extensions.Extensions;

namespace exam_modul_4.Service;

public class Service : IService
{
    private IDatabaseBroker broker;
    private int myId;
    public Service()
    {
        broker = new DatabaseBroker();
    }

    public async Task AddRoomAsync()
    {
        
        Console.Write("Room number : ");
        int room_number = int.Parse(Console.ReadLine()!);
        Console.Write("Count of seats : ");
        int count_seates = int.Parse(Console.ReadLine()!);
        int id = await broker.GetLastRoomIdAsync();
        Room room = new Room(id, room_number, count_seates);
        await broker.InsertRoomAsync(room);
    }

    public async Task<Extensions.Extensions.Role> LoginAsync()
    {
        Console.Write("Username : ");
        string username = Console.ReadLine()!;
        Console.WriteLine("Password : ");
        string password = Console.ReadLine()!;
        var data = await broker.GetAllUsersAsync();

        foreach (var item in data)
        {
            if(item.Username == username && item.Password == password)
            {
                return item.role;
            }
        }
        return Extensions.Extensions.Role.no_one;
    }

    public async Task PrintAllAplications()
    {
        var aplications = await broker.GetAllAplicationAsync();
        foreach (var item in aplications)
        {
            Console.WriteLine(item);
        }
    }

    public async Task PrintAllRoomsAsync()
    {
        var data = await broker.GetAllRoomsAsync();
        int k = 0;
        foreach (var item in data)
        {
            Console.WriteLine(k + ". " + item);
        }
    }

    public async Task PrintRoomsByDate(DateTime time)
    {
        var data = await broker.GetRoomsByDateAsync(time);
        int k = 0;
        foreach (var item in data)
        {
            Console.WriteLine(k + ". " + item);
        }
    }

    public async Task RegistrationAsync()
    {
        Console.Write("Fullname : ");
        string fullname = Console.ReadLine()!;
        Console.Write("Username : ");
        string username = Console.ReadLine()!;
        Console.Write("role :(0 - user, 1 - company, 2 - admin) : ");
        int role = int.Parse(Console.ReadLine()!);
        Console.Write("Password: ");
        string password = Console.ReadLine()!;
        string company = "";
        if(role == 1)
        {
            Console.Write("Company name :");
            company = Console.ReadLine()!;
        }
        
        int id = await broker.GetLastUserIdAsync();
        User user1 = new User();
        if (role == 0 || role == 2)
        {
            User user = new User(id, fullname, username, password, (Role)role);
            user1 = user;
        }
        else if(role == 1)
        {
            User user = new User(id, fullname, username, password, (Role)role,company);
            user1 = user;
        }
        await broker.InsertUserAsync(user1);

    }

    public async Task SendAplicationAsync()
    {

    }


}
