using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class Suggestion_ComplaintRepository : GenericRepository<Suggestion_Complaint>, ISuggestion_ComplaintRepository
    {
        public Suggestion_ComplaintRepository(Context context) : base(context)
        {
        }
    }
}
