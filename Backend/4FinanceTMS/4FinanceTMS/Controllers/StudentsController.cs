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
        public StudentsController(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await studentRepository.GetAllAsync();

            var studentsDto = new List<Dtos.StudentDto>();

            students.ToList().ForEach(student =>
            {
               
                var studentDto = new Dtos.StudentDto()
                {
                    StudentId = student.Id,
                    Name = student.Name,
                    Email = student.Major,
                };

                studentsDto.Add(studentDto);
            });
            return Ok(studentsDto);
        }
        //end point 
        [HttpGet("{id:guid}")]
        [ActionName("GetStudentAsync")]
        public async Task<IActionResult> GetStudentAsync(Guid id)
        {
            var student = await studentRepository.GetAsync(id);
            if (student == null)
            {
                return NotFound();
            }
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
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid id, [FromBody] UpdateStudentInputModel updateStudentInputModel)
        {
            var student = new Models.Student()
            {
                Name = updateStudentInputModel.Name,
                Major = updateStudentInputModel.Major,
            };
            student = await studentRepository.UpdateStudentAsync(id, student);

            if (student == null)
            {
                return NotFound();
            }
            var studentDto = new Dtos.StudentDto
            {
                StudentId = student.Id,
                Name = student.Name,
                Email = student.Email,
                Major = student.Major,
            };
            return Ok(studentDto);
        }
    }
}
