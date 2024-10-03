using System.Net;
using System.Net.Mail;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces.NotificationServices;
using static Duende.IdentityServer.Models.IdentityResources;

namespace FlexBook.Infrastructure.Services.NotificationServices;
public class EmailProviderSender : IEmailProviderSender
{
    private readonly AppSettings _appSettings;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public EmailProviderSender(IOptions<AppSettings> appSettings, IWebHostEnvironment webHostEnvironment)
    {
        _appSettings = appSettings.Value;
        _webHostEnvironment = webHostEnvironment;
    }
    public async Task SendAsync(EmailMessage msg)
    {

        MailMessage message = new()
        {
            From = new MailAddress(_appSettings.Smtp.Username,displayName:_appSettings.Smtp.DisplayName),
            Body = msg.Body,
            Subject = msg.Subject,
            IsBodyHtml = true
        };

        message.To.Add(msg.EmailAddress);

        SmtpClient smtpClient = new(_appSettings.Smtp.Host)
        {
            Port = _appSettings.Smtp.Port,
            Credentials = new NetworkCredential(_appSettings.Smtp.Username, _appSettings.Smtp.Password),
            EnableSsl = true
        };

        await smtpClient.SendMailAsync(message);

        smtpClient.Dispose();



        //var smtpClient = new SmtpClient(_appSettings.Smtp.Host)
        //{
        //    DeliveryMethod = SmtpDeliveryMethod.Network,
        //    UseDefaultCredentials = false,

        //    Port = _appSettings.Smtp.Port,
        //    Credentials = new NetworkCredential(_appSettings.Smtp.Username, _appSettings.Smtp.Password),
        //    EnableSsl = true,
        //};
        //var mailMessage = new MailMessage
        //{
        //    From = new MailAddress(_appSettings.Smtp.FromEmail),
        //    Subject = "",
        //    Body = msg.Body,
        //    IsBodyHtml = true,
        //};
        //mailMessage.To.Add(msg.EmailAddress);
        //try
        //{

        //smtpClient.Send(mailMessage);
        //}
        //catch 
        //{

        //}
    }
}
