namespace ChaveAutenticidadeTjRs.Core.Models
{
    public class Error
    {
        public Error(string? errorCode, string? errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }

        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}