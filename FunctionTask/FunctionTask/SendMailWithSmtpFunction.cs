using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;

public static class SendMailWithSmtpFunction
{
    [Function("SendMailWithSmtpFunction")]
    public static async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var data = JsonConvert.DeserializeObject<EmailRequest>(requestBody);

        if (data == null || string.IsNullOrWhiteSpace(data.Email) || string.IsNullOrWhiteSpace(data.Name))
        {
            return new BadRequestObjectResult("Invalid name or email.");
        }

        var smtpHost = Environment.GetEnvironmentVariable("SmtpHost");
        var smtpPort = int.Parse(Environment.GetEnvironmentVariable("SmtpPort") ?? "587");
        var smtpUser = Environment.GetEnvironmentVariable("SmtpUser");
        var smtpPass = Environment.GetEnvironmentVariable("SmtpPass");
        var fromEmail = Environment.GetEnvironmentVariable("FromEmail");

        try
        {
            var message = new MailMessage();
            message.From = new MailAddress(fromEmail, "Azure Function");
            message.To.Add(new MailAddress(data.Email));
            message.Subject = "Message from AzureFunction";
            message.Body = $"Salam {data.Name}, bu email Azure tərəfindən göndərildi.";

            using (var smtpClient = new SmtpClient(smtpHost, smtpPort))
            {
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential(smtpUser, smtpPass);
                await smtpClient.SendMailAsync(message);
            }

            return new OkObjectResult("Mail successfully sent.");
        }
        catch (System.Exception ex)
        {
            log.LogError($"Error sending mail: {ex.Message}");
            return new StatusCodeResult(500);
        }
    }

    public class EmailRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
