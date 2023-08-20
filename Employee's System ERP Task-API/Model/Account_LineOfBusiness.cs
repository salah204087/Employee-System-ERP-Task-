namespace EmployeeSystemERPTaskAPI.Model
{
    public class Account_LineOfBusiness
    {
        public int AccountId { get; set; }
        public Account? Account { get; set; }
        public int LineOfBusinessId { get; set; }
        public LineOfBusiness? LineOfBusiness { get; set; }
        public string? LineOfBusinessName { get; set; }
    }
}
