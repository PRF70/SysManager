using SysManager.Application.Contracts.Products.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using SysManager.Application.Validators.Products;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly ProductTypeRepository _productTypeRepository;
        private readonly UnityRepository _unityRepository;

        public ProductsService(ProductsRepository productsRepository,
                               CategoryRepository categoryRepository,
                               ProductTypeRepository productTypeRepository,
                               UnityRepository unityRepository)
        {
            this._productsRepository = productsRepository;
            this._categoryRepository = categoryRepository;
            this._productTypeRepository = productTypeRepository;
            this._unityRepository = unityRepository;
        }

        public async Task<ResultData> PostAsync(ProductsPostRequest request)
        {
            var validator = new ProductsPostRequestValidator(_productsRepository, _unityRepository, _categoryRepository,_productTypeRepository);
            var validatorResult = validator.Validate(request);

            if (!validatorResult.IsValid)
                return Utils.ErrorData(validatorResult.Errors.ToErrorList());


            var entity = new ProductsEntity(request);
            var response = await _productsRepository.CreateAsync(entity);
            return Utils.SuccessData(response);
        }
        public async Task<ResultData> PutAsync(ProductsPutRequest request)
        {
            var validator = new ProductsPutRequestValidator(_productsRepository,_categoryRepository,_unityRepository,_productTypeRepository);
            var validatorResult = validator.Validate(request);
            if (!validatorResult.IsValid)
                return Utils.ErrorData(validatorResult.Errors.ToErrorList());


            var entity = new ProductsEntity(request);
            var response = await _productsRepository.UpdateAsync(entity);
            return Utils.SuccessData(response);            
        }

        public async Task<ResultData> GetByFilterAsync(ProductsGetFilterRequest request)
        {
            var result = await _productsRepository.GetByFilterAsync(request);
            return Utils.SuccessData(result);
        }

        public async Task<ResultData> GetByIdAsync(Guid id)
        {
            var response = await _productsRepository.GetByIdAsync(id);

            if (response != null)
                return Utils.SuccessData(response);

            return Utils.ErrorData(SysManagerErrors.Products_Get_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());
        }
        public async Task<ResultData> DeleteByIdAsync(Guid id)
        {
            var response = await _productsRepository.GetByIdAsync(id);
            if (response != null)
            {
                var result = await _productsRepository.DeleteByIdAsync(id);
                return Utils.SuccessData(result);
            }
            return Utils.ErrorData(SysManagerErrors.Products_Delete_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());
        }

    }
}
