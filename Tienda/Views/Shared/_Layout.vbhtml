<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Mi aplicación ASP.NET</title>
    @Styles.Render("~/Content/css")
    @Styles.Render("~/Content/kendo/css")
    @Scripts.Render("~/bundles/modernizr")
    @Scripts.Render("~/bundles/jquery")
    @Scripts.Render("~/bundles/kendo")
    @Scripts.Render("~/bundles/bootstrap")    
</head>
<body>
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                @Html.ActionLink("Demo formulario maestro-detalle con MVC", "Index", "Home", New With {.area = ""}, New With {.class = "navbar-brand"})
            </div>           
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li>@Html.ActionLink("Inicio", "Index", "Home")</li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Maestros <span class="caret"></span></a>
                        <ul class="dropdown-menu">
                            <li>@Html.ActionLink("Articulos", "Index", "Articulos")</li>
                            <li>@Html.ActionLink("Clientes", "Index", "Clientes")</li>
                            <li><a href="#">Something else here</a></li>
                            <li role="separator" class="divider"></li>
                            <li><a href="#">Separated link</a></li>
                        </ul>
                    </li>
                    <li>@Html.ActionLink("Pedidos", "Index", "Pedidos")</li>
                    <li>@Html.ActionLink("Acerca de", "About", "Home")</li>
                    <li>@Html.ActionLink("Contacto", "Contact", "Home")</li>
                </ul>
                @Html.Partial("_LoginPartial")
            </div>
        </div>
    </div>
    <div class="container body-content">        
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Mi aplicación ASP.NET</p>
        </footer>
    </div>

    @RenderSection("scripts", required:=False)
</body>
</html>
