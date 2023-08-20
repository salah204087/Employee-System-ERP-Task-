using System.Net;

namespace EmployeeSystemERPTaskWeb.Models
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; } = true;
        public HttpStatusCode StatusCode { get; set; }
        public List<string>? ErrorMessages { get; set; }
        public object? Result { get; set; }
    }
}
