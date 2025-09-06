namespace THosCase.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// Product Repository
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;            
        }

        /// <summary>
        /// Add
        /// </summary>
        public void Add(Product requestModel)
        {
            _context.Products.Add(requestModel);

            _context.SaveChanges();
        }

        public void AddProperty(ProductProperty requestModel)
        {
            _context.ProductProperties.Add(requestModel);

            _context.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(int productId)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == productId);

            _context.Products.Remove(product);

            _context.SaveChanges();
        }

        /// <summary>
        /// Get
        /// </summary>
        public Product Get(int productId)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == productId);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update(Product requestModel)
        {
            var product = _context.Products.FirstOrDefault(x => x.ProductId == requestModel.ProductId);

            product.ProductName = requestModel.ProductName;
            product.CategoryId = requestModel.CategoryId;
            product.Price = requestModel.Price;
            product.ImagePath = requestModel.ImagePath;
            product.IsDeleted = requestModel.IsDeleted;

            _context.SaveChanges();
        }
    }
}
