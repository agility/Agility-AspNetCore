# Agility for .NET Core
This is a starter template for developers who want to use ASP.NET Core.

It uses the open-source [`Agility.AspNetCore SDK`](https://github.com/agility/Agility.AspNetCore) which handles page routing, rendering, multi-language, redirections and syncing content from Agility CMS. Find a problem within the SDK? Open an [issue](https://github.com/agility/Agility.AspNetCore/issues).


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

In addition, the Agility instance must have its **Development Language** set to *ASP.NET Core*. This can be done in **Agility > Settings > Customization/Development / Development Framework**.


1. Clone/Download this repository.
2. Open the repository in your favorite IDE - we recommend VS Code.
3. Open and edit the file **Website\appsettings.json** and set the **websiteName** and **securityKey** 

[How to Retrieve your Website Name and Security Key](https://help.agilitycms.com/hc/en-us/articles/360029220591-How-to-Retrieve-an-Instance-s-Security-Key)

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
    "debugSync": "false",
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
**Note:** *When connecting this to your instance, your instance may have Modules or Page Templates that will need corresponding code to be implemented within the website. If you see any errors around Page Templates not found or missing a corresponding ViewComponent, then ensure you add the appropriate dependencies for your instance. Sometimes the easiest way to get this up and running is to initialize the files and just have them output some sample HTML*

4. Open a terminal and start the dotnet site (backend) - this should restore packages, build the site and start running the site
```
Website> dotnet run
```
5. Open a terminal and start the webpack dev server (frontend) - you will use this during development
```
Website\wwwroot> npm run dev
```
You should now have the site running on http://localhost:8080/.

## Agility Modules 
In a traditional ASP.NET MVC project, Controllers and Actions are used to render Agility Modules. ASP.NET Core replaces them with ViewComponents. Using ViewComponents enables Agility.Web for ASP.NET Core to render modules on a page asynchronously.


In Agility, you set the *Output Template* for a module to be a View Component which corresponds to the name of your ViewComponent class.

If you have a module with a View Component Name set to *Callout*, then Agility.Web will look for a ViewComponent in your website.

**CalloutViewComponent.cs**:
``` csharp
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website;
using Website.AgilityModels;
using Agility.Web.Extensions;

namespace Website.ViewComponents.Modules
{
    public class Callout: ViewComponent
    {

        public Task<IViewComponentResult> InvokeAsync(Module_Callout module) 
        {
            return Task.Run<IViewComponentResult>(() =>
            {
                return View("~/Views/Modules/Callout.cshtml", module);
            });
        }

    }

}
```

**Callout.cshtml**:
``` html
@model Website.AgilityModels.Module_Callout

@if(Model.Image != null)
{
    <img src="@Model.Image.URL?w=200" alt="@Model.Image.Label" />
}


<h1>@Model.Title</h1>

@Html.Raw(Model.TextBlob)
```

## Creating a Production Build
When ready to deploy a website built on this template, you'll need to build both your backend and frontend.

1. In a terminal, run the following command to build the frontend:
```
Website\wwwroot> npm run build
```

2. In a terminal, run the following command to build the backend - [see dotnet publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21) for more information on this:
```
Website> dotnet publish --configuration Release
```

# Want to Contribute?
Do you have something you want to add to this template that you think will benefit others? If so, please use the *fork and pull* model so you can fork this repository and push changes to your personal fork. Then, open a pull request and we can merged it into this repository.
