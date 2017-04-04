@ModelType IEnumerable(Of Tienda.Articulo)
@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>

@(Html.Kendo().Grid(Of Tienda.Articulo)() _
                                                                                                                                            .Name("grid") _
                                                                                                                                            .Columns(Sub(columns)
                                                                                                                                                         columns.Bound(Function(p) p.ID)
                                                                                                                                                         columns.Bound(Function(p) p.Descripcion).Width(100)
                                                                                                                                                         columns.Command(Sub(c) c.Edit()).Width(86)
                                                                                                                                                         columns.Command(Sub(c) c.Destroy()).Width(86)
                                                                                                                                                     End Sub) _
                                                                                                                                                        .Sortable() _
                                                                                                                                                        .Pageable() _
                                                                                                                                                        .Filterable() _
                                                                                                                                                        .DataSource(Function(d) _
                                                                                                                                                                            d.WebApi() _
                                                                                                                                                                            .Model(Sub(m)
                                                                                                                                                                                       m.Id(Function(i) i.ID)
                                                                                                                                                                                   End Sub) _
                            .Read(Function(read) read.Action("Person_Read", "GridList")) _
                            .Events(Function(events) events.Error("error_handler"))
                          )
)

<script>
    function error_handler(e)            var errors = $.parseJSON(e.xhr.responseText); if (errors) alert("Errors:\n" + errors.join("\n")                }
}
</script>
@*<table class="table">
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

    </table>*@
