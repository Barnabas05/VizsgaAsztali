using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VizsgaAsztali
{
    public class Database
    {
        private const string connectionString = "Server=localhost;Database=[db_name];Uid=root;Pwd=;";

        public static List<[Class_name]> GetItems()
        {
            var [list_name] = new List<[Class_name]>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT [all data]";
                using (var command = new MySqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("id");
                            string [var_name] = reader.GetString("[var_name]");
                            
                            int [var_name1] = reader.GetInt32("[var_name1]");
                            

                            [list_name].Add(new [Class_name](id, [var_name], [var_name1], ...));
                         
                        }
                    }
				}
			}
            return [list_name];
		}

		public static bool DeleteItem(long id)
		{
			using (MySqlConnection conn = new MySqlConnection(connectionString))
			{
				conn.Open();
				string query = "DELETE FROM [table_name] WHERE id = @id";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@id", id);
				int affectedRows = cmd.ExecuteNonQuery();
				return affectedRows == 1;
			}
		}
	}
}
