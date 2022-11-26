using _4FinanceTMS.Data;
using _4FinanceTMS.Models;
using AutoMapper.Configuration.Annotations;
using Microsoft.EntityFrameworkCore;

namespace _4FinanceTMS.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly TMSDbContext _TMSDbContext;
        public CourseRepository(TMSDbContext tMSDbContext)
        {
            this._TMSDbContext = tMSDbContext;
        }
    
        public async Task<Course> CreateCourseAsync(Course course)
        {
            course.Id = new Guid();
            await _TMSDbContext.Courses.AddAsync(course);
            await _TMSDbContext.SaveChangesAsync();
            return (course);

        }

        public async Task<Course> DeleteCourseAsync(Guid id)
        {
            var course = await _TMSDbContext.Courses.FirstOrDefaultAsync(course => course.Id == id);
            if(course == null)
            {
                return null;
            }
            _TMSDbContext.Courses.Remove(course);
            await _TMSDbContext.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _TMSDbContext.Courses.ToListAsync();
        }

        public  async Task<Course> GetAsync(Guid id)
        {
            return await _TMSDbContext.Courses.FirstOrDefaultAsync(course => course.Id == id);
        }

        public async Task<Course> UpdateCourseAsync(Guid id, Course course)
        {
            var existingcourse = await _TMSDbContext.Courses.FirstOrDefaultAsync(course => course.Id == id);
            if (existingcourse == null)
            {
                return null;
            }
            existingcourse.Name=course.Name;    
            existingcourse.Description=course.Description;
            existingcourse.CreditNumber=course.CreditNumber;
            await _TMSDbContext.SaveChangesAsync(); 
            return existingcourse;
        }
    }
}
