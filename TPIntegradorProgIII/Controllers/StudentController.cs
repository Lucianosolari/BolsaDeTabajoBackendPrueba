// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TPIntegradorProgIII.Data.Repository.Interfaces;
using TPIntegradorProgIII.Entities;
using TPIntegradorProgIII.Models;

namespace TPIntegradorProgIII.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {

        private readonly IStudentRepository _swimmerRepository;

        public StudentController(IStudentRepository swimmerRepository)
        {
            _swimmerRepository = swimmerRepository;
        }

        [HttpGet]
        [Route("getAllSwimmers")]
        public IActionResult GetAllSwimmers()
        {
            try
            {
                List<StudentResponse> swimmersToReturn = new();
                List<Student> swimmers = _swimmerRepository.GetSwimmers();
                foreach (var swimmer in swimmers)
                {
                    swimmer.AttendedTrial = _swimmerRepository.GetAttendedTrial(swimmer.TrialId);
                    StudentResponse response = new()
                        {
                            Id = swimmer.Id,
                            Name = swimmer.Name,
                            Surname = swimmer.Surname,
                            UserName = swimmer.UserName,
                            DNI = swimmer.DNI,
                            Email = swimmer.Email,
                            AttendedTrial = swimmer.AttendedTrial,
                        };
                    swimmersToReturn.Add(response);
                }
                return Ok(swimmersToReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("getSwimmerById/{id}")]
        public IActionResult GetSwimmerById(int id)
        {
            try
            {
                Student? swimmer = _swimmerRepository.GetSingleSwimmer(id);
                swimmer.AttendedTrial = _swimmerRepository.GetAttendedTrial(swimmer.TrialId);
                StudentResponse response = new()
                {
                    Id = swimmer.Id,
                    Name = swimmer.Name,
                    Surname = swimmer.Surname,
                    UserName = swimmer.UserName,
                    DNI = swimmer.DNI,
                    Email = swimmer.Email,
                    AttendedTrial = swimmer.AttendedTrial
                };
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("createSwimmer")]
        public IActionResult CreateSwimmer(AddStudentRequest request)
        {
            try
            {
                List<Offer> trials = _swimmerRepository.GetExistingTrials();
                ValidateTrialId(trials, request.TrialId);

                List<Student> swimmers = _swimmerRepository.GetSwimmers();
                ValidateUsername(swimmers, request.UserName);
                ValidateDNI(swimmers, request.DNI);
                Student newSwimmer = new()
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    UserName = request.UserName,
                    DNI = request.DNI,
                    Password = request.Password,
                    Email = request.Email,
                    TrialId = request.TrialId
                };
                newSwimmer.AttendedTrial = _swimmerRepository.GetAttendedTrial(newSwimmer.TrialId);
                StudentResponse response = new()
                {
                    Id = newSwimmer.Id,
                    Name = newSwimmer.Name,
                    Surname = newSwimmer.Surname,
                    UserName = newSwimmer.UserName,
                    DNI = newSwimmer.DNI,
                    Email = newSwimmer.Email,
                    AttendedTrial = newSwimmer.AttendedTrial
                };
                _swimmerRepository.AddSwimmer(newSwimmer);
                return Created("Nadador creado", response);
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteSwimmer/{id}")]
        public IActionResult DeleteSwimmer(int id)
        {
            try
            {
                _swimmerRepository.RemoveSwimmer(id);
                return Ok("Nadador borrado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySwimmerName/{id}/{newName}")]
        public IActionResult ModifySwimmerName(int id, string newName)
        {
            try
            {
                _swimmerRepository.EditSwimmerName(id, newName);
                return Ok("Nombre editado");
            }
            catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [HttpPut]
        [Route("modifySwimmerSurname/{id}/{newSurname}")]
        public IActionResult ModifySwimmerSurname(int id, string newSurname)
        {
            try
            {
                _swimmerRepository.EditSwimmerSurname(id, newSurname);
                return Ok("Apellido editado");
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [NonAction]
        public void ValidateUsername(List<Student> swimmers, string username)
        {
            var inUser = swimmers.FirstOrDefault(s => s.UserName == username);
            if (inUser != null)
            {
                throw new Exception("UserName ya utilizado, elija otro");
            }
        }

        [NonAction]
        public void ValidateDNI(List<Student> swimmers, int DNI)
        {
            var inUse = swimmers.FirstOrDefault(s => s.DNI == DNI);
            if (inUse != null)
            {
                throw new Exception("DNI ya registrado");
            }
        }

        [NonAction]
        public void ValidateTrialId(List<Offer> trials, int trialId)
        {
            var trialExists = trials.FirstOrDefault(m => m.Id == trialId);
            if (trialExists == null)
            {
                throw new Exception("Trial no encontrado, revisar Id.");
            }
        }
    }
}
