namespace THosCase.Business.Intefaces
{
    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of Product Service
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Get
        /// </summary>
        ServiceResult<ProductModel> Get(int productId);

        /// <summary>
        /// Get All
        /// </summary>
        ServiceResult<List<ProductModel>> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<ProductModel> Add(ProductRequestModel requestModel);

        /// <summary>
        /// Update
        /// </summary>
        ServiceResult<ProductModel> Update(ProductRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int productId);
    }
}
