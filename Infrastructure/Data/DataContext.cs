using Npgsql;

namespace Infrastructure.Data;

public class DataContext
{
    private const string connectionString = "Server=localhost;Port=5433;Database=exam-16-05;User Id=postgres;Password=nozimjanov";

    public Task<NpgsqlConnection> GetConnection()
    {
        return Task.FromResult(new NpgsqlConnection(connectionString));
    }
}
