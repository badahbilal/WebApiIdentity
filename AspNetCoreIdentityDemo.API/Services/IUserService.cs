using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreIdentityDemo.Shared;

namespace AspNetCoreIdentityDemo.API.Services
{
    public interface IUserService
    {
        Task<UserMangerResponse> RegisterUserAsync(RegisterViewMolel model);
        
    }
}