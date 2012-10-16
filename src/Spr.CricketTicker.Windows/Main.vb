Imports Spr.CricketTicker.Windows.Forms
Imports Spr.YahooQueryLanguage.Cricket
Imports Spr.CricketTicker.Library

Module Main

    Private ReadOnly _log As log4net.ILog =
        log4net.LogManager.GetLogger(Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    <STAThread()> _
    Public Sub Main()

        Try

            log4net.GlobalContext.Properties("AppVersion") = GetAssemblyVersion()

            Application.EnableVisualStyles()

            Dim service As ICricketService = GetCricketService()
            Dim gameSelector = New GameSelector(service)
            If gameSelector.ShowDialog = DialogResult.OK Then
                Dim frm = New Forms.CricketTicker(service, gameSelector.SelectedGameId)
                Application.Run(frm)
            End If

        Catch ex As Exception
            _log.Error("Runtime Error", ex)

        End Try

    End Sub

    Private Function GetCricketService() As ICricketService
#If USE_SAMPLE_FEED Then
        Return New CricketService(New Spr.CricketTicker.SampleFeeds.SampleFeed)
#Else
        Return New CricketService()
#End If
    End Function

End Module
