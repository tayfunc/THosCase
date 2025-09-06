namespace THosCase.Business.Product
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Web;
    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Data.Context;
    using THosCase.Data.Interfaces;
    using THosCase.Data.Repositories;

    /// <summary>
    /// Product Service
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        private readonly IProductPropertyRepository _productPropertyRepository;

        public ProductService(IProductRepository repository, IProductPropertyRepository productPropertyRepository)
        {
            _repository = repository;
            _productPropertyRepository = productPropertyRepository;
        }

        /// <summary>
        /// Add
        /// </summary>
        public ServiceResult<ProductModel> Add(ProductRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductRequestModel, Product>();
                cfg.CreateMap<Product, ProductModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Product productDto = mapper.Map<Product>(requestModel);

            productDto.CreatedDate = DateTime.Now;

            _repository.Add(productDto);

            var product = _repository.Get(productDto.ProductId);

            if (product == null)
            {
                return ServiceResult.Failed<ProductModel>(ServiceError.ProductAddFailed);
            }

            if (requestModel.ProductProperties.Length > 0)
            {
                List<ProductProperty> productProperties = requestModel.ProductProperties.Split(',').Select(x => new ProductProperty
                {
                    ProductId = requestModel.ProductId,
                    PropertyId = Convert.ToInt32(x)
                }).ToList();

                _productPropertyRepository.AddRange(productProperties);
            }

            ProductModel productModel = mapper.Map<ProductModel>(product);

            return ServiceResult.Success(productModel);
        }

        /// <summary>
        /// Delete
        /// </summary>
        public ServiceResult Delete(int productId)
        {
            var product = _repository.Get(productId);

            if (product == null)
            {
                return ServiceResult.Failed(ServiceError.ProductDeleteFailed);
            }

            _repository.Delete(productId);

            var folderPath = HttpContext.Current.Server.MapPath("~/Uploads/Images/");
            if (File.Exists(folderPath + product.ImagePath))
            {
                File.Delete(folderPath + product.ImagePath);
            }

            return ServiceResult.Success(product);
        }

        /// <summary>
        /// Get
        /// </summary>
        public ServiceResult<ProductModel> Get(int productId)
        {
            var product = _repository.Get(productId);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductModel>());

            var mapper = mappingConfig.CreateMapper();

            ProductModel productModel = mapper.Map<ProductModel>(product);

            return ServiceResult.Success(productModel);
        }

        /// <summary>
        /// Get All
        /// </summary>
        public ServiceResult<List<ProductModel>> GetAll()
        {
            var products = _repository.GetAll();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductModel>());

            var mapper = mappingConfig.CreateMapper();

            List<ProductModel> productModels = mapper.Map<List<ProductModel>>(products);

            productModels.ForEach(i =>
            {
                i.ProductProperties = string.Join(",", _productPropertyRepository.GetByProductId(i.ProductId).Select(x => x.PropertyId).ToList());
            });

            return ServiceResult.Success(productModels);
        }

        /// <summary>
        /// Update
        /// </summary>
        public ServiceResult<ProductModel> Update(ProductRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductRequestModel, Product>();
                cfg.CreateMap<Product, ProductModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            Product productDto = mapper.Map<Product>(requestModel);

            _repository.Update(productDto);

            if (requestModel.ProductProperties.Length > 0)
            {
                List<ProductProperty> productProperties = requestModel.ProductProperties.Split(',').Where(x => x != "0").Select(x => new ProductProperty
                {
                    ProductId = requestModel.ProductId,
                    PropertyId = Convert.ToInt32(x)
                }).ToList();

                _productPropertyRepository.DeleteByProductId(requestModel.ProductId);

                _productPropertyRepository.AddRange(productProperties);
            }

            ProductModel productModel = mapper.Map<ProductModel>(productDto);

            return ServiceResult.Success(productModel);
        }
    }
}
