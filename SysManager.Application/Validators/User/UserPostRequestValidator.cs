using FluentValidation;
using SysManager.Application.Contracts.Users.Request;
using SysManager.Application.Data.MySql.Repositories;
using SysManager.Application.Errors;
using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Validators.User
{
    public class UserPostRequestValidator : AbstractValidator<UserPostRequest>
    {
        public UserPostRequestValidator(UserRepository repository)
        {
            RuleFor(Contracts => Contracts.UserName)
                .Must(_name => !string.IsNullOrEmpty(_name))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_UserName_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(Contracts => Contracts.Email)
                .Must(_email => !string.IsNullOrEmpty(_email))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_Email_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(Contracts => Contracts.Password)
                .Must(_pass => !string.IsNullOrEmpty(_pass))
                .WithMessage(SysManagerErrors.User_Post_BadRequest_Password_Cannot_Be_Null_Or_Empty.Description());

            RuleFor(contract => contract.Email)
                           .Must(email =>
                           {
                               var userExists = repository.GetUserByEmail(email).Result;
                               return userExists == null;
                           })
                           .WithMessage(SysManagerErrors.User_Post_BadRequest_Email_Cannot_Be_Duplicated.Description());
        }
    }
}
