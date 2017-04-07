Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations.Schema
Imports System.ComponentModel.DataAnnotations
Imports System.Data.Entity
Imports Microsoft.AspNet

<Table("Articulos")>
Public Class Articulo
    Inherits Entity

    <Required>
    Public Property Descripcion As String

    Public Property DescripcionLarga As String

    ' <DisplayFormat(DataFormatString:="{0:###,###,##0.00}")>
    <Required>
    <DefaultValue(0.01)>
    <Range(0.01, 999999999, ErrorMessage:="El precio debe ser un número entre 0.01 y 999999999")>
    <DisplayName("Precio unitario (€)")>
    Public Property PrecioUnitario As Decimal

End Class
