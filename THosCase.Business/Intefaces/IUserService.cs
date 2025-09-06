namespace THosCase.Business.Intefaces
{
    using System.Collections.Generic;
    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of User Service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Get
        /// </summary>
        ServiceResult<UserModel> Get(int userId);

        /// <summary>
        /// Get All
        /// </summary>
        ServiceResult<List<UserModel>> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<UserModel> Add(UserRequestModel requestModel);

        /// <summary>
        /// Update
        /// </summary>
        ServiceResult<UserModel> Update(UserRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int userId);
    }
}
