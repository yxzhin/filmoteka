namespace filmotekaAPI.DTOs
{
    public class KorisnikServiceLoginDTO : BaseResponseDTO
    {
        public string? AccessToken { get; init; }
        public string? TokenType { get; init; }

        public static KorisnikServiceLoginDTO Ok(
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

        public static new KorisnikServiceLoginDTO Error(string message)
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
