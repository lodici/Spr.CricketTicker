Imports System.Runtime.CompilerServices
Imports System.Xml

Public Module LinqXmlExtensions

    <Extension()>
    Public Function ToXmlDocument(xDoc As XDocument) As XmlDocument
        Dim xmlDoc = New XmlDocument
        Using reader As XmlReader = xDoc.CreateReader()
            xmlDoc.Load(reader)
        End Using
        Return xmlDoc
    End Function

    <Extension()>
    Public Function ToXDocument(xmlDoc As XmlDocument) As XDocument
        Using reader = New XmlNodeReader(xmlDoc)
            reader.MoveToContent()
            Return XDocument.Load(reader)
        End Using
    End Function

End Module
