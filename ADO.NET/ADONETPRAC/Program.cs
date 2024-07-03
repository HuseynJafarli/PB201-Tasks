using System.Data.SqlClient;

namespace ADONETPRAC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InsertData();
            //DeleteData();
            //GetData(3);
            //GetAllData();
            UpdateData(1,"Grant",98.6);
        }

        static void InsertData()
        {
            string connectionString = "Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Students VALUES ('Huseyn','Jafarli',19,250,1)", connection);

            int check = command.ExecuteNonQuery();
            if (check > 0)
            {
                Console.WriteLine("Inserted!");
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
            connection.Close();
        }

        static void DeleteData()
        {
            string connectionString = "Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand("DELETE FROM Students WHERE Id = 2", connection);

            int check = command.ExecuteNonQuery();
            if (check > 0)
            {
                Console.WriteLine("Deleted!");
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
            connection.Close();
        }

        static void GetData(int id)
        {
            string connectionString = "Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand($"SELECT * FROM Students WHERE Id = {id}", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[3]} - {reader[4]}");
                }
            }
            connection.Close();
        }

        static void GetAllData()
        {
            string connectionString = "Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Students", connection);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]} - {reader[1]} - {reader[3]} - {reader[4]}");
                }
            }
            connection.Close();
        }

        static void UpdateData(int id, string columnName, object value)
        {
            string connectionString = "Server=LAPTOP-UKQF5N8I\\SQLEXPRESS;Database=Academy;Trusted_Connection=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            if (value != null)
            {
                if (columnName == "Age")
                {
                    value = Convert.ToInt32(value);
                }
                else if(columnName == "Grant")
                {
                    value = Convert.ToDecimal(value);
                }
            }
            SqlCommand command = new SqlCommand($"UPDATE Students SET [{columnName}] = {value} WHERE Id = {id}", connection);

            int check = command.ExecuteNonQuery();

            if (check > 0)
            {
                Console.WriteLine("Updated!");
            }
            else
            {
                Console.WriteLine("Error!!!");
            }
            connection.Close();
        }
    }
}
