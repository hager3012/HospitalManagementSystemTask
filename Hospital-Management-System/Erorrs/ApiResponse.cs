namespace Hospital_Management_System.Erorrs
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        private string? GetDefaultMessage(int statusCode)
        {
            return statusCode switch
            {
                404 => "Resource was not found",
                400 => "A bad Request",
                401 => "Not Authroized",
                500 => "Errors are the path in the server side"
            };
        }
    }
}
