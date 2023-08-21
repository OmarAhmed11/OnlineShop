namespace OnlineShop.Errors
{
    public class ApiResponse
    {

        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }


        public int StatusCode { get; set; }
        public string Message { get; set; }


        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A Bad Request",
                401 => "Authorized, You Are Not",
                404 => "Resource Found, it was not",
                500 => "Errors are the path to the dark side",
                _ => null

            };
        }
    }
}
