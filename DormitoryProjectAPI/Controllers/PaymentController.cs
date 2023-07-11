using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstract;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPayementService _paymentService;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentController(IPayementService paymentService, IUnitOfWork unitOfWork)
        {
            _paymentService = paymentService;
            _unitOfWork = unitOfWork;
        }

        [Route("getpaidstudentsofmonths/{monthId:int}")]
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetPaidStudentOfMonth(int monthId)
        {
            try
            {
                var students = _paymentService.GetPaidStudentOfMonth(monthId);
                return Ok(students);
            }
            catch (Exception err)
            {
                if(err as DirectoryNotFoundException is not null)
                {
                    return NotFound();
                }
                throw err;
            }
        }

        [Route("getpaymentsofstudent/{studentId:int}")]
        [HttpGet]
        [Authorize]
        public IActionResult GetPaymentsOfStudent(int studentId)
        {
            try
            {
                var payments = _paymentService.GetPaymentsOfStudents(studentId);
                return Ok(payments);
            }
            catch (Exception err)
            {
                if (err as DirectoryNotFoundException is not null)
                {
                    return NotFound();
                }
                throw err;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPaymentRecordAsync(PaymentRecord paymentRecord)
        {
            paymentRecord.Date = DateTime.Now;
            var paymentrecords = _paymentService.GetAll();
            foreach (var record in paymentrecords)
            {
                if (record.StudentId == paymentRecord.StudentId && record.MonthId == paymentRecord.MonthId)
                {
                    throw new Exception("Bu ödeme zaten yapıldı.");
                }
            }
            var result=await _paymentService.Create(paymentRecord);
            if (result)
            {
                await _unitOfWork.Save();
                return Ok();
            }
            throw new Exception("Bir hata oluştu.");
        }
    }
}
