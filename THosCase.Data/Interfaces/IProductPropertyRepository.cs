namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;
    using THosCase.Data.Context;

    /// <summary>
    /// Interface of Product Property
    /// </summary>
    public interface IProductPropertyRepository
    {
        /// <summary>
        /// Add
        /// </summary>
        void Add(ProductProperty requestModel);

        /// <summary>
        /// Add
        /// </summary>
        void AddRange(List<ProductProperty> requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int productPropertyId);

        /// <summary>
        /// Delete By Product Id
        /// </summary>
        void DeleteByProductId(int productId);

        /// <summary>
        /// Get
        /// </summary>
        ProductProperty Get(int productPropertyId);

        /// <summary>
        /// Get By Product Id
        /// </summary>
        List<ProductProperty> GetByProductId(int productId);
    }
}
