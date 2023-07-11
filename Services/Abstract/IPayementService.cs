using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IPayementService : IGenericService<PaymentRecord>
    {
        public IEnumerable<AppUser> GetPaidStudentOfMonth(int monthId);
        public IEnumerable<MonthsForPay> GetPaymentsOfStudents(int studentId);
    }
}
