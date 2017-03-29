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
    Public Class PedidosController
        Inherits System.Web.Mvc.Controller

        Private db As New TiendaContext

        ' GET: Pedidos
        Async Function Index() As Task(Of ActionResult)
            Dim pedidoes = db.Pedidoes.Include(Function(p) p.Cliente)
            Return View(Await pedidoes.ToListAsync())
        End Function

        ' GET: Pedidos/Details/5
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pedido As Pedido = Await db.Pedidoes.FindAsync(id)
            If IsNothing(pedido) Then
                Return HttpNotFound()
            End If
            Return View(pedido)
        End Function

        ' GET: Pedidos/Create
        Function Create() As ActionResult
            ViewBag.ClienteID = New SelectList(db.Clientes, "ClienteID", "Nombre")
            Return View()
        End Function

        ' POST: Pedidos/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Create(<Bind(Include:="PedidoID,FacturaID,ClienteID,Fecha")> ByVal pedido As Pedido) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Pedidoes.Add(pedido)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteID = New SelectList(db.Clientes, "ClienteID", "Nombre", pedido.ClienteID)
            Return View(pedido)
        End Function

        ' GET: Pedidos/Edit/5
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pedido As Pedido = Await db.Pedidoes.FindAsync(id)
            If IsNothing(pedido) Then
                Return HttpNotFound()
            End If
            ViewBag.ClienteID = New SelectList(db.Clientes, "ClienteID", "Nombre", pedido.ClienteID)
            Return View(pedido)
        End Function

        ' POST: Pedidos/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        Async Function Edit(<Bind(Include:="PedidoID,FacturaID,ClienteID,Fecha")> ByVal pedido As Pedido) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(pedido).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ClienteID = New SelectList(db.Clientes, "ClienteID", "Nombre", pedido.ClienteID)
            Return View(pedido)
        End Function

        ' GET: Pedidos/Delete/5
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim pedido As Pedido = Await db.Pedidoes.FindAsync(id)
            If IsNothing(pedido) Then
                Return HttpNotFound()
            End If
            Return View(pedido)
        End Function

        ' POST: Pedidos/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim pedido As Pedido = Await db.Pedidoes.FindAsync(id)
            db.Pedidoes.Remove(pedido)
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
