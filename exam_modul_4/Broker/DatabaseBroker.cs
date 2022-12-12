using exam_modul_4.Model;
using System.Data;
using System.Data.SqlClient;
using static exam_modul_4.Extensions.Extensions;

namespace exam_modul_4.Broker;

public partial class DatabaseBroker : IDatabaseBroker
{
    #region inserting data
    public async Task InsertApplicationAsync(Aplications application)
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.InsertUser;
       
        await connection.OpenAsync();

        await command.ExecuteReaderAsync();
    }

    public async Task InsertRoomAsync(Room room)
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.InsertRoom;
        command.Parameters.Add(new SqlParameter("@id", room.Id));
        command.Parameters.Add(new SqlParameter("@room_number", room.RoomNumber));
        command.Parameters.Add(new SqlParameter("@count_seats", room.CountSeats));


        await connection.OpenAsync();

        try
        {
            await command.ExecuteReaderAsync();
        }
        catch
        {
            Console.WriteLine("Cant insert room");
            throw;
        }

    }

    public async Task InsertUserAsync(User user)
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.InsertUser;
        command.Parameters.Add(new SqlParameter("@id", user.Id));
        command.Parameters.Add(new SqlParameter("@role", user.role));
        command.Parameters.Add(new SqlParameter("@fullname", user.FullName));
        command.Parameters.Add(new SqlParameter("@username", user.Username));
        command.Parameters.Add(new SqlParameter("@password", user.Password));
        command.Parameters.Add(new SqlParameter("@company_name", user.CompanyName));


        await connection.OpenAsync();

        try
        {
            await command.ExecuteReaderAsync();
        }
        catch
        {
            Console.WriteLine("Cant insert user");
            throw;
        }

    }

    #endregion

    #region get last id
    public async Task<int> GetLastUserIdAsync()
    {
        int id_ = -1;
        using var connection = GetConnection();

        string query = "select top 1 id from Usersss order by id desc";
        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        SqlDataReader dataReader = await command.ExecuteReaderAsync();

        while (await dataReader.ReadAsync())
        {
            id_ = int.Parse(dataReader["id"].ToString()!);
        }


        return ++id_;
    }
    public async Task<int> GetLastRoomIdAsync()
    {
        int id_ = -1;
        using var connection = GetConnection();

        string query = "select top 1 id from Room order by id desc";
        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        SqlDataReader dataReader = await command.ExecuteReaderAsync();

        while (await dataReader.ReadAsync())
        {
            id_ = int.Parse(dataReader["id"].ToString()!);
        }


        return ++id_;
    }
    public async Task<int> GetLastAplicationIdAsync()
    {
        int id_ = -1;
        using var connection = GetConnection();

        string query = "select top 1 id from Aplication order by id desc";
        SqlCommand command = new SqlCommand(query, connection);

        await connection.OpenAsync();
        SqlDataReader dataReader = await command.ExecuteReaderAsync();

        while (await dataReader.ReadAsync())
        {
            id_ = int.Parse(dataReader["id"].ToString()!);
        }


        return ++id_;
    }

    #endregion

    public async Task<List<User>> GetAllUsersAsync()
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.GetAllUsers;
        

        await connection.OpenAsync();

        using var dataReader = await command.ExecuteReaderAsync();
        List<User> users = new List<User>();
        while(await dataReader.ReadAsync())
        {
            int role1 = int.Parse(dataReader["role"].ToString()!);
            User user = new User(
                id: int.Parse(dataReader["id"].ToString()!),
                fullName: dataReader["fullname"].ToString()!,
                username: dataReader["username"].ToString()!,
                password: dataReader["password"].ToString()!,
                role: (Role)role1,
                companyName: dataReader["company_name"].ToString()!
                ) ;
            users.Add(user);
        }
        return users;
    }

    public async Task<List<Aplications>> GetAllAplicationAsync()
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.GetAllAplications;


        await connection.OpenAsync();

        using var dataReader = await command.ExecuteReaderAsync();
        var aplications = new List<Aplications>();
        while (await dataReader.ReadAsync())
        {
            int role1 = int.Parse(dataReader["role"].ToString()!);
            var aplication = new Aplications(
                id: int.Parse(dataReader["id"].ToString()!),
                roomId: int.Parse(dataReader["room_id"].ToString()!),
                startTime : DateTime.Parse(dataReader["start_time"].ToString()!),
                endTime : DateTime.Parse(dataReader["end_time"].ToString()!),
                companyId : int.Parse(dataReader["company_id"].ToString()!),
                isAllowed : bool.Parse(dataReader["isAllowed"].ToString()!)
                );
            aplications.Add(aplication);
        }
        return aplications;

    }

    public async Task<List<Room>> GetAllRoomsAsync()
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.GetAllRooms;


        await connection.OpenAsync();

        using var dataReader = await command.ExecuteReaderAsync();
        var rooms = new List<Room>();
        while (await dataReader.ReadAsync())
        {
            var room = new Room(
                id: int.Parse(dataReader["id"].ToString()!),
                roomNumber: int.Parse(dataReader["room_number"].ToString()!),
                countSeats: int.Parse(dataReader["count_seats"].ToString()!)
                );
            rooms.Add(room);
        }
        return rooms;

    }

    public async Task<List<Room>> GetRoomsByDateAsync(DateTime time)
    {
        var connection = GetConnection();
        using var command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        command.CommandText = Procedures.GetRoomByDate;
        command.Parameters.Add(new SqlParameter("@start_time", time.ToString()));

        await connection.OpenAsync();

        using var dataReader = await command.ExecuteReaderAsync();
        var rooms = new List<Room>();
        while (await dataReader.ReadAsync())
        {
            var room = new Room(
                id: int.Parse(dataReader["id"].ToString()!),
                roomNumber: int.Parse(dataReader["room_number"].ToString()!),
                countSeats: int.Parse(dataReader["count_seats"].ToString()!)
                );
            rooms.Add(room);
        }
        return rooms;
    }
}
