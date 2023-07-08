using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Concrete;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;

        public RoomController(IRoomService roomService, IUnitOfWork unitOfWork)
        {
            _roomService = roomService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = _roomService.GetAll();
            return Ok(rooms);
        }

        [Route("students/{id}")]
        [HttpGet]
        public IActionResult GetRoomWithStudents(int id)
        {
            var rooms=_roomService.GetOneWithStudents(id);
            return Ok(rooms);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneRoomAsync(int id)
        {
            var room =await _roomService.GetOne(id);
            if(room is not null)
            {
                return Ok(room);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                var result = await _roomService.Create(room);
                if (result)
                {
                    int result2=await _unitOfWork.Save();
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
        public async Task<IActionResult> UpdateRoleAsync(Room room)
        {
            var result = _roomService.Update(room);
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
            throw new Exception("Bir hata oluştu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomById(int id)
        {
            try
            {
                var room=await _roomService.GetOne(id);
                if (room is not null)
                {
                    var result = _roomService.DeleteAsync(room);
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
