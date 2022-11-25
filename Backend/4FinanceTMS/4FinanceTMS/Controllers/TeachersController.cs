using _4FinanceTMS.Data;
using _4FinanceTMS.InputModels;
using _4FinanceTMS.Models;
using _4FinanceTMS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4FinanceTMS.Controllers
{
    //decorations
    [Route("[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase

    {
        //create an instance from the repository interface
        private readonly ITeacherRepository teacherRepository;
        //constructor to inject the teacherRepository in the class
        public TeachersController(ITeacherRepository teacherRepository)
        {
            this.teacherRepository = teacherRepository;
        }

        //end point
        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            //get all teachers from database using repository
            var teachers = await teacherRepository.GetAllAsync();

            //declare a teacher dto list to return it to the user
            var teachersDto = new List<Dtos.TeacherDto>();

            //loop over the teachers model
            teachers.ToList().ForEach(teacher =>
            {
                //create a teacher dto and fill it from the teacher model
                var teacherDto = new Dtos.TeacherDto()
                {
                    TeacherId = teacher.Id,
                    Name = teacher.Name,
                    Email = teacher.Email,
                    Speciality = teacher.Speciality,
                };

                //add each teacher dto to the teachersDto List
                teachersDto.Add(teacherDto);
            });
            return Ok(teachersDto);
        }

        //end point 
        [HttpGet("{id:guid}")]
        [ActionName("GetTeacherAsync")]
        public async Task<IActionResult> GetTeacherAsync(Guid id)
        {
            //use the repository
            var teacher = await teacherRepository.GetAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            //mapping
            var teacherDto = new Dtos.TeacherDto()
            {
                TeacherId = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Speciality = teacher.Speciality,
            };
            return Ok(teacherDto);

        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherInputModel createTeacherInputModel)
        {
            var teacher = new Models.Teacher()
            {
                Name = createTeacherInputModel.Name,
                Email = createTeacherInputModel.Email,
                Speciality = createTeacherInputModel.Speciality
            };
            teacher = await teacherRepository.CreateTeacherAsync(teacher);
            var teacherDto = new Dtos.TeacherDto
            {
                TeacherId = teacher.Id,
                Name = teacher.Name,
                Email = teacher.Email,
                Speciality = teacher.Speciality,
            };
            return CreatedAtAction(
                nameof(GetTeacherAsync),
                new { id = teacherDto.TeacherId },
                teacherDto
                );
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTeacherAsync(Guid id)
        {
            var teacher = await teacherRepository.DeleteTeacherAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            var teacherDto = new Dtos.TeacherDto
            {
                Name = teacher.Name,
                Email = teacher.Email,
                Speciality = teacher.Speciality,
            };
            return Ok(teacherDto);
        }
        [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTeacherAsync([FromRoute]Guid id,[FromBody] UpdateTeacherInputModel updateTeacherInputModel)
    {
        //convert DTO to model
        var teacher = new Models.Teacher()
        {
            Name = updateTeacherInputModel.Name,
            Speciality = updateTeacherInputModel.Speciality,
        };
        //update Teacher using teacher depository
        teacher = await teacherRepository.UpdateTeacherAsync(id, teacher);
        //if null return not found
        if(teacher == null)
        {
            return NotFound();
        }
        //comvert from model back to DTB
        var teacherDto = new Dtos.TeacherDto
        {
            TeacherId=teacher.Id,
            Name = teacher.Name,
            Email = teacher.Email,
            Speciality = teacher.Speciality,
        };
        return Ok(teacherDto);
    }
}
}
