@ModelType Tienda.LineaPedido
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<div>
    <h4>LineaPedido</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Articulo.Descripcion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Articulo.Descripcion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Pedido.PedidoID)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Pedido.PedidoID)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Cantidad)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cantidad)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PrecioUnitario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PrecioUnitario)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Descuento)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descuento)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PorcentajeIva)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PorcentajeIva)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.TotalBaseImponible)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.TotalBaseImponible)
        </dd>

    </dl>
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
