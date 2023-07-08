using DataAccess.Abstract;
using DTOs.Suggestion_ComplaintsDTOs;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;
using Services.Concrete;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestion_ComplaintService _suggestionService;
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;
        public SuggestionsController(ISuggestion_ComplaintService suggestionService, IStudentService studentService, IUnitOfWork unitOfWork)
        {
            _suggestionService = suggestionService;
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetSuggestions()
        {
            try
            {
                var suggesitons = _suggestionService.GetAll();
                return Ok(suggesitons);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSuggestionByIdAsync(int id)
        {
            try
            {
                var user = await _suggestionService.GetOne(id);
                if (user is null)
                {
                    return BadRequest();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSuggestion(Suggestion_Complaint suggestion)
        {
            if (ModelState.IsValid)
            {
                var result = await _suggestionService.Create(suggestion);
                if (result)
                {
                    await _studentService.AddSuggestionsToStudentAsync(suggestion);
                    await _unitOfWork.Save();
                    return Ok();
                }
                else
                {
                    throw new Exception("Bir hata oluştu.");
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSuggestion(Suggestion_Complaint suggestion)
        {
            suggestion.Date = DateTime.Now;
            var result = _suggestionService.Update(suggestion);
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
        public async Task<IActionResult> DeleteSuggestionByIdAsync(int id)
        {
            try
            {
                var suggestion = await _suggestionService.GetOne(id);
                if (suggestion is not null)
                {
                    var result = _suggestionService.DeleteAsync(suggestion);
                    if (result)
                    {
                        return NoContent();
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
