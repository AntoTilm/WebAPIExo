using Demo_01.DAL.Entities;
using Demo_01.DAL.Repositories;
using Demo_01.DTO;
using Demo_01.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private CourseRepository _CourseRepository;
        public CourseController(CourseRepository courseRepository)
        {
            _CourseRepository = courseRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Course>))]
        public IActionResult GetCourse()
        {
            IEnumerable<Course> courseList = _CourseRepository.GetAll();
            return Ok(courseList);

            // Demo avant qu'on mette la liste étou
            //return Ok(new { message = "Hello les .Net de Technobel" });
            //OU
            //return StatusCode(StatusCodes.Status200OK, "Hello les .Net de Technobel");
        }

        [HttpGet("{courseId:int:min(1)}")]
        //[ProducesResponseType(200, Type = typeof(Course))]
        //[ProducesResponseType(404)]
        public IActionResult GetCourse(int courseId)
        {
            Course? course = _CourseRepository.GetById(courseId);
            if (course is null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        //[HttpPost]
        //[ProducesResponseType(201, Type = typeof(Course))]
        //public IActionResult AddCourse(CourseDTO course)
        //{
            //Course courseToAdd = new Course
            //{
            //    Id = course.Id,
            //    Name = course.Name,
            //    Description = course.Description
            //};

            //Course courseAdded = _CourseRepository.Create(courseToAdd);

            // Renvoie d'une 201
            //return CreatedAtAction
            //    (
            //        nameof(GetTrainer), //string : nom de l'action à mettre dans le location
            //        new { trainerId = trainerAdded.Id }, //objet : contenant tous les paramètres dont la route a besoin (ici notre GetTrainer a besoin de trainerId)
            //        trainerAdded //objet : représente l'objet qui vient d'être crée (qui sera dans le body de la reponse)
            //    );
        //}

        //[HttpDelete("{trainerId:int}")]
        //[ProducesResponseType(204)]
        //[ProducesResponseType(404)]
        //public IActionResult DeleteTrainer(int trainerId)
        //{
        //    if (_TrainerRepository.Delete(trainerId))
        //    {
        //        return NoContent();
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPut("{trainerId:int}")]
        //[ProducesResponseType(501)]
        //public IActionResult UpdateTrainer(int trainerId, TrainerDTO trainer)
        //{
        //    return StatusCode(StatusCodes.Status501NotImplemented, new { reason = "Flemme" });
        //}
    }
}
