gitserver.net (git-server-dot-net - a fork of Bonobo Git Server)
==============================================

Thank you for downloading gitserver.net (a fork of Bonobo Git Server).  

gitserver.net is a C#/IIS/.NET Framework based HTTP(S) and GIT server (and will remain targed to the .NET Framework).

Roadmap
-----------------------------------------------

- [x] Forked project
- [x] Update NuGet dependencies
- [x] Drop DotNetZip dependency for System.IO.Compression
- [x] Cleanup naming conventions
- [ ] Update javascript dependencies
- [ ] Move AD to OWIN
- [ ] Cleanup Tests

**CURRENT DEVELOPMENT BRANCH: [v6.6.0](https://github.com/iam-sysop/gitserver.net/tree/v6.6.0)**



Prerequisites
-----------------------------------------------
* Microsoft IIS 7.5 or higher
* Windows based OS
    * ~~Windows Vista~~ [^1][^2]
    * Windows 7 [^2]
    * Windows 8.x [^2]
    * Windows 10 or higher
    * ~~Windows Server 2008~~ [^1][^2]
    * Windows Server 2008 R2 [^2]
    * Windows Server 2012 [^2]
    * Windows Server 2016
    * Windows Server 2019 or higher
* [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)  
    OFFLINE INSTALLERS:  
    * [Runtime](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-offline-installer)  
    * [Developer SDK](https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-developer-pack-offline-installer)
    



Update
-----------------------------------------------

Before each update please read carefully the information about **compatibility issues** between your version and the latest one in [changelog](/changelog.md).

* Delete all the files in the installation folder **except App_Data**.
    * Default location is `C:\inetpub\wwwroot\gitserverdotnet`.
    * Inside the App_Data folder, also remove the "Git" folder as well as .gitconfig (a proper Git binary will be automatically installed).
* Copy the files from the downloaded archive to the server location.


<hr />



Installation
-----------------------------------------------

These steps illustrate simple installation with Windows 2008 R2 Server and IIS 7.5. They are exactly the same for higher platforms (Windows Server 2012+ and IIS 8.0+).

* **Extract the files** from the installation archive to `C:\inetpub\wwwroot`

* **Allow IIS User to modify** `C:\inetpub\wwwroot\gitserverdotnet\App_Data` folder. To do so
    * select Properties of App_Data folder,
    * go to Security tab, 
    * click edit, 
    * select IIS user (in my case IIS_IUSRS) and add Modify and Write permission,
    * confirm these settings with Apply button.

* **Convert gitserverdotnet to Application** in IIS
    * Run IIS Manager and navigate to Sites -> Default Web Site. You should see gitserverdotnet.
    * Right click on gitserverdotnet and convert to application.
    * Check if the selected application pool runs on .NET 4.0 and convert the site.

* **Launch your browser** and go to [http://localhost/gitserverdotnet](http://localhost/gitserverdotnet). Now you can see the initial page of gitserver.net and everything is working.
    * Default credentials are username: **admin** password: **admin**


<hr />

  
[^1]: no longer supported - underlying OS does not support .NET Framework v4.7.2  
[^2]: underlying OS is EOL by vendor and not recommended for production usage      

