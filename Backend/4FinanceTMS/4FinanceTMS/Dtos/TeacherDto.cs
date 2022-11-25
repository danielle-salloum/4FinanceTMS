namespace _4FinanceTMS.Dtos
{
    public class TeacherDto
    {
        public Guid TeacherId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Speciality { get; set; } = String.Empty;
    }
}
