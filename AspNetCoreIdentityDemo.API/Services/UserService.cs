using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentityDemo.Shared;
using Microsoft.AspNetCore.Identity;
namespace AspNetCoreIdentityDemo.API.Services
{
    public class UserService : IUserService
    {
        private UserManager<IdentityUser> _userManger;

        public UserService(UserManager<IdentityUser> userManager)
        {
            _userManger = userManager;
        }
        public async Task<UserMangerResponse> RegisterUserAsync(RegisterViewMolel model)
        {
            if(model == null){
                throw new NullReferenceException("Register Model is null");
            }

            if(model.Password != model.ConfirmPassword){
              return  new UserMangerResponse {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };  
            }
            var identityUser = new IdentityUser{
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManger.CreateAsync(identityUser,model.Password);

            if(result.Succeeded){

                // TODO: Send confirmation email

                return new UserMangerResponse{
                    Message = "User created successfully!",
                    IsSuccess = true
                };
            }

            return new UserMangerResponse {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }
    }
}