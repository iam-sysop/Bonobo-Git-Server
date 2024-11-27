gitserver.net (git-server-dot-net - a fork of Bonobo Git Server)
==============================================

Thank you for downloading gitserver.net (a fork of Bonobo Git Server).  

gitserver.net is a C#/IIS/.NET Framework based HTTP(S) and GIT server (and will remain targed to the .NET Framework).

Roadmap
-----------------------------------------------
- [x] Forked project
- [x] Update NuGet dependencies
- [x] Drop DotNetZip dependency for System.IO.Compression
- [ ] Cleanup naming conventions
- [ ] Update javascript dependencies
- [ ] Move AD to OWIN
- [ ] Cleanup Tests
  


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
    * Default location is `C:\inetpub\wwwroot\Bonobo.Git.Server`.
* Copy the files from the downloaded archive to the server location.


<hr />



Installation
-----------------------------------------------

These steps illustrate simple installation with Windows 2008 Server and IIS 7. They are exactly the same for higher platforms (Windows Server 2012 and IIS 8.0).

* **Extract the files** from the installation archive to `C:\inetpub\wwwroot`

* **Allow IIS User to modify** `C:\inetpub\wwwroot\Bonobo.Git.Server\App_Data` folder. To do so
    * select Properties of App_Data folder,
    * go to Security tab, 
    * click edit, 
    * select IIS user (in my case IIS_IUSRS) and add Modify and Write permission,
    * confirm these settings with Apply button.

* **Convert Bonobo.Git.Server to Application** in IIS
    * Run IIS Manager and navigate to Sites -> Default Web Site. You should see Bonobo.Git.Server.
    * Right click on Bonobo Git Server and convert to application.
    * Check if the selected application pool runs on .NET 4.0 and convert the site.

* **Launch your browser** and go to [http://localhost/Bonobo.Git.Server](http://localhost/Bonobo.Git.Server). Now you can see the initial page of Bonobo Git Server and everything is working.
    * Default credentials are username: **admin** password: **admin**


<hr />


Frequently Asked Questions
-----------------------------------------------

#### How to clone a repository?

* Go to the **Repository Detail**.
* Copy the value in the **Git Repository Location**.
    * It should look like `http://servername/projectname.git`.
* Go to your command line and run `git clone http://servername/projectname.git`.

#### How do I change my password?

* Click on the **account settings** in the top right corner.
* Enter new password and confirmation.
* Save.

#### How to backup data?

* Go to the installation folder of Bonobo Git Server on the server.
    * Default location is `C:\inetpub\wwwroot\Bonobo.Git.Server`.
* Copy the content of App_Data folder to your backup directory.
* If you changed the location of your repositories, backup them as well.

#### How to change repositories folder?

* Log in as an administrator.
* Go to **Global Settings**.
* Set the desired value for the **Repository Directory**.
    * Directory must exist on the hard drive.
    * IIS User must have proper permissions to modify the folder.
* Save changes.    

#### Can I allow anonymous access to a repository?

* Edit the desired repository (or do this when creating the repository).
* Check **Anonymous** check box.
* Save.

For allowing anonymous push you have to modify global settings.

* Log in as an administrator.
* Go to **Global Settings**.
* Check the value **Allow push for anonymous repositories**
* Save changes.

#### I'd like to use git hooks to restrict access. How do I access the web frontend usernam?

Bonobo provides the following environment variables:

* `AUTH_USER`: The username used to login. Empty if it was an anonymous operation (clone/push/pull)
* `REMOTE_USER`: Same as `AUTH_USER`
* `AUTH_USER_TEAMS`: A comma-separated list containing all the teams the user belongs to. Commas in teams name are escaped with a backslash. Backslashes are also escaped with a `\`. Example: Teams 'Editors\ Architects', 'Programmers,Testers' will become `Editors\\ Architects,Programmers\,Testers`.
* `AUTH_USER_ROLES`: A comma-separated list containing all the roles the user belongs to. Commas in roles are escaped with a backslash. Backslashes are also escaped with a `\`.
* `AUTH_USER_DISPLAYNAME`: Given Name + Surname if available. Else the username.

**Beware that due to the way HTTP basic authentication works, if anonymous operations (push/pull) are enabled the variables above will always be empty!**

<br>
[^1]: no longer supported - underlying OS does not support .NET Framework v4.7.2  
[^2]: underlying OS is EOL by vendor and not recommended for production usage
    