using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;Database=PrivatTransport;User ID=root;Password=password;";
        using (MySqlConnection conn = new MySqlConnection(connectionString))
        {
            conn.Open();

            // Example of inserting a new driver
            string insertDriverQuery = "INSERT INTO Driver (driverID, name, sex, DOB, phone, officeID) VALUES (3, 'Laura Thompson', 'F', '1990-03-03', '34567890', 1)";
            using (MySqlCommand cmd = new MySqlCommand(insertDriverQuery, conn))
            {
                cmd.ExecuteNonQuery();
            }

            // Example of selecting all drivers
            string selectDriversQuery = "SELECT * FROM Driver";
            using (MySqlCommand cmd = new MySqlCommand(selectDriversQuery, conn))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["driverID"]}, {reader["name"]}, {reader["sex"]}, {reader["DOB"]}, {reader["phone"]}, {reader["officeID"]}");
                    }
                }
            }
        }
    }
}
