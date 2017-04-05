Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("LineasPedidos")>
Public Class LineaPedido
    Inherits Entity

    <Required>
    Public Property PedidoID As Integer

    Public Property Pedido As Pedido

    <Required>
    Public Property ArticuloID As Integer

    Public Property Articulo As Articulo

    <Required>
    <DefaultValue(1)>
    Public Property Cantidad As Decimal

    <Required>
    <DefaultValue(0)>
    Public Property PrecioUnitario As Decimal

    <Required>
    <DefaultValue(0)>
    Public Property Descuento As Decimal

    <Required>
    <DefaultValue(21.0)>
    Public Property PorcentajeIva As Decimal

    Public Property TotalBaseImponible As Decimal

End Class
