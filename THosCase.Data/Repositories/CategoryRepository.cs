namespace THosCase.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category requestModel)
        {
            _context.Categories.Add(requestModel);

            _context.SaveChanges();
        }

        public void Delete(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);

            _context.Categories.Remove(category);

            _context.SaveChanges();
        }

        public Category Get(int categoryId)
        {
            return _context.Categories.FirstOrDefault(x=> x.CategoryId == categoryId);
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public void Update(Category requestModel)
        {
            var category = _context.Categories.FirstOrDefault(x=> x.CategoryId == requestModel.CategoryId);

            category.CategoryName = requestModel.CategoryName;
            category.ParentCategoryId = requestModel.ParentCategoryId;
            category.IsDeleted = requestModel.IsDeleted;

            _context.SaveChanges();
        }
    }
}
