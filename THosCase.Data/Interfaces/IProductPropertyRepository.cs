namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;

    using THosCase.Data.Context;

    /// <summary>
    /// Interface of Product Property Repository
    /// </summary>
    public interface IProductPropertyRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        ProductProperty Get(int productPropertyId);

        /// <summary>
        /// Get All
        /// </summary>
        List<ProductProperty> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        void Add(ProductProperty requestModel);

        /// <summary>
        /// Update
        /// </summary>
        void Update(ProductProperty requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int productPropertyId);
    }
}
