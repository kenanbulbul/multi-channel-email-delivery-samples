using Azure.Identity;
using Graph.Mail.Send.Sample;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using System.Text.Json;

// 1️⃣ Load configuration
var settings = LoadSettings();

// 2️⃣ Create a credential using Azure.Identity
var credential = new ClientSecretCredential(
    settings.AzureAd.TenantId,
    settings.AzureAd.ClientId,
    settings.AzureAd.ClientSecret
);

// 3️- Initialize Graph client with modern authentication
var graphClient = new GraphServiceClient(credential, new[] { "https://graph.microsoft.com/.default" });


// 4️- Build the email message
var message = new Message
{
    Subject = "Graph API Mail Test",
    Body = new ItemBody
    {
        ContentType = BodyType.Text,
        Content = "This email was sent using Microsoft Graph API via application permissions (OAuth2)."
    },
    ToRecipients = new List<Recipient>
    {
        new Recipient
        {
            EmailAddress = new EmailAddress
            {
                Address = settings.Mail.Recipient
            }
        }
    }
};

await graphClient.Users[settings.Mail.Sender]
    .SendMail
    .PostAsync(new Microsoft.Graph.Users.Item.SendMail.SendMailPostRequestBody
    {
        Message = message,
        SaveToSentItems = true
    });


Console.WriteLine("✅ Email sent successfully via Microsoft Graph!");




AppSettings LoadSettings()
{
    var json = File.ReadAllText("appsettings.json");
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    return JsonSerializer.Deserialize<AppSettings>(json, options)!;
}

namespace Graph.Mail.Send.Sample
{
    public class AppSettings
    {
        public AzureAdSettings AzureAd { get; set; }
        public MailSettings Mail { get; set; }
    }

    public class AzureAdSettings
    {
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }

    public class MailSettings
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
    }
}