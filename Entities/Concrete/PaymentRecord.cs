using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PaymentRecord
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public AppUser? Student { get; set; }
        public int MonthId { get; set; }
        public MonthsForPay? Month { get; set; }
        public DateTime Date { get; set; }
    }
}
