﻿

Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Web
Imports Tienda.Models

Namespace Tienda.Services

    Public Class ArticulosService
        Implements IDisposable

        Private Shared UpdateDatabase As Boolean = False
        Private db As TiendaContext

        Public Sub New(db As TiendaContext)
            Me.db = db
        End Sub


        Public Function GetAll(request As DataSourceRequest) As IQueryable(Of Articulo)

            Return GenericService.Read(Me.db, "Articulo", request)

            ' Return db.Articulos.ToList()
            'IList<ProductViewModel> result = New List<ProductViewModel>()

            '    result = db.Products.Select(product => New ProductViewModel
            '    {
            '        ProductID = product.ProductID,
            '        ProductName = product.ProductName,
            '        UnitPrice = product.UnitPrice.HasValue ? product.UnitPrice.Value : Default(decimal),
            '        UnitsInStock = product.UnitsInStock.HasValue ? product.UnitsInStock.Value : Default(short),
            '        QuantityPerUnit = product.QuantityPerUnit,
            '        Discontinued = product.Discontinued,
            '        UnitsOnOrder = product.UnitsOnOrder.HasValue ? (int)product.UnitsOnOrder.Value : Default(int),
            '        CategoryID = product.CategoryID,
            '        Category = New CategoryViewModel()
            '        {
            '            CategoryID = product.Category.CategoryID,
            '            CategoryName = product.Category.CategoryName
            '        },
            '        LastSupply = DateTime.Today
            '    }).ToList();


            '    Return result;
        End Function

        Public Function Read(request As DataSourceRequest) As IList(Of Articulo)

            Dim resultado As IQueryable(Of Articulo)

            resultado = db.Articulos.AsQueryable()

            ' Aplico el filtro.
            For Each filtro As Expression(Of Func(Of Articulo, Boolean)) In request.Filtro
                resultado = resultado.Where(filtro)
            Next

            ' Aplico el orden.
            If request.Orden.Any Then
                For Each orden As Orden In request.Orden
                    If (orden.Direccion = SortDirection.Ascending) Then
                        resultado = resultado.OrderBy(Function(a) a.GetType().GetProperty(orden.Campo))
                    End If
                Next
            Else
                resultado = resultado.OrderBy(Function(a) a.ID)
            End If

            ' Aplico paginación
            Return resultado.Skip((request.Pagina - 1) * request.TamanyoPagina).Take(request.TamanyoPagina).ToList()

        End Function


        'Public void Create(ProductViewModel product)
        '    {
        '        If (!UpdateDatabase)
        '        {
        '            var first = GetAll().OrderByDescending(e >= e.ProductID).FirstOrDefault();
        '            var id = (first! = null) ? first.ProductID : 0;

        '            product.ProductID = id + 1;

        '            GetAll().Insert(0, product);
        '        }
        '        Else
        '        {
        '            var entity = New Product();

        '            entity.ProductName = product.ProductName;
        '            entity.UnitPrice = product.UnitPrice;
        '            entity.UnitsInStock = (short)product.UnitsInStock;
        '            entity.Discontinued = product.Discontinued;
        '            entity.CategoryID = product.CategoryID;

        '            If (entity.CategoryID == null)
        '            {
        '                entity.CategoryID = 1;
        '            }

        '            If (product.Category! = null)
        '            {
        '                entity.CategoryID = product.Category.CategoryID;
        '            }

        '            db.Products.Add(entity);
        '            db.SaveChanges();

        '            product.ProductID = entity.ProductID;
        '        }
        '    }

        '    Public void Update(ProductViewModel product)
        '    {
        '        If (!UpdateDatabase)
        '        {
        '            var target = One(e >= e.ProductID == product.ProductID);

        '            If (target! = null)
        '            {
        '                target.ProductName = product.ProductName;
        '                target.UnitPrice = product.UnitPrice;
        '                target.UnitsInStock = product.UnitsInStock;
        '                target.Discontinued = product.Discontinued;
        '                target.CategoryID = product.CategoryID;
        '                target.Category = product.Category;
        '            }
        '        }
        '        Else
        '        {
        '            var entity = New Product();

        '            entity.ProductID = product.ProductID;
        '            entity.ProductName = product.ProductName;
        '            entity.UnitPrice = product.UnitPrice;
        '            entity.UnitsInStock = (short)product.UnitsInStock;
        '            entity.Discontinued = product.Discontinued;
        '            entity.CategoryID = product.CategoryID;

        '            If (product.Category! = null)
        '            {
        '                entity.CategoryID = product.Category.CategoryID;
        '            }

        '            db.Products.Attach(entity);
        '            db.Entry(entity).State = EntityState.Modified;
        '            db.SaveChanges();
        '        }
        '    }

        '    Public void Destroy(ProductViewModel product)
        '    {
        '        If (!UpdateDatabase)
        '        {
        '            var target = GetAll().FirstOrDefault(p >= p.ProductID == product.ProductID);
        '            If (target! = null)
        '            {
        '                GetAll().Remove(target);
        '            }
        '        }
        '        Else
        '        {
        '            var entity = New Product();

        '            entity.ProductID = product.ProductID;

        '            db.Products.Attach(entity);

        '            db.Products.Remove(entity);

        '            var orderDetails = db.Order_Details.Where(pd >= pd.ProductID == entity.ProductID);

        '            foreach (var orderDetail in orderDetails)
        '            {
        '                db.Order_Details.Remove(orderDetail);
        '            }

        '            db.SaveChanges();
        '        }
        '    }

        '    Public ProductViewModel One(Func<ProductViewModel, bool> predicate)
        '    {
        '        Return GetAll().FirstOrDefault(predicate);
        '    }

        Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
            db.Dispose()
        End Sub

    End Class

End Namespace
