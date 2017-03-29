@ModelType Tienda.Articulo
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
