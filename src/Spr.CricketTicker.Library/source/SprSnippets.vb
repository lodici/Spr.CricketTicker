Imports System.Reflection
Imports System.Text

Module SprSnippets

    Public Function ProductCaption() As String
        Return My.Application.Info.ProductName + " " + GetAssemblyVersion()
    End Function

    Public Function GetAssemblyVersion() As String
        Dim assemblyVersion As Version
        If Assembly.GetEntryAssembly Is Nothing Then
            assemblyVersion = Assembly.GetExecutingAssembly.GetName.Version
        Else
            assemblyVersion = Assembly.GetEntryAssembly().GetName().Version
        End If
        Dim versionString As New StringBuilder
        versionString _
            .Append(assemblyVersion.Major).Append(".") _
            .Append(assemblyVersion.Minor).Append(".") _
            .Append(assemblyVersion.Build)
        If IsDebugBuild() Then
            '// Revision is irrelevant in a Release build.
            versionString.Append(".").Append(assemblyVersion.Revision)
        End If
        Return versionString.ToString()
    End Function

    Public Function IsRunningInIde() As Boolean
        Return Debugger.IsAttached
    End Function

    Public Function IsDebugBuild() As Boolean
#If DEBUG Then
        Return True
#Else
            Return False
#End If
    End Function

End Module