using System.Data.SqlClient;

namespace exam_modul_4.Broker;

public partial class DatabaseBroker : IDatabaseBroker
{
    public SqlConnection GetConnection()
    {
        string connectionString = @"Server=localhost; Database=MyDataBase;User Id=sa; password=Baxram2002;";
        return new SqlConnection(connectionString);
    }
}
