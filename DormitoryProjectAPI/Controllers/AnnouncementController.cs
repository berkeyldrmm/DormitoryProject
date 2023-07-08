using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IUnitOfWork _unitOfWork;

        public AnnouncementController(IAnnouncementService announcementService, IUnitOfWork unitOfWork)
        {
            _announcementService = announcementService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAllAnnouncements()
        {
            var announcements = _announcementService.GetAll();
            return Ok(announcements);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetOneAnnouncementAsync(int id)
        {
            var announcement = await _announcementService.GetOne(id);
            if (announcement is not null)
            {
                return Ok(announcement);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> AddAnnouncement(Announcement announcement)
        {
            announcement.Date= DateTime.Now;
            if (ModelState.IsValid)
            {
                var result = await _announcementService.Create(announcement);
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
        public async Task<IActionResult> UpdateAnnouncementAsync(Announcement announcement)
        {
            announcement.Date= DateTime.Now;
            var result = _announcementService.Update(announcement);
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
        public async Task<IActionResult> DeleteAnnouncementById(int id)
        {
            try
            {
                var announcement = await _announcementService.GetOne(id);
                if (announcement is not null)
                {
                    var result = _announcementService.DeleteAsync(announcement);
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
    }
}
