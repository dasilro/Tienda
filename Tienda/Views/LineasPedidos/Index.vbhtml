@ModelType IEnumerable(Of Tienda.LineaPedido)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.Articulo.Descripcion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Pedido.PedidoID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Cantidad)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PrecioUnitario)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Descuento)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PorcentajeIva)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.TotalBaseImponible)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Articulo.Descripcion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Pedido.PedidoID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cantidad)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PrecioUnitario)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Descuento)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PorcentajeIva)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.TotalBaseImponible)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.LineaPedidoID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.LineaPedidoID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.LineaPedidoID })
        </td>
    </tr>
Next

</table>
