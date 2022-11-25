namespace _4FinanceTMS.Dtos
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public int CreditNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
