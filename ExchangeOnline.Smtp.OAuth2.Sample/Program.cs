using Microsoft.Identity.Client;
using System.Text.Json;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using ExchangeOnline.Smtp.OAuth2.Sample;

// read settings from appsettings.json
var json = File.ReadAllText("appsettings.json");

// options to read case-insensitive
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

var settings = JsonSerializer.Deserialize<AppSettings>(json, options);

// create MSAL client application
var app = ConfidentialClientApplicationBuilder.Create(settings.AzureAd.ClientId).WithClientSecret(settings.AzureAd.ClientSecret).WithTenantId(settings.AzureAd.TenantId).Build();

// define the required scopes
string[] scopes = ["https://outlook.office365.com/.default"];


//get the access token - Remove test areas 
Console.WriteLine("Getting Access Token...");
var result = await app.AcquireTokenForClient(scopes).ExecuteAsync();
Console.WriteLine("Access token has been taken.");
// show part of the token for validation
Console.WriteLine($"Token's (first 60 char): {result.AccessToken.Substring(0, 50)}...");


Console.WriteLine("SMTP connection is in progress...");


// 1) create the email message
var message = new MimeMessage();
message.From.Add(MailboxAddress.Parse(settings.Mail.UserPrincipalName));
message.To.Add(MailboxAddress.Parse(settings.Mail.TargetEmailAddress)); // 
message.Subject = "Exchange Online OAuth2 Test";
message.Body = new TextPart("plain")
{
    Text = "This is a test email sent using Exchange Online with OAuth2 (MSAL + MailKit)."
};


// 2) connect to SMTP using MailKit
using (var smtp = new SmtpClient())
{
    await smtp.ConnectAsync(settings.Mail.SmtpHost, settings.Mail.SmtpPort, SecureSocketOptions.StartTls);

    // 3) XOAUTH2 authentication
    var oauth2 = new MailKit.Security.SaslMechanismOAuth2(settings.Mail.UserPrincipalName, result.AccessToken);
    await smtp.AuthenticateAsync(oauth2);

    // 4) send mail
    await smtp.SendAsync(message);
    await smtp.DisconnectAsync(true);
}

Console.WriteLine("Email has been sent successfully.");

namespace ExchangeOnline.Smtp.OAuth2.Sample
{

    // Classes for appsettings.json
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
        public string UserPrincipalName { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        public string TargetEmailAddress { get; set; }
    }
}
