using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TeacherStudent.ServiceContract;
using TeacherStudent.ModelClasses;
using System.Threading.Tasks;

namespace TeacherStudent.Services
{
    public class Email : IEmail
    {
        public async Task<bool> SendEmail(string name)
        {
            try
            {
                using (MailMessage mm = new MailMessage("Jitendra <jeetsharma8390@gmail.com>", "jeetusharma.jee@gmail.com"))
                {
                    mm.Subject = "Registration Successful!!";
                    mm.Body = name + " is registered successfully!!";
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("jeetsharma8390@gmail.com", "Sh123Jeetxxx@$");
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    await smtp.SendMailAsync(mm);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}