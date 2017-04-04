Namespace Tienda.Services
    Public Class Orden
        Public Campo As String
        Public Direccion As SortDirection

        Public Sub New(campo As String, direccion As SortDirection)
            Me.Campo = campo
            Me.Direccion = direccion
        End Sub
    End Class
End Namespace
