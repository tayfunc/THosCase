namespace THosCase.Business.Intefaces
{
    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of Product Property Service
    /// </summary>
    public interface IProductPropertyService
    {
        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<ProductPropertyModel> Add(ProductPropertyRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int productPropertyId);

        /// <summary>
        /// Get By Product Id
        /// </summary>
        ServiceResult<ProductPropertyModel> GetByProductId(int productId);
    }
}
