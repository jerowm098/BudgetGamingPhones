using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using InfinixShop_Common;
using Microsoft.Extensions.Configuration;

namespace InfinixShop_DataLogic
{
    public class SqlPhoneDataService : IPhoneDataService
    {
        private readonly string connectionString;

        public SqlPhoneDataService(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SqlConnection");
        }

        public bool AddItem(string name)
        {
            if (SearchItemByName(name) != null)
            {
                return false;
            }

            var insertStatement = "INSERT INTO PhoneItems (Name) VALUES (@Name);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(insertStatement, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error adding item: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public List<PhoneItem> GetAllItems()
        {
            var phoneItems = new List<PhoneItem>();
            string selectStatement = "SELECT Id, Name FROM PhoneItems;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                phoneItems.Add(new PhoneItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString()
                                });
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error getting all items: {ex.Message}");
                    }
                }
            }
            return phoneItems;
        }

        public bool UpdateItem(int id, string newName)
        {
            string updateStatement = "UPDATE PhoneItems SET Name = @newName WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateStatement, connection))
                {
                    command.Parameters.AddWithValue("@newName", newName);
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error updating item: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool DeleteItem(int id)
        {
            string deleteStatement = "DELETE FROM PhoneItems WHERE Id = @Id;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(deleteStatement, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error deleting item: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public PhoneItem SearchItemByName(string name)
        {
            PhoneItem phoneItem = null;
            string selectStatement = "SELECT Id, Name FROM PhoneItems WHERE LOWER(Name) LIKE '%' + LOWER(@Name) + '%';";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(selectStatement, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                phoneItem = new PhoneItem
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Name = reader["Name"].ToString()
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"SQL Error searching item: {ex.Message}");
                    }
                }
            }
            return phoneItem;
        }
    }
}
