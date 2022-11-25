namespace _4FinanceTMS.InputModels
{
    public class CreateCourseInputModel
    {
        public int CreditNumber { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
