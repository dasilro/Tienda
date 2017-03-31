Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Entity
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Net
Imports System.Web
Imports System.Web.Mvc
Imports Tienda
Imports Tienda.Models

Namespace Controllers

    <RoutePrefix("Articulos")>
    Public Class ArticulosController
        Inherits System.Web.Mvc.Controller

        Private db As New TiendaContext

        ' GET: Articulos
        <HttpGet>
        <Route("Index")>
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Articulos.ToListAsync())
        End Function

        ' GET: Articulos/Details/5
        <HttpGet>
        <Route("Details/{id:integer}")>
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            If IsNothing(articulo) Then
                Return HttpNotFound()
            End If
            Return View(articulo)
        End Function

        ' GET: Articulos/Create
        <HttpGet>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Articulos/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Create(<Bind(Include:="ArticuloID,Descripcion,DescripcionLarga,PrecioUnitario")> ByVal articulo As Articulo) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Articulos.Add(articulo)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(articulo)
        End Function

        ' GET: Articulos/Edit/5
        <HttpGet>
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            If IsNothing(articulo) Then
                Return HttpNotFound()
            End If
            Return View(articulo)
        End Function

        ' POST: Articulos/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost>
        <ValidateAntiForgeryToken>
        Async Function Edit(<Bind(Include:="ArticuloID,Descripcion,DescripcionLarga,PrecioUnitario")> ByVal articulo As Articulo) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(articulo).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(articulo)
        End Function

        ' GET: Articulos/Delete/5
        <HttpGet>
        <ValidateAntiForgeryToken>
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            If IsNothing(articulo) Then
                Return HttpNotFound()
            End If
            Return View(articulo)
        End Function

        ' POST: Articulos/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim articulo As Articulo = Await db.Articulos.FindAsync(id)
            db.Articulos.Remove(articulo)
            Await db.SaveChangesAsync()
            Return RedirectToAction("Index")
        End Function

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If (disposing) Then
                db.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Namespace
