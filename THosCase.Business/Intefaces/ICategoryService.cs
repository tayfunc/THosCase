namespace THosCase.Business.Intefaces
{
    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of Category Service
    /// </summary>
    public interface ICategoryService
    {
        /// <summary>
        /// Get
        /// </summary>
        ServiceResult<CategoryModel> Get(int categoryId);

        /// <summary>
        /// Get All
        /// </summary>
        ServiceResult<List<CategoryModel>> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<CategoryModel> Add(CategoryRequestModel requestModel);

        /// <summary>
        /// Update
        /// </summary>
        ServiceResult<CategoryModel> Update(CategoryRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int categoryId);
    }
}
