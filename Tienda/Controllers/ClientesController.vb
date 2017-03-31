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

    <RoutePrefix("Clientes")>
    Public Class ClientesController
        Inherits System.Web.Mvc.Controller

        Private db As New TiendaContext

        ' GET: Clientes
        <HttpGet>
        <Route("Index")>
        Async Function Index() As Task(Of ActionResult)
            Return View(Await db.Clientes.ToListAsync())
        End Function

        ' GET: Clientes/Details/5
        <HttpGet>
        <Route("Details")>
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cliente As Cliente = Await db.Clientes.FindAsync(id)
            If IsNothing(cliente) Then
                Return HttpNotFound()
            End If
            Return View(cliente)
        End Function

        ' GET: Clientes/Create
        <HttpGet>
        <Route("Create")>
        Function Create() As ActionResult
            Return View()
        End Function

        ' POST: Clientes/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Route("Create")>
        Async Function Create(<Bind(Include:="ClienteID,Nombre,IdentificadorFiscal")> ByVal cliente As Cliente) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Clientes.Add(cliente)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(cliente)
        End Function

        ' GET: Clientes/Edit/5
        <HttpGet>
        <Route("Edit/{id:integer}")>
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cliente As Cliente = Await db.Clientes.FindAsync(id)
            If IsNothing(cliente) Then
                Return HttpNotFound()
            End If
            Return View(cliente)
        End Function

        ' POST: Clientes/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken>
        <Route("Edit")>
        Async Function Edit(<Bind(Include:="ClienteID,Nombre,IdentificadorFiscal")> ByVal cliente As Cliente) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(cliente).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            Return View(cliente)
        End Function

        ' GET: Clientes/Delete/5
        <HttpGet>
        <Route("Delete/{id:integer}")>
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim cliente As Cliente = Await db.Clientes.FindAsync(id)
            If IsNothing(cliente) Then
                Return HttpNotFound()
            End If
            Return View(cliente)
        End Function

        ' POST: Clientes/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <Route("Delete/{id:integer}")>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim cliente As Cliente = Await db.Clientes.FindAsync(id)
            db.Clientes.Remove(cliente)
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
