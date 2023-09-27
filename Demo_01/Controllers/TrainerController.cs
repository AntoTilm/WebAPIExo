using Demo_01.DAL.Entities;
using Demo_01.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private TrainerRepository _TrainerRepository;

        public TrainerController(TrainerRepository trainerRepository)
        {
            _TrainerRepository = trainerRepository;
            //// 1 (mauvaise) facon d'injecter notre TrainerRepositoryà
            //_TrainerRepository = new TrainerRepository();
        }

        [HttpGet] //Permet de faire comprendre à swagger que la méthode ci dessous est une méthode get
        public IActionResult GetTrainers()
        {
            IEnumerable<Trainer> trainers = _TrainerRepository.GetAll();
            return Ok(trainers);
            //Demo avant qu'on mette la liste etou
            //return Ok(new { message = "Hello les .Net de Technobel" });
            //OU
            //retrun StatusCode(StatusCodes.Status200OK, "Hello les .Net de Technobel");
        }

        [HttpGet("{trainerId}")] 
        public IActionResult GetTrainer(int trainerId)
        {
            Trainer? trainer = _TrainerRepository.GetById(trainerId);
            if (trainer is null)
            {
                return NotFound();
            }
            return Ok(trainer);
        }
    }
}
