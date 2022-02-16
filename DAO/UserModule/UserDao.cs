using Microsoft.Extensions.Configuration;
using Model.UserModule;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO.UserModule
{
    public class UserDao
    {
        private readonly string _connectionString;

        public UserDao(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("defaultConnection");
        }

        public bool InsertUser(User user)
        {
            bool success = false;
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("InsertUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", user.Username));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@sede", user.Sede));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            return success;
        }

        public bool UpdateUser(User user)
        {
            bool success = false;
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", user.Id));
                    cmd.Parameters.Add(new SqlParameter("@username", user.Username));
                    cmd.Parameters.Add(new SqlParameter("@password", user.Password));
                    cmd.Parameters.Add(new SqlParameter("@name", user.Name));
                    cmd.Parameters.Add(new SqlParameter("@sede", user.Sede));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            return success;
        }

        public bool DeleteUser(int id)
        {
            bool success = false;
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteUser", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    sql.Open();
                    cmd.ExecuteNonQuery();
                    success = true;
                }
            }
            return success;
        }

        public User UserLogin(string username, string password)
        {
            User user = null;
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("User_Login", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@username", username));
                    cmd.Parameters.Add(new SqlParameter("@password", password));
                    sql.Open();
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt64(reader["id"].ToString()),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Name = reader["name"].ToString(),
                                Sede = reader["sede"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }

        public List<User> GetListUsers()
        {
            List<User> users = new List<User>();
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("GetListUsers", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sql.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new User
                            {
                                Id = Convert.ToInt64(reader["id"].ToString()),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Name = reader["name"].ToString(),
                                Sede = reader["sede"].ToString()
                            });
                        }
                    }
                }
            }
            return users;
        }

        public User GetUserForId(int id)
        {
            User user = null;
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("select * from user_data where id = @id", sql))
                {
                    cmd.Parameters.Add(new SqlParameter("@id", id));
                    sql.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt64(reader["id"].ToString()),
                                Username = reader["username"].ToString(),
                                Password = reader["password"].ToString(),
                                Name = reader["name"].ToString(),
                                Sede = reader["sede"].ToString()
                            };
                        }
                    }
                }
            }
            return user;
        }
    }
}
