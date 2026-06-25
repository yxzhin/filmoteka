namespace filmotekaAPI.DTOs.AuthDTOs
{
    public class LoginResponseDTO : BaseResponseDTO
    {
        public string? AccessToken { get; init; }
        public string? TokenType { get; init; }

        public static LoginResponseDTO Ok(
            string message,
            string accessToken,
            string tokenType
        )
        {
            return new()
            {
                Message = message,
                Success = true,
                AccessToken = accessToken,
                TokenType = tokenType
            };
        }

        public static new LoginResponseDTO Error(string message)
        {
            return new()
            {
                Message = message,
                Success = false,
                AccessToken = null,
                TokenType = null
            };
        }
    }
}
