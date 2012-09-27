Imports Spr.CricketTicker.Library
Imports Spr.CricketTicker.SampleFeeds

Module Main

    <STAThread()> _
    Public Sub Main()

        Application.EnableVisualStyles()

        Dim service As ICricketService = GetCricketService()
        Dim gameSelector = New GameSelector(service)
        If gameSelector.ShowDialog = DialogResult.OK Then
            Dim frm = New CricketTicker(service, gameSelector.SelectedGameId)
            Application.Run(frm)
        End If

    End Sub

    Private Function GetCricketService() As ICricketService
#If USE_SAMPLE_FEED Then
        Return New Spr.YahooQueryLanguage.CricketService(New SampleFeed)
#Else
        Return New Spr.YahooQueryLanguage.CricketService()
#End If
    End Function

End Module
