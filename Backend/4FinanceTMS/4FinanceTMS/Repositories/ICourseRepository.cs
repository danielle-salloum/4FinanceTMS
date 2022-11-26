using _4FinanceTMS.Models;

namespace _4FinanceTMS.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();
        Task<Course> GetAsync(Guid id);
        Task<Course> CreateCourseAsync(Course course);
        Task<Course> DeleteCourseAsync(Guid id);
        Task<Course> UpdateCourseAsync(Guid id, Course course);
    }
}
