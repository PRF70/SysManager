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
    public class ProductsPostRequestValidator : AbstractValidator<ProductsPostRequest>
    {
        public ProductsPostRequestValidator(ProductsRepository repository,
                                            UnityRepository _unityRepository,
                                            CategoryRepository _categoryRepository,
                                            ProductTypeRepository _producttypeRepository)
        {
            RuleFor(contract => contract.ProductCode)
               .Must(productcode => !string.IsNullOrEmpty(productcode))
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_ProductCode_Cannot_Be_Null_Or_Empty.Description());
            RuleFor(contract => contract.Name)
               .Must(name => !string.IsNullOrEmpty(name))
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.CostPrice)
               .Must(costprice => costprice > 0)
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_CostPrice_Must_Be_Greater_Than_Zero.Description());

            RuleFor(contract => contract)
               .Must(productPrice =>
               {
                   var _calc = productPrice.CostPrice + (productPrice.CostPrice * productPrice.Percentage) / 100;
                   return (productPrice.Price == _calc);
               })
                .WithMessage(SysManagerErrors.Product_Post_BadRequest_Price_Must_Be_Exact.Description());



            RuleFor(contract => contract.UnityId)
               .Must(unityid => !string.IsNullOrEmpty(unityid.ToString()))
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_UnityId_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.CategoryId)
               .Must(categoryid => !string.IsNullOrEmpty(categoryid.ToString()))
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_CategoryId_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.ProductTypeId)
               .Must(producttypeid => !string.IsNullOrEmpty(producttypeid.ToString()))
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_ProductTypeId_Cannot_Be_Null_Or_Empty.Description());


            RuleFor(contract => contract.Active)
                           .Must(active => active == true || active == false)
                           .WithMessage(SysManagerErrors.Products_Post_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.CategoryId)
                .Must(categoryid =>
                {
                    var exists = _categoryRepository.GetByIdAsync(Guid.Parse(categoryid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Post_BadRequest_CategoryId_Cannot_Be_Found.Description());

            RuleFor(contract => contract.UnityId)
                .Must(unityid =>
                {
                    var exists = _unityRepository.GetByIdAsync(Guid.Parse(unityid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Post_BadRequest_UnityId_Cannot_Be_Found.Description());

            RuleFor(contract => contract.ProductTypeId)
                .Must(producttypeid =>
                {
                    var exists = _producttypeRepository.GetByIdAsync(Guid.Parse(producttypeid)).Result;
                    return exists != null;
                })
                .WithMessage(SysManagerErrors.Products_Post_BadRequest_ProductTypeId_Cannot_Be_Found.Description());

            RuleFor(contract => contract.Name)
               .Must(name =>
               {
                   var exists = repository.GetByNameAsync(name).Result;
                   return exists == null;
               })
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_Name_Cannot_Be_Duplicated.Description());
            RuleFor(contract => contract)
               .Must(contract =>
               {
                   var exists = repository.GetByProductCodeAsync(contract.ProductCode).Result;
                   return exists == null;
               })
               .WithMessage(SysManagerErrors.Products_Post_BadRequest_ProductCode_Cannot_Be_Duplicated.Description());


        }
    }
}
