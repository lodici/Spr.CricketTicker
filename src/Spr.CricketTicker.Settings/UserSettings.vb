Imports System.IO
Imports Nini.Config

Public Class UserSettings

    Private Shared _settings As IConfigSource

    ''' <remarks>Public Not Creatable</remarks>
    Protected Sub New()
    End Sub

    ''' <summary>
    ''' False by default. If true then ticker displays score using the Australian format (wickets/runs).
    ''' </summary>
    Public Shared Property ReverseScoreDisplay As Boolean
        Get
            Return Settings("Display").GetBoolean("ReverseScoreDisplay", False)
        End Get
        Set(value As Boolean)
            Settings("Display").Set("ReverseScoreDisplay", value)
        End Set
    End Property

    Private Shared Function Settings(section As String) As IConfig
        If _settings Is Nothing Then
            _settings = New IniConfigSource(IniFilePath())
            _settings.AutoSave = True
        End If
        If _settings.Configs(section) Is Nothing Then
            _settings.AddConfig(section)
        End If
        Return _settings.Configs(section)
    End Function

    Private Shared Function IniFilePath() As String
        Dim settingsFile As String = Path.Combine(UserSettingsDirectory(), "settings.ini")
        EnsureFileExists(settingsFile)
        Return settingsFile
    End Function

    Private Shared Function UserSettingsDirectory() As String
        Dim directoryPath As String =
            Path.Combine(GetAppDataRoamingDirectory(), GetRootDirectoryName())
        EnsureDirectoryExists(directoryPath)
        Return directoryPath
    End Function

    Private Shared Function GetRootDirectoryName() As String
#If DEBUG Then
        Return "Spr.CricketTicker.Debug"
#Else
        return "Spr.CricketTicker"
#End If
    End Function

    Private Shared Function GetAppDataRoamingDirectory() As String
        Return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    End Function

    Private Shared Sub EnsureDirectoryExists(directoryPath As String)
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If
    End Sub

    Private Shared Sub EnsureFileExists(filePath As String)
        EnsureDirectoryExists(Path.GetDirectoryName(filePath))
        If Not File.Exists(filePath) Then
            File.Create(filePath).Close()
        End If
    End Sub

End Class
