﻿using DataAccess.Abstract;
using Entities.Concrete;
using IdentityProject.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace DormitoryProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailConfirmController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public MailConfirmController(UserManager<AppUser> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }

        [Route("sendconfirmcode")]
        [HttpPost]
        public IActionResult SendConfirmCode(AppUser user)
        {
            if(user is null)
            {
                return NotFound();
            }
            try
            {
                Random random = new Random();
                int code = random.Next(100000, 1000000);
                user.ConfirmCode = code;
                using MimeMessage mimeMessage = new MimeMessage();
                MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "berke.yildirimm44@gmail.com");
                MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);
                mimeMessage.From.Add(mailboxAddressFrom);
                mimeMessage.To.Add(mailboxAddressTo);

                BodyBuilder bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = "Doğrulama kodu : " + user.ConfirmCode;
                mimeMessage.Body = bodyBuilder.ToMessageBody();
                mimeMessage.Subject = "Uygulama mail doğrulama kodu";

                using SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("berke.yildirimm44@gmail.com", "rcertnrinytvjzxc");
                client.Send(mimeMessage);
                client.Disconnect(true);
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
        }

        [Route("confirmmail")]
        [HttpPost]
        public async Task<IActionResult> ConfirmCodeandEmailAsync(ConfirmCodeDTO confirmCodeDto)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(confirmCodeDto.Mail);
                if (user.ConfirmCode == confirmCodeDto.ConfirmCode)
                {
                    user.EmailConfirmed = true;
                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.Save();
                }
                return Ok();
            }
            catch (Exception)
            {
                throw new Exception("Bir hata oluştu.");
            }
            
        }
    }
}
