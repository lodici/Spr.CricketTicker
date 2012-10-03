Imports Spr.CricketTicker.Windows.Forms
Imports Spr.YahooQueryLanguage.Cricket
Imports Spr.CricketTicker.Library

Module Main

    <STAThread()> _
    Public Sub Main()

        Application.EnableVisualStyles()

        Dim service As ICricketService = GetCricketService()
        Dim gameSelector = New GameSelector(service)
        If gameSelector.ShowDialog = DialogResult.OK Then
            Dim frm = New Forms.CricketTicker(service, gameSelector.SelectedGameId)
            Application.Run(frm)
        End If

    End Sub

    Private Function GetCricketService() As ICricketService
#If USE_SAMPLE_FEED Then
        Return New CricketService(New Spr.CricketTicker.SampleFeeds.SampleFeed)
#Else
        Return New CricketService()
#End If
    End Function

End Module
