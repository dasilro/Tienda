Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection
Imports System.Web
Imports Tienda.Models
Imports Tienda.Tienda.Services


Namespace Tienda.Services

    Public Class GenericService

        Public Shared Function Read(db As TiendaContext, clase As String, request As DataSourceRequest) As IList(Of Entity)

            Dim resultado As IQueryable(Of Entity)

            Dim tipo As Type = Type.GetType("Tienda." + clase)

            resultado = db.Set(tipo).AsQueryable()

            ' Aplico el filtro.
            ' For Each filtro As Expression(Of Func(Of Articulo, Boolean)) In request.Filtro
            ' Dim tipo As Type = Type.GetType("Tienda." + clase)

            For Each filtro As Expression(Of Func(Of Entity, Boolean)) In request.Filtro
                resultado = resultado.Where(filtro)
            Next

            ' Aplico el orden.
            If request.Orden.Any Then
                For Each orden As Orden In request.Orden
                    If (orden.Direccion = SortDirection.Ascending) Then
                        resultado = resultado.OrderBy(Function(a) a.GetType().GetProperty(orden.Campo))
                    End If
                Next
            Else
                resultado = resultado.OrderBy(Function(a) a.ID)
            End If

            ' Aplico paginación
            resultado = resultado.Skip((request.Pagina - 1) * request.TamanyoPagina).Take(request.TamanyoPagina)

            Return resultado.ToList()

        End Function

    End Class

End Namespace