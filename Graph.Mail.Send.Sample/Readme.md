# Microsoft Graph Mail Send Sample (.NET)

This sample demonstrates how to send an email through **Microsoft Graph API** using  
**application permissions** and **OAuth 2.0 (Modern Authentication)** in a .NET console application.

---

## ⚙️ Prerequisites

- .NET 8.0 or later  
- An Azure AD application registered in your tenant  
- The following API permission granted to the app:  
  - `Mail.Send` (Application permission)  
- A mailbox-enabled user in Exchange Online

---

## 🧩 App Registration Steps

1. Go to **Microsoft Entra ID → App registrations → New registration**
2. Give it a name (e.g., `GraphMailSendApp`) and register
3. Under **Certificates & secrets**, create a **Client secret**
4. Under **API permissions**, add **Microsoft Graph → Application permissions → Mail.Send**
5. Grant **Admin consent** for the tenant

---

## 🔧 Configuration

Create an `appsettings.json` file in the project root:

```json
{
  "AzureAd": {
    "TenantId": "your-tenant-id",
    "ClientId": "your-client-id",
    "ClientSecret": "your-client-secret"
  },
  "Mail": {
    "Sender": "sender@yourtenant.onmicrosoft.com",
    "Recipient": "recipient@yourtenant.onmicrosoft.com"
  }
}
```

---


## ✅ Expected Output

Access token successfully acquired via Azure.Identity ✅
Email sent successfully via Microsoft Graph! ✅

---


## Dependencies

- Microsoft.Graph
- Azure.Identity
- 
