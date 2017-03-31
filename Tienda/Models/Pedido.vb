Imports System.ComponentModel.DataAnnotations

Public Class Pedido

    <Key>
    Public Property PedidoID As Integer

    <Required>
    Public Property ClienteID As Integer

    Public Property Cliente As Cliente

    <Required>
    Public Property Fecha() As DateTime

    Public Property LineasPedido As List(Of LineaPedido)

End Class
