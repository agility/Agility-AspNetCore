# Agility .NET Core Vanilla Template
This is a starter template for developers who want to use ASP.NET Core, and the Agility.AspNetCore/Agility.Web SDK to sync content and provide an interface to access content without making API calls. The Agility.AspNetCore/Agility.Web SDK also manages page routing, caching and more.

This is the *fastest* way to get started with Agility and build high-performance websites out-of-the-box. 

**Backend:**
- .NET Core 2.1

**Frontend:**
- npm and webpack
- sass loader
- agility and agility-ugc npm packages
- vanilla js

## Benefits vs .NET Framework Templates
- Better caching
- Agility Modules are executed asnychronously
- Cross-platform development and hosting
- Modern frontend tools

## How to Get Set Up
In order to connect this website to an Agility instance, you'll need a Website Name, Security Key, and UGC API credentials. If you don't have this, please contact support@agilitycms.com and we can assist you.

1. Clone/Download this repository.
2. Open the repository in your favorite IDE - we recommend VS Code.
3. Open and edit the file **Website\appsettings.json** and set the **websiteName** and **securityKey** 
``` javascript
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "Agility": {
    "applicationName": "My Web Application",
    "websiteName": "{WebsiteName goes here}", 
    "securityKey": "{Security Key goes here}",
    "contentCacheFilePath": "d:/home/AgilityContent/",
    "contentServerUrl": "https://contentserver1503.agilitycms.com/agilitycontentserver.svc",
    "developmentMode": "false",
    "Trace": {
      "traceLevel": "Warning",
      "logFilePath": "d:/home/AgilityLogs/Website.log"
    },
    "UGC": {
      "Url": "https://ugc.agilitycms.com/",
      "Key": "{optional}",
      "Password": "{optional}"
    },
    "Analytics": {
      "Url": ""
    }
  }
}
```
4. Open a terminal and start the dotnet site (backend) - this should restore packages, build the site and start running the site
```
Website> dotnet run
```
5. Open a terminal and start the webpack dev server (frontend) - you will use this during development
```
Website\wwwroot> npm run dev
```

You should now have the site running on http://localhost:8080/.
