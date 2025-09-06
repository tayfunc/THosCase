namespace THosCase.Business.User
{
    using AutoMapper;
    using System;
    using System.Collections.Generic;

    using THosCase.Business.Abstraction;
    using THosCase.Business.Intefaces;
    using THosCase.Business.RequestModel;
    using THosCase.Data.Context;
    using THosCase.Data.DTOs;
    using THosCase.Data.Interfaces;
    using THosCase.Data.Repositories;

    /// <summary>
    /// User Service
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Add
        /// </summary>
        public ServiceResult<UserModel> Add(UserRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRequestModel, UserDto>();
                cfg.CreateMap<User, UserModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            UserDto userDto = mapper.Map<UserDto>(requestModel);

            try
            {
                _userRepository.Add(userDto);

                var user = _userRepository.Get(userDto.UserId);

                if (user == null)
                {
                    return ServiceResult.Failed<UserModel>(ServiceError.CategoryAddFailed);
                }

                UserModel userModel = mapper.Map<UserModel>(user);

                return ServiceResult.Success(userModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        public ServiceResult Delete(int userId)
        {
            var user = _userRepository.Get(userId);

            if (user == null)
            {
                return ServiceResult.Failed(ServiceError.UserDeleteFailed);
            }

            _userRepository.Delete(userId);

            return ServiceResult.Success(user);
        }

        /// <summary>
        /// Get
        /// </summary>
        public ServiceResult<UserModel> Get(int userId)
        {
            var user = _userRepository.Get(userId);

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());

            var mapper = mappingConfig.CreateMapper();

            UserModel userModel = mapper.Map<UserModel>(user);

            return ServiceResult.Success(userModel);            
        }

        /// <summary>
        /// Get All
        /// </summary>
        public ServiceResult<List<UserModel>> GetAll()
        {
            var users = _userRepository.GetAll();

            var mappingConfig = new MapperConfiguration(cfg => cfg.CreateMap<User, UserModel>());

            var mapper = mappingConfig.CreateMapper();

            List<UserModel> userModels = mapper.Map<List<UserModel>>(users);

            return ServiceResult.Success(userModels);
        }


        /// <summary>
        /// Update
        /// </summary>
        public ServiceResult<UserModel> Update(UserRequestModel requestModel)
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserRequestModel, UserDto>();
                cfg.CreateMap<UserDto, UserModel>();
            });

            var mapper = mappingConfig.CreateMapper();

            UserDto userDto = mapper.Map<UserDto>(requestModel);

            try
            {
                _userRepository.Update(userDto);

                UserModel userModel = mapper.Map<UserModel>(userDto);

                return ServiceResult.Success(userModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Validate
        /// </summary>
        public ServiceResult Validate(LoginModel requestModel)
        {
            var isValid = _userRepository.Validate(requestModel.Username, requestModel.Password);

            if (isValid)
            {
                return ServiceResult.Success();
            }
            else
            {
                return ServiceResult.Failed(ServiceError.UserNotFound);
            }
        }
    }
}
