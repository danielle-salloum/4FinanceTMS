using _4FinanceTMS.Data;
using _4FinanceTMS.Models;
using Microsoft.EntityFrameworkCore;

namespace _4FinanceTMS.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        //instance from the TMSDbContext
        private readonly TMSDbContext _TMSDbContext;
        //constructor that inject the _TMSDbContext in the class
        public StudentRepository(TMSDbContext tmsDbContext)
        {
            this._TMSDbContext = tmsDbContext;
        }


        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _TMSDbContext.Students.ToListAsync();
        }

        public async Task<Student> GetAsync(Guid id)
        {
            return await _TMSDbContext.Students.FirstOrDefaultAsync(student => student.Id == id);
        }
        public async Task<Student> DeleteStudentAsync(Guid id)
        {
            var student = await _TMSDbContext.Students.FirstOrDefaultAsync(student => student.Id == id);
            if (student == null)
            {
                return null;
            }
            _TMSDbContext.Students.Remove(student);
            await _TMSDbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            
                student.Id = new Guid();
                await _TMSDbContext.Students.AddAsync(student);
                await _TMSDbContext.SaveChangesAsync();
                return (student);
            

        }

        public async Task<Student> UpdateStudentAsync(Guid id, Student student)
        {
            var existingstudent = await _TMSDbContext.Students.FirstOrDefaultAsync(student => student.Id == id);
            if (existingstudent == null)
            {
                return null;
            }
            existingstudent.Name=student.Name;
            existingstudent.Email=student.Email;
            existingstudent.Major=student.Major;    
            await _TMSDbContext.SaveChangesAsync();
            return existingstudent;
            
        }
    }
      
}
