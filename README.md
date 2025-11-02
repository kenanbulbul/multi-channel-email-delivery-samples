# Multi-Channel Email Delivery Samples

This repository demonstrates **multiple approaches for programmatic email delivery**  
across different platforms and authentication models — including Microsoft 365, Azure, and AWS services.

---

## 🚀 Overview

Modern applications often need to send transactional or system notifications securely,  
reliably, and without relying on legacy basic authentication (username/password).

This repository provides **end-to-end working samples** that illustrate  
how to send outbound email using modern APIs and identity models.

Each sample focuses on a different backend or transport mechanism.

---

## 📂 Project Structure

| Folder | Description |
|---------|--------------|
| **ExchangeOnline.Smtp.OAuth2.Sample** | Uses `MailKit` and `MSAL` to send mail via Exchange Online SMTP AUTH with OAuth2 (Modern Authentication). |
| **Graph.Mail.Send.Sample** | Uses Microsoft Graph API (`/sendMail`) endpoint to send email with delegated or application permissions. *(coming soon)* |
| **Azure.Communication.Email.Sample** | Demonstrates email delivery via [Azure Communication Services Email](https://learn.microsoft.com/azure/communication-services/email/overview). *(planned)* |
| **AWS.SES.Sample** | Shows sending email using [Amazon Simple Email Service (SES)](https://aws.amazon.com/ses/) with AWS SDK for .NET. *(planned)* |

---

## 🧰 Tech Stack

- **.NET 9 / C#**
- **Microsoft Identity Platform (OAuth2 / MSAL)**
- **MailKit**, **Graph SDK**, **Azure.Communication.Email**, **AWSSDK.SimpleEmail**
- Secure app registration and token-based authentication
- Exchange Online, Microsoft Graph, Azure Communication Services, AWS SES

---

## ⚙️ Configuration

Each sample project includes its own configuration file (`appsettings.sample.json`).  
Before running any sample:

1. Duplicate the file as `appsettings.json`
2. Replace placeholder values (`YOUR_TENANT_ID`, `YOUR_CLIENT_ID`, etc.) with real values
3. Ensure the corresponding app registration and permissions are configured in Azure AD or AWS IAM

---

## 🧠 Learning Goals

- Understand different **email delivery architectures**
- Learn how **OAuth2 application tokens** are used for secure SMTP and Graph communication
- Explore how to migrate from **legacy Basic Auth** to **Modern Auth**
- Compare cloud-native alternatives (Exchange Online vs Azure Communication vs AWS SES)

---

## 🧩 Roadmap

- [x] Exchange Online SMTP OAuth2 Sample  
- [ ] Microsoft Graph Mail Send Sample  
- [ ] Azure Communication Services Email Sample  
- [ ] AWS SES Email Sample  

---

## 📘 Documentation

Additional setup and screenshots can be found under the [docs/](./docs) folder:
- [Azure App Registration Guide](./docs/azure-app-registration.md)

---

## 🧾 License

This repository is provided for educational and integration purposes.  
You are free to clone, adapt, and extend the samples under the MIT License.

---

### 💡 Author
**Kenan Bulbul**  
Microsoft 365 / Cloud / DevOps Solutions Architect  
[GitHub Profile](https://github.com/kenanbulbul)
