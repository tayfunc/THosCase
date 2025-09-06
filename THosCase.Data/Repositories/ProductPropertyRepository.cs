namespace THosCase.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// Product Property Repository
    /// </summary>
    public class ProductPropertyRepository : IProductPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add
        /// </summary>
        public void Add(ProductProperty requestModel)
        {
            _context.ProductProperties.Add(requestModel);

            _context.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(int productPropertyId)
        {
            var productProperty = _context.ProductProperties.FirstOrDefault(x => x.ProductPropertyId == productPropertyId);

            _context.ProductProperties.Remove(productProperty);

            _context.SaveChanges();
        }

        /// <summary>
        /// Get
        /// </summary>
        public ProductProperty Get(int productPropertyId)
        {
            return _context.ProductProperties.FirstOrDefault(x => x.ProductPropertyId == productPropertyId);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public List<ProductProperty> GetAll()
        {
            return _context.ProductProperties.ToList();
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update(ProductProperty requestModel)
        {
            var product = _context.ProductProperties.FirstOrDefault(x => x.ProductPropertyId == requestModel.ProductPropertyId);

            product.ProductId = requestModel.ProductId;
            product.ProductPropertyId = requestModel.ProductPropertyId;

            _context.SaveChanges();
        }
    }
}
