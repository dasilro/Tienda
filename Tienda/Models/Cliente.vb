Imports System.ComponentModel.DataAnnotations

Public Class Cliente
    Inherits Entity

    <Required>
    <StringLength(256, ErrorMessage:="El nombre del cliente tendrá entre 3 y 256 caracteres.", MinimumLength:=3)>
    Public Property Nombre As String

    <Required>
    <StringLength(32, ErrorMessage:="El identificador fiscal tendrá entre 9 y 32 caracteres.", MinimumLength:=9)>
    Public Property IdentificadorFiscal() As String

End Class
