@ModelType Tienda.Cliente
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Cliente</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.Nombre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Nombre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.IdentificadorFiscal)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.IdentificadorFiscal)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.ClienteID }) |
    @Html.ActionLink("Back to List", "Index")
</p>
