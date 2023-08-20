using System.ComponentModel.DataAnnotations;

namespace EmployeeSystemERPTaskAPI.Model.DTO
{
    public class BaseEmployeeDTO
    {
        [Required]
        [Min18YearsOld]
        public DateTime? BirthDate { get; set; }
    }
}
