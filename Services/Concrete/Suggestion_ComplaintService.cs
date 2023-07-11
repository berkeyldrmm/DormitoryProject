using AutoMapper;
using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class Suggestion_ComplaintService : ISuggestion_ComplaintService
    {
        private readonly ISuggestion_ComplaintRepository _suggestionComplaintRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStudentService _studentService;
        public Suggestion_ComplaintService(ISuggestion_ComplaintRepository suggestionComplaintRepository, IMapper mapper, UserManager<AppUser> userManager, IStudentService studentService)
        {
            _suggestionComplaintRepository = suggestionComplaintRepository;
            _mapper = mapper;
            _userManager = userManager;
            _studentService = studentService;
        }
        public async Task<bool> Create(Suggestion_Complaint entity)
        {
            entity.Date= DateTime.Now;
            return await _suggestionComplaintRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<Suggestion_Complaint> entity)
        {
            await _suggestionComplaintRepository.AddRangeAsync(entity);
        }

        public bool DeleteAsync(Suggestion_Complaint entity)
        {
            return _suggestionComplaintRepository.Delete(entity);
        }

        public void DeleteRange(IEnumerable<Suggestion_Complaint> entity)
        {
            _suggestionComplaintRepository.DeleteRange(entity);
        }

        public IEnumerable<Suggestion_Complaint> GetAll()
        {
            return _suggestionComplaintRepository.GetAll().ToList();
        }

        public IEnumerable<Suggestion_Complaint> GetByCondition(Expression<Func<Suggestion_Complaint, bool>> expression)
        {
            return _suggestionComplaintRepository.GetByCondition(expression).ToList();
        }

        public async Task<Suggestion_Complaint> GetOne(int id)
        {
            return await _suggestionComplaintRepository.GetOneById(id);
        }

        public bool Update(Suggestion_Complaint entity)
        {
            return _suggestionComplaintRepository.Update(entity);
        }

        public void UpdateRange(IEnumerable<Suggestion_Complaint> entity)
        {
            _suggestionComplaintRepository.UpdateRange(entity);
        }

        public async Task AddSuggestionsToStudentAsync(Suggestion_Complaint suggestion)
        {
            AppUser user = await _userManager.FindByIdAsync(suggestion.StudentId.ToString());
            user.Suggestions_Complaints.Add(suggestion);
            await _userManager.UpdateAsync(user);
        }
        public IEnumerable<Suggestion_Complaint> GetSuggestionsOfStudent(int id)
        {
            var student=_studentService.GetStudentWithSuggestions(id);
            if(student is null)
            {
                throw new DirectoryNotFoundException("Öğrenci kaydı bulunamadı.");
            }
            return student.Suggestions_Complaints;
        }
    }
}
