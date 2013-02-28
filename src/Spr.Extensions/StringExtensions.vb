
Imports System.Runtime.CompilerServices

Public Module StringExtensions

    ''' <summary>
    ''' String extension that offers a more concise syntax for converting a string representation of an Enum into its actual Enum type.
    ''' </summary>
    ''' <remarks>
    ''' Example - "LightOn".AsEnum(Of LightSwitchStates)() returns LightSwitchStates.LightOn enum type.
    ''' </remarks>
    <Extension()>
    Public Function AsEnum(Of E)(enumString As String) As E
        Return CType([Enum].Parse(GetType(E), enumString), E)
    End Function

    ''' <summary>
    ''' Extension removes specified suffix from end of string.
    ''' </summary>
    <Extension()>
    Public Sub RemoveSuffix(ByRef var As String, suffix As String)
        If Right(var, Len(suffix)) = suffix Then
            var = Left(var, Len(var) - Len(suffix))
        Else
            Throw New ArgumentException("Suffix not found.")
        End If
    End Sub

End Module
