@ModelType IEnumerable(Of Tienda.Articulo)
@Code
	ViewData("Title") = "Artículos"
End Code



<h2>Búsqueda de artículos.</h2>

<p>
    @*@Html.ActionLink("Create New", "Create")*@
</p>


<script>

</script>


@(Html.Kendo().Grid(Of Tienda.Articulo)() _
				.ToolBar(Function(tool) tool.Custom.Text("Nuevo").HtmlAttributes(New With {.ID = "btnCrearArticulo"})) _
											.Name("grid") _
											.Columns(Sub(columns)
														 columns.Bound(Function(p) p.ID).Width(50)
														 columns.Bound(Function(p) p.Descripcion)
														 columns.Bound(Function(p) p.PrecioUnitario).Format("{0:n2}").Width(64)
														 columns.Command(Sub(c) c.Custom("Editar").Click("MostrarEditor")).Width(50)
														 columns.Command(Sub(c) c.Destroy()).Width(50)
													 End Sub) _
				.Sortable() _
				.Pageable() _
				.Filterable() _
				.Events(Function(e) e.DataBound("onRowBound")) _
				.DataSource(Function(d) _
				d.WebApi() _
				.Events(Function(e) e.Error("error_handler")) _
				.Model(Sub(m)
						   m.Id(Function(i) i.ID)
					   End Sub) _
				.Read(Function(read) read.Url(Url.HttpRouteUrl("GetArticulos", New With {.HttpRoute = True, .Controller = "ApiArticulos"}))) _
				.Destroy(Function(destroy) destroy.Url(Url.HttpRouteUrl("DeleteArticulo", New With {.HttpRoute = True, .Controller = "ApiArticulos", .id = "{0}"}))))
)

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
    $(document).ready(function () {

        $("#btnCrearArticulo").find("span").addClass("k-icon k-i-add");

        $("#btnCrearArticulo").click(function (e) {
            e.preventDefault();
           
            var wnd = $("#Editor").data("kendoWindow");
            wnd.refresh({
                url: "../Articulos/Create"
            });
            wnd.center().open();
        });

    });
       

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

    function error_handler(e) {
        var errors = $.parseJSON(e.xhr.responseText);

        if (errors) {
            alert("Errors:\n" + errors.join("\n"));
        }
    }
</script>
