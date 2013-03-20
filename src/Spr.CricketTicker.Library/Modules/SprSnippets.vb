Imports System.Reflection
Imports System.Text

Module SprSnippets

    Public Function ProductCaption() As String
        Return My.Application.Info.ProductName + " " + GetAssemblyVersion()
    End Function

    Private Function GetAssemblyVersion() As String
        Dim assemblyVersion As Version
        If Assembly.GetEntryAssembly Is Nothing Then
            assemblyVersion = Assembly.GetExecutingAssembly.GetName.Version
        Else
            assemblyVersion = Assembly.GetEntryAssembly().GetName().Version
        End If
        Dim versionString As New StringBuilder
        versionString _
            .Append(assemblyVersion.Major).Append(".") _
            .Append(assemblyVersion.Minor)
        If IsDebugBuild() Then
            '// Do not show Build & Revision in a Release build.
            versionString _
                .Append(".").Append(assemblyVersion.Build) _
                .Append(".").Append(assemblyVersion.Revision)
        End If
        Return versionString.ToString()
    End Function

    Public Function IsRunningInIde() As Boolean
        Return Debugger.IsAttached
    End Function

    Private Function IsDebugBuild() As Boolean
#If DEBUG Then
        Return True
#Else
            Return False
#End If
    End Function

End Module