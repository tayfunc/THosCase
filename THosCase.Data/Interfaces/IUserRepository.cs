namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;

    using THosCase.Data.Context;
    using THosCase.Data.DTOs;

    /// <summary>
    /// Interface of User Repository
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        User Get(int userId);

        /// <summary>
        /// Get All
        /// </summary>
        List<User> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        void Add(UserDto requestModel);

        /// <summary>
        /// Update
        /// </summary>
        void Update(UserDto requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int userId);

        /// <summary>
        /// Validate
        /// </summary>
        bool Validate(string userName, string password);
    }
}
