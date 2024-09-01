using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using practice_web_apis.Constants;
using practice_web_apis.Dtos;
using practice_web_apis.Models;
using static practice_web_apis.Dtos.ApiResponses;

namespace practice_web_apis.Repository.Authentication
{
    public class AuthenticationRepo(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        RoleManager<IdentityRole> roleManager
        ) : IAuthenticationRepo
    {
        public async Task<GeneralResponse<UserDto>> RegisterUser(UserDto userDto)
        {
            if (userDto is null) throw new ArgumentNullException(nameof(userDto));
            var user = await userManager.FindByEmailAsync(userDto.Email);
            if(user is not null) return new GeneralResponse<UserDto>(false, ResponseMessages.UserExists);
            
            var newUser = new ApplicationUser
            {
                First_name = userDto.First_name,
                Last_name = userDto.Last_name,
                Email = userDto.Email,
                PasswordHash = userDto.Password
            };

            throw new NotImplementedException();

        }
        public Task<ApiResponses.LoginResponse> LoginUser(LoginDto loginDto)
        {
            throw new NotImplementedException();
        }

    }
}
