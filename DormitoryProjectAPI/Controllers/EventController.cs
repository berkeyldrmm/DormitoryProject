using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEventParticipantService _eventParticipantService;
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork, IEventService eventService, IEventParticipantService eventParticipantService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
            _eventParticipantService = eventParticipantService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllEvents()
        {
            var _events = _eventService.GetAll();
            return Ok(_events);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetOneEventAsync(int id)
        {
            var _event = await _eventService.GetOne(id);
            if (_event is not null)
            {
                return Ok(_event);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddEvent(Event _event)
        {
            if (ModelState.IsValid)
            {
                _event.Date= DateTime.Now;
                var result = await _eventService.Create(_event);
                if (result)
                {
                    int result2 = await _unitOfWork.Save();
                    if (result2 == 1)
                    {
                        return Ok();
                    }
                    else
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> UpdateEventAsync(Event _event)
        {
            var result = _eventService.Update(_event);
            if (result)
            {
                int result2 = await _unitOfWork.Save();
                if (result2 == 1)
                {
                    return Ok();
                }
                throw new Exception("Bir hata oluştu.");

            }
            throw new Exception("Bir hata oluştu.");
        }

        [HttpDelete]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> DeleteEventById(int id)
        {
            try
            {
                var _event = await _eventService.GetOne(id);
                if (_event is not null)
                {
                    var result = _eventService.DeleteAsync(_event);
                    if (result)
                    {
                        int result2 = await _unitOfWork.Save();
                        if (result2 == 1)
                        {
                            return NoContent();
                        }
                        else
                        {
                            throw new Exception("Bir hata oluştu.");
                        }
                    }
                    else
                    {
                        throw new Exception("Bir hata oluştu.");
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [Route("geteventofstudent/{id:int}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetEventOfStudent(int id)
        {
            var events=_eventService.GetEventsOfStudent(id);
            if(events is null)
            {
                return NotFound();
            }
            List<Event> students = new List<Event>();
            foreach (var _event in events)
            {
                students.Add(_event.Event);
            }
            return Ok(students);
        }

        [Route("registerstudenttoevent")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterStudentToEventAsync(EventParticipant eventParticipant)
        {
            var events = _eventService.GetEventsOfStudent(eventParticipant.StudentId);
            foreach (var _event in events)
            {
                if(_event.StudentId == eventParticipant.StudentId && _event.EventId == eventParticipant.EventId)
                {
                    throw new Exception("Bu etkinliğe zaten kayıtlısınız.");
                }

            }
            var result = await _eventParticipantService.Create(eventParticipant);
            if (result)
            {
                await _unitOfWork.Save();
                return Ok();
            }
            throw new Exception("Bir hata oluştu, öğrenci kaydı oluşturulamadı.");
        }
    }
}
