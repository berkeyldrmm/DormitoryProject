using DataAccess.Abstract;
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
    public class PaymentService : IPayementService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> Create(PaymentRecord entity)
        {
            var result = await _paymentRepository.AddAsync(entity);
            return result;
        }

        public Task CreateRange(IEnumerable<PaymentRecord> entity)
        {
            throw new NotImplementedException();
        }

        public bool DeleteAsync(PaymentRecord entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteRange(IEnumerable<PaymentRecord> entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            return _paymentRepository.GetAll();
        }

        public IEnumerable<PaymentRecord> GetByCondition(Expression<Func<PaymentRecord, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentRecord> GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(PaymentRecord entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<PaymentRecord> entity)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AppUser> GetPaidStudentOfMonth(int monthId)
        {
            var records=_paymentRepository.GetPaidStudentsOfMonth(monthId);
            if(records is null)
            {
                throw new DirectoryNotFoundException();
            }
            List<AppUser> paidstudents =new List<AppUser>();
            foreach (var record in records)
            {
                paidstudents.Add(record.Student);
            }
            return paidstudents;
        }
        public IEnumerable<MonthsForPay> GetPaymentsOfStudents(int studentId)
        {
            var records = _paymentRepository.GetPaymentRecordsOfStudent(studentId);
            if (records is null)
            {
                throw new DirectoryNotFoundException();
            }
            List<MonthsForPay> payments = new List<MonthsForPay>();
            foreach (var record in records)
            {
                payments.Add(record.Month);
            }
            return payments;
        }
    }
}
