namespace THosCase.Data.Repositories
{
    using System.Collections.Generic;
    using System.Data.Entity.Core.Metadata.Edm;
    using System.Linq;
    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// Property Repository
    /// </summary>
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add
        /// </summary>
        public void Add(Property requestModel)
        {
            _context.Properties.Add(requestModel);

            _context.SaveChanges();
        }

        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(int propertyId)
        {
            var property = _context.Properties.FirstOrDefault(x => x.PropertyId == propertyId);

            _context.Properties.Remove(property);

            _context.SaveChanges();
        }

        /// <summary>
        /// Get
        /// </summary>
        public Property Get(int propertyId)
        {
            return _context.Properties.FirstOrDefault(x => x.PropertyId == propertyId);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public List<Property> GetAll()
        {
            return _context.Properties.ToList();
        }

        /// <summary>
        /// Update
        /// </summary>
        public void Update(Property requestModel)
        {
            var property = _context.Properties.FirstOrDefault(x => x.PropertyId == requestModel.PropertyId);

            property.PropertyKey = requestModel.PropertyKey;
            property.PropertyValue = requestModel.PropertyValue;

            _context.SaveChanges();
        }
    }
}
