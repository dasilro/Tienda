Imports Kendo.Mvc.Extensions
Imports Kendo.Mvc.UI
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Net
Imports System.Threading.Tasks
Imports System.Web.Http
Imports System.Web.Http.Description
Imports Tienda.Models

Namespace ApiControllers
    Public Class ArticulosController
        Inherits System.Web.Http.ApiController
        Private db As New TiendaContext
        Private _service As Tienda.Services.ArticulosService
        Public ReadOnly Property service() As Tienda.Services.ArticulosService
            Get
                If IsNothing(_service) Then
                    _service = New Tienda.Services.ArticulosService(Me.db)
                End If
                Return _service
            End Get
        End Property

        ' GET api/product
        Public Function GetArticulos(<DataSourceRequest> Request As DataSourceRequest) As DataSourceResult

            Return service.Read().ToDataSourceResult(Request)

        End Function

        ' GET: api/Articulos
        Function GetArticulos() As IQueryable(Of Articulo)
            Return db.Articulos
        End Function

        ' GET: api/Articulos/5
        <ResponseType(GetType(Articulo))>
        Async Function GetArticulo(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            If IsNothing(articulo) Then
                Return NotFound()
            End If

            Return Ok(articulo)
        End Function

        ' PUT: api/Articulos/5
        <ResponseType(GetType(Void))>
        Async Function PutArticulo(ByVal id As Integer, ByVal articulo As Articulo) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            If Not id = articulo.ArticuloID Then
                Return BadRequest()
            End If

            db.Entry(articulo).State = EntityState.Modified

            Try
                Await db.SaveChangesAsync()
            Catch ex As DbUpdateConcurrencyException
                If Not (ArticuloExists(id)) Then
                    Return NotFound()
                Else
                    Throw
                End If
            End Try

            Return StatusCode(HttpStatusCode.NoContent)
        End Function

        ' POST: api/Articulos
        <ResponseType(GetType(Articulo))>
        Async Function PostArticulo(ByVal articulo As Articulo) As Task(Of IHttpActionResult)
            If Not ModelState.IsValid Then
                Return BadRequest(ModelState)
            End If

            db.Articulos.Add(articulo)
            Await db.SaveChangesAsync()

            Return CreatedAtRoute("DefaultApi", New With {.id = articulo.ArticuloID}, articulo)
        End Function

        ' DELETE: api/Articulos/5
        <ResponseType(GetType(Articulo))>
        Async Function DeleteArticulo(ByVal id As Integer) As Task(Of IHttpActionResult)
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            If IsNothing(articulo) Then
                Return NotFound()
            End If

            db.Articulos.Remove(articulo)
            Await db.SaveChangesAsync()

            Return Ok(articulo)
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Private Function ArticuloExists(ByVal id As Integer) As Boolean
            Return db.Articulos.Count(Function(e) e.ArticuloID = id) > 0
        End Function
    End Class
End Namespace