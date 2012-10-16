Imports System.Reflection
Imports System.Text

Module SprSnippets

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
            .Append(assemblyVersion.Build).Append(".") _
            .Append(assemblyVersion.Revision)
        Return versionString.ToString()
    End Function

End Module