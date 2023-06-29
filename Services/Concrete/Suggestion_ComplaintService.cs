using DataAccess.Abstract;
using DataAccess.Repositories;
using Entities.Concrete;
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
        public Suggestion_ComplaintService(ISuggestion_ComplaintRepository suggestionComplaintRepository)
        {
            _suggestionComplaintRepository = suggestionComplaintRepository;
        }
        public async Task<bool> Create(Suggestion_Complaint entity)
        {
            return await _suggestionComplaintRepository.AddAsync(entity);
        }

        public async Task CreateRange(IEnumerable<Suggestion_Complaint> entity)
        {
            await _suggestionComplaintRepository.AddRangeAsync(entity);
        }

        public bool Delete(Suggestion_Complaint entity)
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
    }
}
