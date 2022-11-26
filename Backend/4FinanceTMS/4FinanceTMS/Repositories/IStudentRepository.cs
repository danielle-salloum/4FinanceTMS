using _4FinanceTMS.Models;

namespace _4FinanceTMS.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();
        Task<Student> GetAsync(Guid id);
        Task<Student> CreateStudentAsync(Student student);
        Task<Student> DeleteStudentAsync(Guid id);
        Task<Student> UpdateStudentAsync(Guid id, Student student);
    }
}
