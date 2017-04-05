Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("Pedidos")>
Public Class Pedido
    Inherits Entity

    <Required>
    Public Property ClienteID As Integer

    Public Property Cliente As Cliente

    <Required>
    Public Property Fecha() As DateTime

    Public Property LineasPedido As List(Of LineaPedido)

End Class
