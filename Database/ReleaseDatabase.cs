using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SQLite;

namespace Database
{
    public class ReleaseDatabase : IDatabaseContext
    {
        IUser IDatabaseContext.GetUser(string firstName, string lastName)
        {
            return null;
        }

        IUser IDatabaseContext.GetUser(int id)
        {
            var connection = new SQLiteConnection("Data Source=C:\\Users\\David\\source\\repos\\Secure-Calculator-Technical-Challenge\\Database\\database.sqlite3;Version=3");
            var command = new SQLiteCommand();
            command.CommandText = "SELECT * FROM users WHERE Id = @Id";
            var idParam = new SQLiteParameter("@Id", id);
            command.Parameters.Add(idParam);

            connection.Open();
            command.Connection = connection;
            command.Prepare();
            System.Diagnostics.Debug.WriteLine("Table rows: {0}", command.CommandText);
            using (var reader = command.ExecuteReader())
            {
                var table = new DataTable();
                table.Load(reader);
                reader.Close();
                connection.Close();
                System.Diagnostics.Debug.WriteLine("Number of rows: {0}", table.Rows.Count);
                if (table.Rows.Count <= 0) return null;
                var row = table.Rows[0];
                string firstName = row["FirstName"].ToString();
                string lastName = row["LastName"].ToString();
                string passwordHash = row["Password"].ToString();
                return new User(firstName, lastName, passwordHash, id);
            }
        }
    }
}
