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
        /// Add Range
        /// </summary>
        public void AddRange(List<ProductProperty> requestModel)
        {
            _context.ProductProperties.AddRange(requestModel);

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
        /// Delete By Product Id
        /// </summary>
        public void DeleteByProductId(int productId)
        {
            var productProperties = _context.ProductProperties.Where(x => x.ProductId == productId).ToList();

            _context.ProductProperties.RemoveRange(productProperties);

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
        /// Get By Product Id
        /// </summary>
        public List<ProductProperty> GetByProductId(int productId)
        {
            return _context.ProductProperties.Where(x=> x.ProductId == productId).ToList();
        }
    }
}
