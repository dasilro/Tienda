Imports System.Linq.Expressions

Namespace Tienda.ApiControllers

    Public Class Conversor

        Public Shared Function Convierte(origen As Kendo.Mvc.UI.DataSourceRequest) As Tienda.Services.DataSourceRequest

            Dim resultado As New Tienda.Services.DataSourceRequest(origen.Page, origen.PageSize, New List(Of Services.Orden), New List(Of Expression))

            For Each sort As Kendo.Mvc.SortDescriptor In origen.Sorts
                resultado.Orden.Add(New Services.Orden(sort.Member, sort.SortDirection))
            Next

            Return resultado

        End Function

    End Class

End Namespace
