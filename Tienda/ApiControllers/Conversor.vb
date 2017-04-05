Imports System.Linq.Expressions
Imports Kendo.Mvc

Namespace Tienda.ApiControllers

    Public Class Conversor

        Public Shared Function Convierte(origen As Kendo.Mvc.UI.DataSourceRequest) As Tienda.Services.DataSourceRequest

            If (IsNothing(origen)) Then
                Return New Tienda.Services.DataSourceRequest(1, 10, New List(Of Services.Orden), New List(Of Expression))
            End If

            Dim resultado As New Tienda.Services.DataSourceRequest(origen.Page, origen.PageSize, New List(Of Services.Orden), New List(Of Expression))

            ' Orden.
            For Each sort As Kendo.Mvc.SortDescriptor In origen.Sorts
                resultado.Orden.Add(New Services.Orden(sort.Member, sort.SortDirection))
            Next

            ' Filtros.
            For Each filtro As IFilterDescriptor In origen.Filters
                resultado.Filtro.Add(filtro.CreateFilterExpression(filtro))
            Next

            Return resultado

        End Function

    End Class

End Namespace
