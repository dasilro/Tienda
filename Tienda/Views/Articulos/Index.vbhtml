@ModelType IEnumerable(Of Tienda.Articulo)
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
            @Html.DisplayNameFor(Function(model) model.Descripcion)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DescripcionLarga)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.PrecioUnitario)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Descripcion)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DescripcionLarga)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.PrecioUnitario)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ArticuloID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ArticuloID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ArticuloID })
        </td>
    </tr>
Next

</table>
