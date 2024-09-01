namespace practice_web_apis.Dtos
{
    public class ApiResponses
    {
        public record class GeneralResponse<T>(bool Success, string Message, T? Data = default);
        public record class LoginResponse(bool Success, string Message, string Token);
    }
}
