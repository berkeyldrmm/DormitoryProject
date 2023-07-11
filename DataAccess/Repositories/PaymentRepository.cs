using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class PaymentRepository : GenericRepository<PaymentRecord>, IPaymentRepository
    {
        public PaymentRepository(Context context) : base(context)
        {
        }
        public IQueryable<PaymentRecord> Payment => Entity.Include(r => r.Student).Include(r => r.Month);
        public IQueryable<PaymentRecord> GetPaymentRecordsOfStudent(int studentId)
        {
            return Payment.Where(r=>r.StudentId==studentId).AsQueryable();
        }
        public IQueryable<PaymentRecord> GetPaidStudentsOfMonth(int monthId)
        {
            return Payment.Where(r => r.MonthId == monthId).AsQueryable();
        }
    }
}
