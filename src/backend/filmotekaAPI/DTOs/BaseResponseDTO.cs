namespace filmotekaAPI.DTOs
{
    public class BaseResponseDTO
    {
        public string? Message { get; init; }
        public bool Success { get; init; }

        public static BaseResponseDTO Ok(string? message = null)
        {
            return new() { Message = message, Success = true };
        }

        public static BaseResponseDTO Error(string? message = null)
        {
            return new() { Message = message, Success = false };
        }
    }
}
