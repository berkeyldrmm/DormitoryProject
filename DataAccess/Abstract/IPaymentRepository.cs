using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IPaymentRepository : IGenericRepository<PaymentRecord>
    {
        public IQueryable<PaymentRecord> Payment { get; }
        public IQueryable<PaymentRecord> GetPaymentRecordsOfStudent(int studentId);
        public IQueryable<PaymentRecord> GetPaidStudentsOfMonth(int monthId);
    }
}
