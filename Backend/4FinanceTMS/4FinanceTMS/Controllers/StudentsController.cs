using _4FinanceTMS.InputModels;
using _4FinanceTMS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4FinanceTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        //constructor to inject the teacherRepository in the class
        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            //get all teachers from database using repository
            var students = await studentRepository.GetAllAsync();

            //declare a teacher dto list to return it to the user
            var studentsDto = new List<Dtos.StudentDto>();

            //loop over the teachers model
            students.ToList().ForEach(student =>
            {
                //create a teacher dto and fill it from the teacher model
                var studentDto = new Dtos.StudentDto()
                {
                    StudentId = student.Id,
                    Name = student.Name,
                    Email = student.Major,
                };

                //add each teacher dto to the teachersDto List
                studentsDto.Add(studentDto);
            });
            return Ok(studentsDto);
        }
        //end point 
        [HttpGet("{id:guid}")]
        [ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync(Guid id)
        {
            //use the repository
            var student = await studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            //mapping
            var studentDto = new Dtos.StudentDto()
            {
                StudentId = student.Id,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
            };
            return Ok(studentDto);

        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentInputModel createStudentInputModel)
        {
            var student = new Models.Student()
            {
                Name = createStudentInputModel.Name,
                Email = createStudentInputModel.Email,
                Major = createStudentInputModel.Major
            };
            student = await studentRepository.CreateStudentAsync(student);
            var studentDto = new Dtos.StudentDto
            {
                StudentId = student.Id,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
            };
            return CreatedAtAction(
                nameof(GetStudentAsync),
                new { id = studentDto.StudentId },
                studentDto
                );
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudentAsync(Guid id)
        {
            var student = await studentRepository.DeleteStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            var studentDto = new Dtos.StudentDto
            {
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
            };
            return Ok(studentDto);
        }
    }
}
