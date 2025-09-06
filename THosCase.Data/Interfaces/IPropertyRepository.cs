namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;

    using THosCase.Data.Context;

    /// <summary>
    /// Interface of Property Repository
    /// </summary>
    public interface IPropertyRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        Property Get(int propertyId);

        /// <summary>
        /// Get All
        /// </summary>
        List<Property> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        void Add(Property requestModel);

        /// <summary>
        /// Update
        /// </summary>
        void Update(Property requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int propertyId);
    }
}
