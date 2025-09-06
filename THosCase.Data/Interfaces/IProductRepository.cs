namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;
    using THosCase.Data.Context;

    /// <summary>
    /// Interface of Product Repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        Product Get(int productId);

        /// <summary>
        /// Get All
        /// </summary>
        List<Product> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        void Add(Product requestModel);

        /// <summary>
        /// Update
        /// </summary>
        void Update(Product requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int productId);
    }
}
