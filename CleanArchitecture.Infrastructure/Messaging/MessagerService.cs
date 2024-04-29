using CleanArchitecture.Application.Contracts.Infrastructure;
using CleanArchitecture.Application.Models;
using CleanArchitecture.Application.Options;
using CleanArchitecture.Domain.Common;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace CleanArchitecture.Infrastructure.Messaging
{
    public class MessagerService : IMessagerService
    {
        private readonly IOptions<SmtpOptions> _smtpOptions;

        public MessagerService(IOptions<SmtpOptions> smtpOptions)
        {
            _smtpOptions = smtpOptions;
        }


        public async Task<BaseResponse> SendEmailAsync(SendEmailAsyncDto sendEmailAsyncDto)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                var credentials = new NetworkCredential(_smtpOptions.Value.Sender, _smtpOptions.Value.Password);

                var mail = new MailMessage()
                {
                    From = new MailAddress(_smtpOptions.Value.Sender, _smtpOptions.Value.SenderName),
                    Subject = sendEmailAsyncDto.Subject,
                    Body = sendEmailAsyncDto.Message,
                    IsBodyHtml = true
                };

                mail.To.Add(new MailAddress(sendEmailAsyncDto.Email));

                var client = new SmtpClient()
                {
                    Port = _smtpOptions.Value.Port,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = _smtpOptions.Value.Host,
                    EnableSsl = _smtpOptions.Value.EnableSsl,
                    Credentials = credentials
                };

                await client.SendMailAsync(mail);
                return new BaseResponse(true, (int)System.Net.HttpStatusCode.OK, "Email Send Seccussfully");
            }
            catch (Exception ex)
            {
                return new BaseResponse(false, (int)System.Net.HttpStatusCode.BadRequest, ex.ToString());
            }
        }

    }
}
