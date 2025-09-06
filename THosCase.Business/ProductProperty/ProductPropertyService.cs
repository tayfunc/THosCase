namespace THosCase.Business.ProductProperty
{
    using AutoMapper;

    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;

    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;

    /// <summary>
    /// Product Property Service
    /// </summary>
    public class ProductPropertyService : IProductPropertyService
    {
        private readonly IProductPropertyRepository _productPropertyRepository;

        public ProductPropertyService(IProductPropertyRepository productPropertyRepository)
        {
            _productPropertyRepository = productPropertyRepository;
        }

        /// <summary>
        /// Add
        /// </summary>
        public ServiceResult<ProductPropertyModel> Add(ProductPropertyRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductRequestModel, ProductProperty>();
                cfg.CreateMap<ProductProperty, ProductPropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            ProductProperty productPropertyDto = mapper.Map<ProductProperty>(requestModel);

            _productPropertyRepository.Add(productPropertyDto);

            var productProperty = _productPropertyRepository.Get(productPropertyDto.ProductPropertyId);

            if (productProperty == null)
            {
                return ServiceResult.Failed<ProductPropertyModel>(ServiceError.ProductPropertyAddFailed);
            }

            ProductPropertyModel productPropertyModel = mapper.Map<ProductPropertyModel>(productProperty);

            return ServiceResult.Success(productPropertyModel);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public ServiceResult Delete(int productPropertyId)
        {
            var productProperty = _productPropertyRepository.Get(productPropertyId);

            if (productProperty == null)
            {
                return ServiceResult.Failed(ServiceError.ProductPropertyDeleteFailed);
            }

            _productPropertyRepository.Delete(productPropertyId);

            return ServiceResult.Success(productProperty);
        }

        /// <summary>
        /// Get
        /// </summary>
        public ServiceResult<ProductPropertyModel> Get(int productPropertyId)
        {
            var productProperty = _productPropertyRepository.Get(productPropertyId);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<ProductProperty, ProductPropertyModel>());

            var mapper = mappingConfig.CreateMapper();

            ProductPropertyModel productPropertyModel = mapper.Map<ProductPropertyModel>(productProperty);

            return ServiceResult.Success(productPropertyModel);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public ServiceResult<List<ProductPropertyModel>> GetAll()
        {
            var productProperties = _productPropertyRepository.GetAll();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<ProductProperty, ProductPropertyModel>());

            var mapper = mappingConfig.CreateMapper();

            List<ProductPropertyModel> productPropertyModels = mapper.Map<List<ProductPropertyModel>>(productProperties);

            return ServiceResult.Success(productPropertyModels);
        }

        /// <summary>
        /// Update
        /// </summary>
        public ServiceResult<ProductPropertyModel> Update(ProductPropertyRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPropertyRequestModel, ProductProperty>();
                cfg.CreateMap<ProductProperty, ProductPropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            ProductProperty productPropertyDto = mapper.Map<ProductProperty>(requestModel);

            _productPropertyRepository.Update(productPropertyDto);

            ProductPropertyModel productPropertyModel = mapper.Map<ProductPropertyModel>(productPropertyDto);

            return ServiceResult.Success(productPropertyModel);
        }
    }
}
