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
                                                                                                                                                                                                                                                               columns.Bound(Function(p) p.ID).Width(50)
                                                                                                                                                                                                                                                               columns.Bound(Function(p) p.Descripcion)
                                                                                                                                                                                                                                                               columns.Bound(Function(p) p.PrecioUnitario).Format("{0:###,###,##0.00 €}").Width(64)
                                                                                                                                                                                                                                                               columns.Command(Sub(c) c.Custom("Editar").Click("MostrarEditor")).Width(50)
                                                                                                                                                                                                                                                               columns.Command(Sub(c) c.Destroy()).Width(50)
                                                                                                                                                                                                                                                           End Sub) _
                                                                                                                                                                                                                                                  .Sortable() _
                                                                                                                                                                                                                                                  .Pageable() _
                                                                                                                                                                                                                                                  .Filterable() _
                                                                                                                                                                                                                                                  .Events(Function(e) e.DataBound("onRowBound")) _
                                                                                                                                                                                                                                                  .DataSource(Function(d) _
                                                                                                                                                                                               d.WebApi() _
                                                                                                                                                                                                .Model(Sub(m)
                                                                                                                                                                                                           m.Id(Function(i) i.ID)
                                                                                                                                                                                                       End Sub) _
                                                                                                                                                                         .Read(Function(read) read.Url(Url.HttpRouteUrl("GetArticulos", New With {.HttpRoute = True, .Controller = "ApiArticulos"}))) _
                                                                                                                                                                         .Destroy(Function(destroy) destroy.Url(Url.HttpRouteUrl("DeleteArticulo", New With {.HttpRoute = True, .Controller = "ApiArticulos", .id = "{0}"}))))
            )
@*'columns.Command(Sub(c) c.Edit()).Width(50)
' columns.Command(Sub(c) c.Custom("Editar").Click("MostrarEditor")).Width(50)*@

@*.Update(Function(update) update.Url(Url.HttpRouteUrl("PutArticulo", New With {.HttpRoute = True, .Controller = "ApiArticulos", .id = "{0}"}))) _*@

@(Html.Kendo().Window().Name("Editor") _
                                                                .Title("Editor de artículos") _
                                                                .Height(500) _
                                                                .Width(500) _
                                                                .Draggable() _
                                                                .Resizable() _
                                                                .Visible(False) _
                                                                .Modal(True)
)

<script>
    function MostrarEditor(e) {
        e.preventDefault();

        var dataItem = this.dataItem($(e.currentTarget).closest("tr"));
        var wnd = $("#Editor").data("kendoWindow");
        wnd.refresh({
            url: "../Articulos/Edit",
            data: { Id: dataItem.ID }
        });
        wnd.center().open();
    }

    function onRowBound(e) {
       $(".k-grid-Editar").find("span").addClass("k-icon k-i-edit");        
    }

    //function error_handler(e) { var errors = $.parseJSON(e.xhr.responseText); if (errors) alert("Errors:\n" + errors.join("\n")}
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
