namespace THosCase.Business.ProductProperty
{
    using AutoMapper;
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
                cfg.CreateMap<ProductPropertyRequestModel, ProductProperty>();
                cfg.CreateMap<ProductProperty, ProductPropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            ProductProperty productPropertyDto = mapper.Map<ProductProperty>(requestModel);

            _productPropertyRepository.Add(productPropertyDto);

            ProductPropertyModel productPropertyModel = mapper.Map<ProductPropertyModel>(productPropertyDto);

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
        /// Get By Product Id
        /// </summary>
        public ServiceResult<ProductPropertyModel> GetByProductId(int productId)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductProperty, ProductPropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            var productProperties = _productPropertyRepository.GetByProductId(productId);

            ProductPropertyModel productPropertyModel = mapper.Map<ProductPropertyModel>(productProperties);

            return ServiceResult.Success(productPropertyModel);
        }
    }
}
