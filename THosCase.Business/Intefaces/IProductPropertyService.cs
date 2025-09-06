namespace THosCase.Business.Intefaces
{
    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of Product Property Service
    /// </summary>
    public interface IProductPropertyService
    {
        /// <summary>
        /// Get
        /// </summary>
        ServiceResult<ProductPropertyModel> Get(int productPropertyId);

        /// <summary>
        /// Get All
        /// </summary>
        ServiceResult<List<ProductPropertyModel>> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<ProductPropertyModel> Add(ProductPropertyRequestModel requestModel);

        /// <summary>
        /// Update
        /// </summary>
        ServiceResult<ProductPropertyModel> Update(ProductPropertyRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int productPropertyId);
    }
}
