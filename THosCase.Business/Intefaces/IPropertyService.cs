namespace THosCase.Business.Intefaces
{
    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.RequestModel;

    /// <summary>
    /// Interface of Property Service
    /// </summary>
    public interface IPropertyService
    {
        /// <summary>
        /// Get
        /// </summary>
        ServiceResult<PropertyModel> Get(int propertyId);

        /// <summary>
        /// Get All
        /// </summary>
        ServiceResult<List<PropertyModel>> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        ServiceResult<PropertyModel> Add(PropertyRequestModel requestModel);

        /// <summary>
        /// Update
        /// </summary>
        ServiceResult<PropertyModel> Update(PropertyRequestModel requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        ServiceResult Delete(int propertyId);
    }
}
