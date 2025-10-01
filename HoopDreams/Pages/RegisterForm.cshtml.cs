using HoopDreams.Models;
using HoopDreams.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;

namespace HoopDreams.Pages
{
    public class RegisterFormModel : PageModel
    {
        private readonly ILogger<RegisterFormModel> _logger;
        private readonly ClientsContext _context;
        private readonly EmailSettings _emailSettings;
        public bool Success { get; set; }

        [BindProperty]
        public FormEntity NewClient { get; set; }

        public RegisterFormModel(ILogger<RegisterFormModel> logger, ClientsContext context, IConfiguration config)
        {
            _logger = logger;
            _context = context;
            _emailSettings = config.GetSection("EmailSettings").Get<EmailSettings>();
        }

        private async Task SendEmailAsync(FormEntity client)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
            email.To.Add(MailboxAddress.Parse(_emailSettings.RecipientEmail));
            email.Subject = "New Client Registration";


            email.Body = new TextPart("plain")
            {
                Text = $@"
            New client registration:
            
            Name: {client.Name}
            Surname: {client.Surname}
            Phone: {client.PhoneNo}
            Email: {client.Email}"
            };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            await smtp.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FormEntities.Add(NewClient);
            await _context.SaveChangesAsync();

            await SendEmailAsync(NewClient); 

            return RedirectToPage("Success"); 
        }
    }
}
