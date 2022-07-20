using FluentValidation;
using SysManager.Application.Contracts.Products.Request;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Validators.Products
{
    public class ProductsPutRequestValidator : AbstractValidator<ProductsPutRequest>
    {
        public ProductsPutRequestValidator(ProductsRepository repository, 
                                           CategoryRepository _categoryRepository, 
                                           UnityRepository _unityRepository, 
                                           ProductTypeRepository _productTypeRepository)
        {
            RuleFor(Contracts => Contracts.ProductCode)
                .Must(productcode => !string.IsNullOrEmpty(productcode.ToString()))
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_Id_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(Contracts => Contracts.Name)
                .Must(_name => !string.IsNullOrEmpty(_name))
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Active)
                           .Must(active => active == true || active == false)
                           .WithMessage(SysManagerErrors.Products_Put_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract)
                .Must(contract =>
                {
                    var exists = repository.GetByNameAsync(contract.Name).Result;

                    if (exists != null)
                        if (exists.ProductCode != contract.ProductCode)
                            return false;
                    return true;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_Name_Cannot_Be_Duplicated.Description());

            RuleFor(contract => contract)
                .Must(contract =>
                {
                    var exists = repository.GetByProductCodeAsync(contract.ProductCode).Result;

                    if (exists != null)
                        if (exists.Id != contract.Id)
                            return false;
                    return true;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_ProductCode_Cannot_Be_Duplicated.Description());


            RuleFor(contract => contract)
                .Must(contract =>
                {
                    var exists = repository.GetByProductCodeAsync(contract.ProductCode).Result;
                    if (exists != null)
                        if (exists.Id != contract.Id)
                            return false;
                    return true;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_ProductCode_Is_Invalid_Or_Inexistent.Description());

            RuleFor(contract => contract.Id)
                .Must(id =>
                {
                    var exists = repository.GetByIdAsync(id).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_Id_Is_Invalid_Or_Inexistent.Description());


            RuleFor(contract => contract.UnityId)
               .Must(unityid => !string.IsNullOrEmpty(unityid.ToString()))
               .WithMessage(SysManagerErrors.Products_Put_BadRequest_UnityId_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.CategoryId)
               .Must(categoryid => !string.IsNullOrEmpty(categoryid.ToString()))
               .WithMessage(SysManagerErrors.Products_Put_BadRequest_CategoryId_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.ProductTypeId)
               .Must(producttypeid => !string.IsNullOrEmpty(producttypeid.ToString()))
               .WithMessage(SysManagerErrors.Products_Put_BadRequest_ProductTypeId_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.CategoryId)
                .Must(categoryid =>
                {
                    var exists = _categoryRepository.GetByIdAsync(Guid.Parse(categoryid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_CategoryId_Cannot_Be_Found.Description());

            RuleFor(contract => contract.UnityId)
                .Must(unityid =>
                {
                    var exists = _unityRepository.GetByIdAsync(Guid.Parse(unityid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_UnityId_Cannot_Be_Found.Description());

            RuleFor(contract => contract.ProductTypeId)
                .Must(producttypeid =>
                {
                    var exists = _productTypeRepository.GetByIdAsync(Guid.Parse(producttypeid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_ProductTypeId_Cannot_Be_Found.Description());

            RuleFor(product => product.CostPrice)
                .Must(cost => cost >= 0)
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_CostPrice_Must_Be_Greater_Than_Zero.Description());

            RuleFor(product => product)
                .Must(productPrice =>
                {
                    var _calc = productPrice.CostPrice + (productPrice.CostPrice * productPrice.Percentage) / 100;
                    return (productPrice.Price == _calc);
                })
                .WithMessage(SysManagerErrors.Products_Put_BadRequest_Price_Must_Be_Exact.Description());


        }
    }
}
