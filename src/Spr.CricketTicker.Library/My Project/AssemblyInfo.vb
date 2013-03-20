﻿Imports System
Imports System.Reflection
Imports System.Runtime.InteropServices

' General Information about an assembly is controlled through the following 
' set of attributes. Change these attribute values to modify the information
' associated with an assembly.

' Review the values of the assembly attributes

<Assembly: AssemblyTitle("Spr.CricketTicker.Library")> 
<Assembly: AssemblyDescription("")> 
<Assembly: AssemblyCompany("SPR")> 
<Assembly: AssemblyProduct("SPR Cricket Ticker")> 
<Assembly: AssemblyCopyright("Copyright © SPR  2012")> 
<Assembly: AssemblyTrademark("")> 

<Assembly: ComVisible(False)>

'The following GUID is for the ID of the typelib if this project is exposed to COM
<Assembly: Guid("6b9cc74c-6c1a-426a-a074-ef611348267e")> 

' Version information for an assembly consists of the following four values:
'
'      Major Version
'      Minor Version 
'      Build Number
'      Revision
'
' You can specify all the values or you can default the Build and Revision Numbers 
' by using the '*' as shown below:
' <Assembly: AssemblyVersion("1.0.*")> 

<Assembly: AssemblyVersion("1.3.0.*")> 
<Assembly: AssemblyFileVersion("1.3.0.0")> 

'// Link log4net to app.config and watch for changes.
<Assembly: log4net.Config.XmlConfigurator(Watch:=True)> 