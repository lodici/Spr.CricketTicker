Public Interface IGameSelectorView
    Sub CloseView()
    Sub DisplayUpcomingGameDetails(details As String)
    Sub SetFormCaption(caption As String)
    Sub AddSelectorItem(gameId As String, gameCaption As String, gameStatus As String)
End Interface
