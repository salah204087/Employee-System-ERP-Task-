using System.Net;

namespace EmployeeSystemERPTaskAPI.Model
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
    }
}
