using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface ISuggestion_ComplaintService : IGenericService<Suggestion_Complaint>
    {
        public Task AddSuggestionsToStudentAsync(Suggestion_Complaint suggestion);
        public IEnumerable<Suggestion_Complaint> GetSuggestionsOfStudent(int id);
    }
}
