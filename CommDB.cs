using Microsoft.Data.SqlClient;

namespace TO_DO_Api
{
    public class CommDB
    {
        readonly string ConnectionString;

        public void Create(string Title, string? Descriprion, DateTime Expiry)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "INSERT INTO Table1 (Title, Description, Expiry) VALUES (title, description, expiry)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@title", Title);
                    command.Parameters.AddWithValue("@description", Descriprion);
                    command.Parameters.AddWithValue("@expiry", Expiry);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        public List<Item> Get(int? Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "SELECT * FROM TDItems";

                if (Id.HasValue)
                    query = query + " Where Id=" + Id.Value.ToString();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                    {
                        Console.WriteLine("Error inserting data into Database!");
                        return new List<Item>();
                    }
                    else
                    {
                        return new List<Item>();//TODO
                    }
                }
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                String query = "DELETE FROM TDitems WHERE Id=" + Id.ToString();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                }
            }
        }

        private CommDB()
        {
            //TODO connection string
        }

        public CommDB(string connectionString)
        {
            ConnectionString = connectionString;
            instance = this;
        }

        private static readonly object padlock = new object();
        private static CommDB? instance = null;
        public static CommDB Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new CommDB();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
