Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations

Public Class Articulo

    <Key>
    Public Property ArticuloID As Integer

    <Required>
    Public Property Descripcion As String

    Public Property DescripcionLarga As String

    <Required>
    <DefaultValue(0)>
    Public Property PrecioUnitario As Decimal

End Class
