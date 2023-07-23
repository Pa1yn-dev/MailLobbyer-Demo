using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System.Threading.Tasks;
using MailLobbyer.ContactClass;
using Microsoft.AspNetCore.Components.Forms;
using MailLobbyer.FileUploadClass;
using MailLobbyer.SmtpClientSettingsClass;

namespace MailLobbyer.EmailHandlerComponent
{
    public class EmailHandler
    {

        public async Task EmailSyntaxHandler(SmtpClientSettings smtpclientsettings, string subject, string body, Contact contact, List<FileUpload> fileuploads)
        {
            string prefixsyntax = "/P";
            string fullnamesyntax = "/FN";
            string forenamesyntax = "/F";
            string surnamesyntax = "/S";

            subject = subject.Replace(prefixsyntax, contact.Prefix, StringComparison.OrdinalIgnoreCase)
                            .Replace(fullnamesyntax, string.Concat(contact.Forename, " ", contact.Surname), StringComparison.OrdinalIgnoreCase)
                            .Replace(forenamesyntax, contact.Forename, StringComparison.OrdinalIgnoreCase)
                            .Replace(surnamesyntax, contact.Surname, StringComparison.OrdinalIgnoreCase);
            
            body = body.Replace(prefixsyntax, contact.Prefix, StringComparison.OrdinalIgnoreCase)
                            .Replace(fullnamesyntax, string.Concat(contact.Forename, " ", contact.Surname), StringComparison.OrdinalIgnoreCase)
                            .Replace(forenamesyntax, contact.Forename, StringComparison.OrdinalIgnoreCase)
                            .Replace(surnamesyntax, contact.Surname, StringComparison.OrdinalIgnoreCase);
            
            await SendEmailAsync(smtpclientsettings,string.Concat(contact.Forename, " ", contact.Surname),contact.Email,subject,body,fileuploads);
        }

        public async Task SendEmailAsync(SmtpClientSettings smtpclientsettings, string RecipientName, string RecipientEmail, string subject, string body, List<FileUpload> fileuploads)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtpclientsettings.Sendername, smtpclientsettings.Senderemail));
            message.To.Add(new MailboxAddress(RecipientName, RecipientEmail));
            message.Subject = subject;

            var builder = new BodyBuilder();

            builder.TextBody = body;

            if(fileuploads.Any())
            {
                foreach (FileUpload fileupload in fileuploads)
                {
                    builder.Attachments.Add(fileupload.Filename, fileupload.Filecontents);
                }
            }

            message.Body = builder.ToMessageBody();
            //message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(smtpclientsettings.Host, smtpclientsettings.Port, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(smtpclientsettings.Username, smtpclientsettings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }

    }
}