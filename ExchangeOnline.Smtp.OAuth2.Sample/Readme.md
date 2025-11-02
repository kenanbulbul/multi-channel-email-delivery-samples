# Exchange Online SMTP OAuth2 Sample

This repository contains a simple **.NET Core** sample project demonstrating how to send outbound emails via **Microsoft Exchange Online** using **Modern Authentication (OAuth2)** with **SMTP** protocol.

## 🧩 Overview
Due to the deprecation of Basic Authentication in Exchange Online, applications must now use **Modern Auth (OAuth2)** to authenticate and send emails securely.  
This project illustrates how to:
- Acquire access tokens from Azure AD using **MSAL** (Microsoft Authentication Library)
- Use these tokens with **SMTP AUTH** to send outbound messages
- Demonstrate a minimal implementation in **C# (.NET 6 or higher)**

## 🚀 Technologies Used
- .NET 6 / .NET 8
- Microsoft.Identity.Client (MSAL)
- Exchange Online (Office 365)
- SMTP AUTH protocol

## ⚙️ Prerequisites
Before running this project:
1. Register an app in **Azure AD**.
2. Grant **SMTP.Send** permission.
3. Enable **SMTP AUTH** for your tenant or user account.
4. Collect your:
   - Client ID
   - Tenant ID
   - Client Secret
   - Exchange Online mailbox address

## ▶️ Running the Sample
1. Clone this repository:
   ```bash
   git clone https://github.com/<your-username>/exchangeonline-smtp-oauth2-sample.git
2. Set environment variables:
   - `AZURE_CLIENT_ID`
   - `AZURE_CLIENT_SECRET`
   - `AZURE_TENANT_ID`
3. Update `appsettings.json` with your mail settings
4. Run the application


## 📨 About High Volume Email (HVE)

This project demonstrates **Modern Authentication (OAuth2)** with **SMTP AUTH** via `smtp.office365.com`.  
It is suitable for **application-based outbound email** using a standard Exchange Online mailbox.

However, this approach **is not the same as Microsoft’s High Volume Email (HVE)** feature.

### 🔍 Key Differences

| Feature | Standard SMTP (this project) | High Volume Email (HVE) |
|----------|------------------------------|--------------------------|
| Endpoint | `smtp.office365.com` | `smtp-hve.office365.com` |
| Mailbox Type | Regular Exchange Online mailbox | Dedicated HVE mailbox |
| Authentication | OAuth2 App (SMTP.SendAsApp) | OAuth2 App or certificate (HVE account) |
| Audience | Internal & external recipients | Primarily internal recipients |
| Limits | Standard Exchange Online sending limits (10k recipients/day) | Designed for high internal volume (100k+/day) |
| Availability | GA | Preview (as of 2025) |
| External Delivery | ✅ Supported | ⚠️ Being phased out (planned removal June 2025) |

### 🧠 When to Use HVE

Use **HVE** if:
- Your organization sends **tens of thousands of internal messages per day**, or  
- You require **system-to-user notifications** at high scale (e.g., HR, workflow systems).

For most line-of-business applications (notifications, alerts, transactional mail),  
this project’s implementation using `smtp.office365.com` with OAuth2 is fully sufficient.

### 📚 Reference
- Microsoft Learn: [High Volume Email (HVE) overview](https://learn.microsoft.com/en-us/exchange/mail-flow-best-practices/high-volume-email)
- Microsoft Learn: [Configure app-based SMTP authentication](https://learn.microsoft.com/en-us/exchange/client-developer/modern-auth-smtp-auth-client)
