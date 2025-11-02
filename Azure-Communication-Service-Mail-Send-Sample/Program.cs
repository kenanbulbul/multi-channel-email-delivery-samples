using Azure;
using Azure.Communication.Email;


string connectionString = "COMMUNICATION_SERVICES_CONNECTION_STRING";
var emailClient = new EmailClient(connectionString);


// 1- Content

var content = new EmailContent("Test Email with CC, BCC and Attachment")
{
    PlainText = "Hello from Azure Communication Services with attachment.",
    Html = @"
                <html>
                    <body>
                        <h2>Hello Kenan,</h2>
                        <p>This email includes an attachment, CC and BCC recipients.</p>
                        <p>-- Azure Communication Services Email</p>
                    </body>
                </html>"
};

// 2- Recipient List (To, CC, BCC)
var recipients = new EmailRecipients(
    to: new List<EmailAddress>
    {
                new EmailAddress("<to_email>")
    },
    cc: new List<EmailAddress>
    {
                new EmailAddress("ccperson@domain.com")
    },
    bcc: new List<EmailAddress>
    {
                new EmailAddress("bccperson@domain.com")
    }
);


// 3- Attachment (sample file attach)

//string attachmentPath = "c:/samplepath/sample.txt";
//File.WriteAllText(attachmentPath, "This is a test file sent as attachment.");

// if you want to add multiple attachments, you can uncomment below lines
//emailMessage.Attachments.Add(new EmailAttachment("doc1.pdf", "application/pdf", Convert.ToBase64String(File.ReadAllBytes("doc1.pdf"))));
//emailMessage.Attachments.Add(new EmailAttachment("image.png", "image/png", Convert.ToBase64String(File.ReadAllBytes("image.png"))));

//byte[] fileBytes = File.ReadAllBytes(attachmentPath);

//var attachment = new EmailAttachment(
//    name: "sample.txt",
//    contentType: "text/plain",
//    content: BinaryData.FromBytes(fileBytes)
//);

// 5️- Create Email Message
var emailMessage = new EmailMessage(
    senderAddress: "DoNotReply@<from_domain>", // Should verified domain on Azure Communication Service
    content: content,
    recipients: recipients
);
//emailMessage.Attachments.Add(attachment);



EmailSendOperation emailSendOperation = emailClient.Send(WaitUntil.Completed, emailMessage);


Console.WriteLine($"✅ Email sent! Status: {emailSendOperation.Value.Status}");
Console.WriteLine($"Operation ID: {emailSendOperation.Id}");