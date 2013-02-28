Imports System.Runtime.CompilerServices

Public Module NumericExtensions

    ''' <summary>
    ''' Integer extension that offers a more concise syntax for converting an integer to the equivalent Enum type.
    ''' </summary>
    <Extension()>
    Public Function AsEnum(Of E)(intValue As Integer) As E
        Return CType([Enum].ToObject(GetType(E), intValue), E)
    End Function

End Module
