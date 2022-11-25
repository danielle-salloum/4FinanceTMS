using _4FinanceTMS.InputModels;
using _4FinanceTMS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _4FinanceTMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        public CoursesController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            //get all teachers from database using repository
            var Courses = await courseRepository.GetAllAsync();

            //declare a teacher dto list to return it to the user
            var coursesDto = new List<Dtos.CourseDto>();

            //loop over the teachers model
            Courses.ToList().ForEach(course =>
            {
                //create a teacher dto and fill it from the teacher model
                var courseDto = new Dtos.CourseDto()
                {
                    CourseId = course.Id,
                    Name = course.Name,
                    CreditNumber = course.CreditNumber,
                    Description = course.Description,
                };

                //add each teacher dto to the teachersDto List
                coursesDto.Add(courseDto);
            });
            return Ok(coursesDto);
        }
        //end point 
        [HttpGet("{id:guid}")]
        [ActionName("GetCourseAsync")]
        public async Task<IActionResult> GetCourseAsync(Guid id)
        {
            //use the repository
            var course = await courseRepository.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            //mapping
            var courseDto = new Dtos.CourseDto()
            {
                CourseId = course.Id,
                Name = course.Name,
                CreditNumber = course.CreditNumber,
                Description = course.Description,
            };
            return Ok(courseDto);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseInputModel createCourseInputModel)
        {
            var course = new Models.Course()
            {
                Name = createCourseInputModel.Name,
                CreditNumber = createCourseInputModel.CreditNumber,
                Description=createCourseInputModel.Description,
            };
            course = await courseRepository.CreateCourseAsync(course);
            var courseDto = new Dtos.CourseDto
            {
                CourseId = course.Id,
                Name = course.Name,
                CreditNumber = course.CreditNumber,
                Description = course.Description,
            };
            return CreatedAtAction(
                nameof(GetCourseAsync),
                new { id = courseDto.CourseId },
                courseDto
                );
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCourseAsync(Guid id)
        {
            var course = await courseRepository.DeleteCourseAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            var courseDto = new Dtos.CourseDto
            {
                CourseId = course.Id,
                Name = course.Name,
                CreditNumber = course.CreditNumber,
                Description = course.Description,
            };
            return Ok(courseDto);
        }
    }
}
