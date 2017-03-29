@ModelType Tienda.Articulo
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Articulo</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Descripcion)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Descripcion)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DescripcionLarga)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DescripcionLarga)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.PrecioUnitario)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.PrecioUnitario)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ArticuloID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
