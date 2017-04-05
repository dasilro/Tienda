Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class Initial
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Articulos",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Descripcion = c.String(nullable := False),
                        .DescripcionLarga = c.String(),
                        .PrecioUnitario = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.Clientes",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 256),
                        .IdentificadorFiscal = c.String(nullable := False, maxLength := 32)
                    }) _
                .PrimaryKey(Function(t) t.ID)
            
            CreateTable(
                "dbo.LineasPedidos",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .PedidoID = c.Int(nullable := False),
                        .ArticuloID = c.Int(nullable := False),
                        .Cantidad = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .PrecioUnitario = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Descuento = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .PorcentajeIva = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .TotalBaseImponible = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Articulos", Function(t) t.ArticuloID, cascadeDelete := True) _
                .ForeignKey("dbo.Pedidos", Function(t) t.PedidoID, cascadeDelete := True) _
                .Index(Function(t) t.PedidoID) _
                .Index(Function(t) t.ArticuloID)
            
            CreateTable(
                "dbo.Pedidos",
                Function(c) New With
                    {
                        .ID = c.Int(nullable := False, identity := True),
                        .ClienteID = c.Int(nullable := False),
                        .Fecha = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.ID) _
                .ForeignKey("dbo.Clientes", Function(t) t.ClienteID, cascadeDelete := True) _
                .Index(Function(t) t.ClienteID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.LineasPedidos", "PedidoID", "dbo.Pedidos")
            DropForeignKey("dbo.Pedidos", "ClienteID", "dbo.Clientes")
            DropForeignKey("dbo.LineasPedidos", "ArticuloID", "dbo.Articulos")
            DropIndex("dbo.Pedidos", New String() { "ClienteID" })
            DropIndex("dbo.LineasPedidos", New String() { "ArticuloID" })
            DropIndex("dbo.LineasPedidos", New String() { "PedidoID" })
            DropTable("dbo.Pedidos")
            DropTable("dbo.LineasPedidos")
            DropTable("dbo.Clientes")
            DropTable("dbo.Articulos")
        End Sub
    End Class
End Namespace
