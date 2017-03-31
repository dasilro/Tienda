Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Articuloes",
                Function(c) New With
                    {
                        .ArticuloID = c.Int(nullable := False, identity := True),
                        .Descripcion = c.String(nullable := False),
                        .DescripcionLarga = c.String(),
                        .PrecioUnitario = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.ArticuloID)
            
            CreateTable(
                "dbo.Clientes",
                Function(c) New With
                    {
                        .ClienteID = c.Int(nullable := False, identity := True),
                        .Nombre = c.String(nullable := False, maxLength := 256),
                        .IdentificadorFiscal = c.String(nullable := False, maxLength := 32)
                    }) _
                .PrimaryKey(Function(t) t.ClienteID)
            
            CreateTable(
                "dbo.LineaPedidoes",
                Function(c) New With
                    {
                        .LineaPedidoID = c.Int(nullable := False, identity := True),
                        .PedidoID = c.Int(nullable := False),
                        .ArticuloID = c.Int(nullable := False),
                        .Cantidad = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .PrecioUnitario = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .Descuento = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .PorcentajeIva = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .TotalBaseImponible = c.Decimal(nullable := False, precision := 18, scale := 2)
                    }) _
                .PrimaryKey(Function(t) t.LineaPedidoID) _
                .ForeignKey("dbo.Articuloes", Function(t) t.ArticuloID, cascadeDelete := True) _
                .ForeignKey("dbo.Pedidoes", Function(t) t.PedidoID, cascadeDelete := True) _
                .Index(Function(t) t.PedidoID) _
                .Index(Function(t) t.ArticuloID)
            
            CreateTable(
                "dbo.Pedidoes",
                Function(c) New With
                    {
                        .PedidoID = c.Int(nullable := False, identity := True),
                        .FacturaID = c.Int(nullable := False),
                        .ClienteID = c.Int(nullable := False),
                        .Fecha = c.DateTime(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.PedidoID) _
                .ForeignKey("dbo.Clientes", Function(t) t.ClienteID, cascadeDelete := True) _
                .Index(Function(t) t.ClienteID)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.LineaPedidoes", "PedidoID", "dbo.Pedidoes")
            DropForeignKey("dbo.Pedidoes", "ClienteID", "dbo.Clientes")
            DropForeignKey("dbo.LineaPedidoes", "ArticuloID", "dbo.Articuloes")
            DropIndex("dbo.Pedidoes", New String() { "ClienteID" })
            DropIndex("dbo.LineaPedidoes", New String() { "ArticuloID" })
            DropIndex("dbo.LineaPedidoes", New String() { "PedidoID" })
            DropTable("dbo.Pedidoes")
            DropTable("dbo.LineaPedidoes")
            DropTable("dbo.Clientes")
            DropTable("dbo.Articuloes")
        End Sub
    End Class
End Namespace
