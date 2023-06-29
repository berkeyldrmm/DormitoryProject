using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class MonthsForPay
    {
        public MonthsForPay()
        {
            PaymentRecords=new HashSet<PaymentRecord>();
        }
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal Cost { get; set; }
        public DateTime ExpiresDate { get; set; }
        public ICollection<PaymentRecord> PaymentRecords { get; set; } 
    }
}
