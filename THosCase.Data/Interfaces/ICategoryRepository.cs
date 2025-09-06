namespace THosCase.Data.Interfaces
{
    using System.Collections.Generic;
    using THosCase.Data.Context;

    public interface ICategoryRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        Category Get(int categoryId);

        /// <summary>
        /// Get All
        /// </summary>
        List<Category> GetAll();

        /// <summary>
        /// Add
        /// </summary>
        void Add(Category requestModel);

        /// <summary>
        /// Update
        /// </summary>
        void Update(Category requestModel);

        /// <summary>
        /// Delete
        /// </summary>
        void Delete(int categoryId);
    }
}
