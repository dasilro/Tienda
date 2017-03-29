@ModelType IEnumerable(Of Tienda.Pedido)
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
            @Html.DisplayNameFor(Function(model) model.Cliente.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.FacturaID)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Cliente.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.FacturaID)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Fecha)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.PedidoID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.PedidoID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.PedidoID })
        </td>
    </tr>
Next

</table>
