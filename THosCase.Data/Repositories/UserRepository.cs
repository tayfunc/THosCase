namespace THosCase.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Linq;

    using THosCase.Data.Context;
    using THosCase.Data.DTOs;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// User Repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Add
        /// </summary>
        public void Add(UserDto requestModel)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["THosDefault"].ConnectionString))
                {
                    if (sqlConn.State != System.Data.ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }

                    using (SqlCommand sqlCmd = new SqlCommand("spAddUser", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("Name", requestModel.Name);
                        sqlCmd.Parameters.AddWithValue("Surname", requestModel.Surname);
                        sqlCmd.Parameters.AddWithValue("Username", requestModel.Username);
                        sqlCmd.Parameters.AddWithValue("Password", requestModel.Password);

                        var userId = sqlCmd.ExecuteScalar();

                        requestModel.UserId = (int)userId;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(int userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == userId);

            _context.Users.Remove(user);

            _context.SaveChanges();
        }

        /// <summary>
        /// Get
        /// </summary>
        public User Get(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == userId);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update(UserDto requestModel)
        {
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(ConfigurationManager.ConnectionStrings["THosDefault"].ConnectionString))
                {
                    if (sqlConn.State != System.Data.ConnectionState.Open)
                    {
                        sqlConn.Open();
                    }

                    using (SqlCommand sqlCmd = new SqlCommand("spUpdateUser", sqlConn))
                    {
                        sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("UserId", requestModel.UserId);
                        sqlCmd.Parameters.AddWithValue("Name", requestModel.Name);
                        sqlCmd.Parameters.AddWithValue("Surname", requestModel.Surname);
                        sqlCmd.Parameters.AddWithValue("Username", requestModel.Username);
                        sqlCmd.Parameters.AddWithValue("Password", requestModel.Password);

                        sqlCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
