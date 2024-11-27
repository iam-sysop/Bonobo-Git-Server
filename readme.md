gitserver.net (git-server-dot-net) (a fork of Bonobo Git Server)
==============================================

Thank you for downloading gitserver.net (a fork of Bonobo Git Server).  

gitserver.net is a C#/IIS/.NET Framework based HTTP(S) and GIT server (and will remain targed to the .NET Framework).

Roadmap
-----------------------------------------------
* Forked project
* Update dependencies
* Drop DotNetZip dependency for System.IO.Compression
* Move AD to OWIN
* Cleanup Tests

**CURRENT DEVELOPMENT BRANCH: [v6.6.0](https://github.com/iam-sysop/gitserver.net/tree/v6.6.0)**
  
<br><br>
(begin original readme)

Prerequisites
-----------------------------------------------

* Internet Information Services 7 and higher
    * [How to Install IIS 8 on Windows 8](http://www.howtogeek.com/112455/how-to-install-iis-8-on-windows-8/)
    * [Installing IIS 8 on Windows Server 2012](http://www.iis.net/learn/get-started/whats-new-in-iis-8/installing-iis-8-on-windows-server-2012)
    * [Installing IIS 7 on Windows Server 2008 or Windows Server 2008 R2](http://www.iis.net/learn/install/installing-iis-7/installing-iis-7-and-above-on-windows-server-2008-or-windows-server-2008-r2)
    * [Installing IIS 7 on Windows Vista and Windows 7](http://www.iis.net/learn/install/installing-iis-7/installing-iis-on-windows-vista-and-windows-7)
* [.NET Framework 4.6](https://www.microsoft.com/en-gb/download/details.aspx?id=48130)
    * Windows Vista SP2, Windows 7, Windows 8 and higher
    * Windows Server 2008 R2, Windows Server 2008 SP2, Windows Server 2012 and higher
    * Don't forget to register .NET framework with your IIS
        * Run `%windir%\Microsoft.NET\Framework\v4.0.30319\aspnet_regiis.exe -ir` with administrator privileges

<hr />


