using practice_web_apis.Dtos;
using static practice_web_apis.Dtos.ApiResponses;

namespace practice_web_apis.Repository.Authentication
{
    public interface IAuthenticationRepo
    {
        Task<GeneralResponse<UserDto>> RegisterUser(UserDto userDto);
        Task<LoginResponse> LoginUser(LoginDto loginDto);
    }
}
