@ModelType Tienda.Pedido
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Pedido</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Cliente.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Cliente.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Fecha)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Fecha)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.PedidoID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
