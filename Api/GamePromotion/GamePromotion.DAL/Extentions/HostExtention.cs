using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace GamePromotion.DAL.Extentions
{
    public static class HostExtention
    {
        public static IHost MigrateDatabase<TContex>(this IHost host, int? retry = 0)
        {
            var retryForAvailability = retry.Value;

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContex>>();

                try
                {
                    logger.LogInformation("Migrating postgres database.");

                    using var connection = new NpgsqlConnection(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
                    connection.Open();

                    using var command = new NpgsqlCommand
                    {
                        Connection = connection
                    };

                    command.CommandText = "DROP TABLE IF EXISTS offers";
                    command.ExecuteNonQuery();

                    command.CommandText = "DROP TABLE IF EXISTS events";
                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Offers
                                            (
                                                id SERIAL PRIMARY KEY,
                                                name VARCHAR(255) NOT NULL,
                                                startsat TIMESTAMP NOT NULL,
                                                expiresat TIMESTAMP NOT NULL,
                                                offertype INTEGER NOT NULL
                                            );";

                    command.ExecuteNonQuery();

                    command.CommandText = @"CREATE TABLE Events
                                            (
                                                id SERIAL PRIMARY KEY,
                                                name VARCHAR(255) NOT NULL,
                                                startsat TIMESTAMP NOT NULL,
                                                expiresat TIMESTAMP NOT NULL,
                                                eventtype INTEGER NOT NULL
                                            );";

                    command.ExecuteNonQuery();

                    command.CommandText = @"INSERT INTO offers(name, startsat, expiresat, offertype) 
                                             VALUES ('Super Chest', '2023-02-26 00:00:10', '2023-10-26 23:59:59', 1),
                                                    ('Mega Chest', '2023-02-28 00:00:10', '2023-10-28 23:59:59', 2);";
                    command.ExecuteNonQuery();

                    command.CommandText = @"INSERT INTO events(name, startsat, expiresat, eventtype) 
                                             VALUES ('Super Tournament', '2023-02-26 00:00:10', '2023-10-26 23:59:59', 1),
                                                    ('Mega Tournament', '2023-02-28 00:00:10', '2023-10-28 23:59:59', 2);";
                    command.ExecuteNonQuery();

                    logger.LogInformation("Migrated postgres database.");
                }
                catch (NpgsqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the postgresql database");

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContex>(host, retryForAvailability);
                    }
                }
            }
            return host;
        }
    }
}
