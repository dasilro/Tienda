Imports System.Data.Entity

Namespace Models
    
    Public Class TiendaContext
        Inherits DbContext
    
        ' You can add custom code to this file. Changes will not be overwritten.
        ' 
        ' If you want Entity Framework to drop and regenerate your database
        ' automatically whenever you change your model schema, please use data migrations.
        ' For more information refer to the documentation:
        ' http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        Public Sub New()
            MyBase.New("name=TiendaContext")
        End Sub

        Public Property Articulos As System.Data.Entity.DbSet(Of Articulo)
        Public Property Clientes As System.Data.Entity.DbSet(Of Cliente)
        Public Property Pedidos As System.Data.Entity.DbSet(Of Pedido)
        Public Property LineaPedidos As System.Data.Entity.DbSet(Of LineaPedido)
    End Class
    
End Namespace
