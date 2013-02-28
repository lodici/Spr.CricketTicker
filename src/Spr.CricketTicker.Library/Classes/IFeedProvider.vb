Public Interface IFeedProvider
    Function GetLiveGamesAsXml() As Xml.XmlDocument
    Function GetUpcomingGamesAsXml() As Xml.XmlDocument
End Interface
