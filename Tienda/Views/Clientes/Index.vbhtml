@ModelType IEnumerable(Of Tienda.Cliente)
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
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.IdentificadorFiscal)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Nombre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.IdentificadorFiscal)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.ClienteID }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.ClienteID }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.ClienteID })
        </td>
    </tr>
Next

</table>
