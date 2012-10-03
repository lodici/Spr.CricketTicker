Namespace Cricket

    Module ParserHelper

        Public Function GetSeriesSubTitle(seriesName As String) As String
            Dim subTitle As String = String.Empty
            Dim series() As String = Split(seriesName, ",")
            For i = 1 To series.Count - 1
                subTitle += series(i).Trim + ", "
            Next
            If subTitle <> String.Empty Then
                subTitle = Left(subTitle, Len(subTitle) - Len(", "))
            End If
            Return subTitle
        End Function

    End Module

End Namespace