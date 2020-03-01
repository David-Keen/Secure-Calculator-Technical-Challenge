using System;
using System.Data;
using System.Data.SQLite;

namespace Calculator_Application.Database
{
    public class ReleaseDatabase : IDatabaseContext
    {
        IUser IDatabaseContext.GetUser(string firstName, string lastName)
        {
            return null;
        }

        private SQLiteConnection OpenDatabaseConnection()
        {
            var path = System.IO.Directory.GetCurrentDirectory() + "\\Database\\database.sqlite3";
            var connection = new SQLiteConnection(String.Format("Data Source={0};Version=3", path));
            connection.Open();
            System.Diagnostics.Debug.WriteLine(String.Format("Path is: {0}", path));
            return connection;
        }

        private void PrepareCommand(ref SQLiteCommand command, SQLiteParameter[] parameters, ref SQLiteConnection connection)
        {
            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }
            command.Connection = connection;
            command.Prepare();
        }

        private SQLiteCommand ExecuteQuery(string query, SQLiteParameter[] parameters, ref SQLiteConnection connection)
        {
            var command = new SQLiteCommand();
            command.CommandText = query;
            PrepareCommand(ref command, parameters, ref connection);
            return command;
        }

        IUser IDatabaseContext.GetUser(int id)
        {
            var connection = OpenDatabaseConnection();
            SQLiteParameter[] parameters = { new SQLiteParameter("@Id", id) };
            var command = ExecuteQuery("SELECT * FROM users WHERE Id = @Id", parameters, ref connection);

            using (var reader = command.ExecuteReader())
            {
                var table = LoadTable(reader);
                connection.Close();
                reader.Close();
                return GetUserFromQueryResult(table, id);
            }
        }

        private DataTable LoadTable(SQLiteDataReader reader)
        {
            var table = new DataTable();
            table.Load(reader);
            return table;
        }

        private User GetUserFromQueryResult(DataTable table, int id)
        {
            if (table.Rows.Count <= 0) return null;
            var row = table.Rows[0];
            string firstName = row["FirstName"].ToString();
            string lastName = row["LastName"].ToString();
            string passwordHash = row["Password"].ToString();
            return new User(firstName, lastName, passwordHash, id);
        }
    }
}
