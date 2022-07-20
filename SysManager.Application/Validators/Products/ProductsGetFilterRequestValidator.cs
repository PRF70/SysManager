using FluentValidation;
using SysManager.Application.Contracts.Products.Request;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Validators.Products
{
    public class ProductsGetFilterRequestValidator : AbstractValidator<ProductsGetFilterRequest>
    {
        public ProductsGetFilterRequestValidator()
        {
            RuleFor(contract => contract.Name)
                 .Must(name => !string.IsNullOrEmpty(name))
                 .WithMessage(SysManagerErrors.Products_Get_BadRequest_Name_Cannot_Be_Null_Or_Empty.Description());
            
            RuleFor(contract => contract.Active)
                            .Must(active => active == "todos" || active == "ativos" || active == "inativos")
                            .WithMessage(SysManagerErrors.Products_Get_BadRequest_Active_Cannot_Be_Empty.Description());

            RuleFor(contract => contract.page)
                .Must(active => active > 0)
                .WithMessage(SysManagerErrors.Products_Get_BadRequest_Page_More_Than_Zero.Description());

            RuleFor(contract => contract.pageSize)
               .Must(active => active > 0)
               .WithMessage(SysManagerErrors.Products_Get_BadRequest_pageSize_More_Than_Zero.Description());
        }
    }
}
