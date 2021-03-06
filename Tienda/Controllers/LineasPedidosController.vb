﻿Imports System
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

    <Authorize>
    <RoutePrefix("LineasPedidos")>
    Public Class LineasPedidosController
        Inherits System.Web.Mvc.Controller

        Private db As New TiendaContext

        ' GET: LineasPedidos        
        <Route("Index")>
        Async Function Index() As Task(Of ActionResult)
            Dim lineaPedidoes = db.LineaPedidos.Include(Function(l) l.Articulo).Include(Function(l) l.Pedido)
            Return View(Await lineaPedidoes.ToListAsync())
        End Function

        ' GET: LineasPedidos/Details/5
        <Route("Details/{id:integer}")>
        Async Function Details(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim lineaPedido As LineaPedido = Await db.LineaPedidos.FindAsync(id)
            If IsNothing(lineaPedido) Then
                Return HttpNotFound()
            End If
            Return View(lineaPedido)
        End Function

        ' GET: LineasPedidos/Create
        <Route("Create")>
        Function Create() As ActionResult
            ViewBag.ArticuloID = New SelectList(db.Articulos, "ArticuloID", "Descripcion")
            ViewBag.PedidoID = New SelectList(db.Pedidos, "PedidoID", "PedidoID")
            Return View()
        End Function

        ' POST: LineasPedidos/Create
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Route("Create")>
        Async Function Create(<Bind(Include:="LineaPedidoID,PedidoID,ArticuloID,Cantidad,PrecioUnitario,Descuento,PorcentajeIva,TotalBaseImponible")> ByVal lineaPedido As LineaPedido) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.LineaPedidos.Add(lineaPedido)
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ArticuloID = New SelectList(db.Articulos, "ArticuloID", "Descripcion", lineaPedido.ArticuloID)
            ViewBag.PedidoID = New SelectList(db.Pedidos, "PedidoID", "PedidoID", lineaPedido.PedidoID)
            Return View(lineaPedido)
        End Function

        ' GET: LineasPedidos/Edit/5
        <Route("Edit/{id:integer}")>
        Async Function Edit(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim lineaPedido As LineaPedido = Await db.LineaPedidos.FindAsync(id)
            If IsNothing(lineaPedido) Then
                Return HttpNotFound()
            End If
            ViewBag.ArticuloID = New SelectList(db.Articulos, "ArticuloID", "Descripcion", lineaPedido.ArticuloID)
            ViewBag.PedidoID = New SelectList(db.Pedidos, "PedidoID", "PedidoID", lineaPedido.PedidoID)
            Return View(lineaPedido)
        End Function

        ' POST: LineasPedidos/Edit/5
        'Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        'más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        <HttpPost()>
        <ValidateAntiForgeryToken()>
        <Route("Edit")>
        Async Function Edit(<Bind(Include:="LineaPedidoID,PedidoID,ArticuloID,Cantidad,PrecioUnitario,Descuento,PorcentajeIva,TotalBaseImponible")> ByVal lineaPedido As LineaPedido) As Task(Of ActionResult)
            If ModelState.IsValid Then
                db.Entry(lineaPedido).State = EntityState.Modified
                Await db.SaveChangesAsync()
                Return RedirectToAction("Index")
            End If
            ViewBag.ArticuloID = New SelectList(db.Articulos, "ArticuloID", "Descripcion", lineaPedido.ArticuloID)
            ViewBag.PedidoID = New SelectList(db.Pedidos, "PedidoID", "PedidoID", lineaPedido.PedidoID)
            Return View(lineaPedido)
        End Function

        ' GET: LineasPedidos/Delete/5
        <Route("Delete/{id:integer}")>
        Async Function Delete(ByVal id As Integer?) As Task(Of ActionResult)
            If IsNothing(id) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If
            Dim lineaPedido As LineaPedido = Await db.LineaPedidos.FindAsync(id)
            If IsNothing(lineaPedido) Then
                Return HttpNotFound()
            End If
            Return View(lineaPedido)
        End Function

        ' POST: LineasPedidos/Delete/5
        <HttpPost()>
        <ActionName("Delete")>
        <ValidateAntiForgeryToken()>
        <Route("Delete/{id:integer}")>
        Async Function DeleteConfirmed(ByVal id As Integer) As Task(Of ActionResult)
            Dim lineaPedido As LineaPedido = Await db.LineaPedidos.FindAsync(id)
            db.LineaPedidos.Remove(lineaPedido)
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
