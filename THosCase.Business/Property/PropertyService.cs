namespace THosCase.Business.Property
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
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        /// <summary>
        /// Add
        /// </summary>
        public ServiceResult<PropertyModel> Add(PropertyRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyRequestModel, Property>();
                cfg.CreateMap<Property, PropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Property propertyDto = mapper.Map<Property>(requestModel);

            _propertyRepository.Add(propertyDto);

            var property = _propertyRepository.Get(propertyDto.PropertyId);

            if (property == null)
            {
                return ServiceResult.Failed<PropertyModel>(ServiceError.PropertyAddFailed);
            }

            PropertyModel propertyModel = mapper.Map<PropertyModel>(property);

            return ServiceResult.Success(propertyModel);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public ServiceResult Delete(int propertyId)
        {
            var property = _propertyRepository.Get(propertyId);

            if (property == null)
            {
                return ServiceResult.Failed(ServiceError.PropertyDeleteFailed);
            }

            _propertyRepository.Delete(propertyId);

            return ServiceResult.Success(property);
        }

        /// <summary>
        /// Get
        /// </summary>
        public ServiceResult<PropertyModel> Get(int propertyId)
        {
            var property = _propertyRepository.Get(propertyId);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Property, PropertyModel>());

            var mapper = mappingConfig.CreateMapper();

            PropertyModel propertyModel = mapper.Map<PropertyModel>(property);

            return ServiceResult.Success(propertyModel);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public ServiceResult<List<PropertyModel>> GetAll()
        {
            var properties = _propertyRepository.GetAll();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Property, PropertyModel>());

            var mapper = mappingConfig.CreateMapper();

            List<PropertyModel> propertyModels = mapper.Map<List<PropertyModel>>(properties);

            return ServiceResult.Success(propertyModels);
        }

        /// <summary>
        /// Update
        /// </summary>
        public ServiceResult<PropertyModel> Update(PropertyRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PropertyRequestModel, Property>();
                cfg.CreateMap<Property, PropertyModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Property propertyDto = mapper.Map<Property>(requestModel);

            _propertyRepository.Update(propertyDto);

            PropertyModel propertyModel = mapper.Map<PropertyModel>(propertyDto);

            return ServiceResult.Success(propertyModel);
        }
    }
}
