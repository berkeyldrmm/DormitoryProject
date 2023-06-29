using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Suggestion_Complaint
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int Suggestion_ComplanintId { get; set; }
        public AppUser Complainant_Recommender { get; set; }
    }
}
