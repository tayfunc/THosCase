namespace THosCase.Business.Category
{
    using AutoMapper;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;

    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// Category Service
    /// </summary>
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Add
        /// </summary>
        public ServiceResult<CategoryModel> Add(CategoryRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryRequestModel, Category>();
                cfg.CreateMap<Category, CategoryModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Category categoryDto = mapper.Map<Category>(requestModel);

            categoryDto.CreatedDate = DateTime.Now;

            _categoryRepository.Add(categoryDto);

            var category = _categoryRepository.Get(categoryDto.CategoryId);

            if (category == null)
            {
                return ServiceResult.Failed<CategoryModel>(ServiceError.CategoryAddFailed);
            }

            CategoryModel categoryModel = mapper.Map<CategoryModel>(category);

            return ServiceResult.Success(categoryModel);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public ServiceResult Delete(int categoryId)
        {
            if (_categoryRepository.GetAll().Any(x => x.ParentCategoryId == categoryId))
            {
                return ServiceResult.Failed<CategoryModel>(ServiceError.CategoryHasSubRecord);
            }

            var category = _categoryRepository.Get(categoryId);

            if (category == null)
            {
                return ServiceResult.Failed(ServiceError.CategoryDeleteFailed);
            }

            _categoryRepository.Delete(categoryId);            

            return ServiceResult.Success(category);
        }

        /// <summary>
        /// Get
        /// </summary>
        public ServiceResult<CategoryModel> Get(int categoryId)
        {
            var category = _categoryRepository.Get(categoryId);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>());

            var mapper = mappingConfig.CreateMapper();

            CategoryModel categoryModel = mapper.Map<CategoryModel>(category);

            return ServiceResult.Success(categoryModel);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public ServiceResult<List<CategoryModel>> GetAll()
        {
            var categories = _categoryRepository.GetAll();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Category, CategoryModel>());

            var mapper = mappingConfig.CreateMapper();

            List<CategoryModel> categoryModels = mapper.Map<List<CategoryModel>>(categories);

            return ServiceResult.Success(categoryModels);
        }

        /// <summary>
        /// Update
        /// </summary>
        public ServiceResult<CategoryModel> Update(CategoryRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryRequestModel, Category>();
                cfg.CreateMap<Category, CategoryModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Category categoryDto = mapper.Map<Category>(requestModel);

            _categoryRepository.Update(categoryDto);

            CategoryModel categoryModel = mapper.Map<CategoryModel>(categoryDto);

            return ServiceResult.Success(categoryModel);
        }
    }
}
