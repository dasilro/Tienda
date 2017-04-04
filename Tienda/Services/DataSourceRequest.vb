Imports System.Linq.Expressions

Namespace Tienda.Services

    Public Class DataSourceRequest

        Public Pagina As Integer
        Public TamanyoPagina As Integer
        Public Orden As List(Of Orden)
        Public Filtro As List(Of Expression)

        Public Sub New()

        End Sub

        Public Sub New(pagina As Integer, tamanyoPagina As Integer, orden As List(Of Orden), filtro As List(Of Expression))
            Me.Pagina = pagina
            Me.TamanyoPagina = tamanyoPagina
            Me.Orden = orden
            Me.Filtro = filtro
        End Sub

    End Class

End Namespace

