using Microsoft.AspNetCore.Http;

namespace _4FinanceTMS.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }    
        public string Name { get; set; } = String.Empty; 
        public string Email { get; set; } = String.Empty;
        public string Speciality { get; set; } = String.Empty;  
        //Navigation Properties
        public IEnumerable<Course> Courses { get; set; }
    }
}
