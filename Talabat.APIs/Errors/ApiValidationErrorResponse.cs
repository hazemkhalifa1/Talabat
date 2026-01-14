namespace Talabat.APIs.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public List<string> Errors { get; set; }
        public ApiValidationErrorResponse(List<string> errors) : base(400)
        {
            Errors = errors;
        }
    }
}
