using EmployeeSystemERPTaskWeb.Model;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskWeb.Model.DTO
{
    public class BaseEmployeeDTO
    {
        [Required]
        [Min18YearsOld]
        public DateTime? BirthDate { get; set; }
    }
}
