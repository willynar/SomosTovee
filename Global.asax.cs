using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace SomosTovee
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            rutasAmigables();
        }
        void rutasAmigables()
        {
            RouteTable.Routes.MapPageRoute("landing", "landing", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("grupos", "grupos", "~/Grupos.aspx");
            RouteTable.Routes.MapPageRoute("inicio", "inicio", "~/Inicio.aspx");
            RouteTable.Routes.MapPageRoute("menuAdministrador", "menuAdministrador", "~/AdminMenu.aspx");
            RouteTable.Routes.MapPageRoute("menuUsuario", "menuUsuario", "~/usuarioMenu.aspx");

            
            //RouteTable.Routes.MapPageRoute("producto", "categoria/{idCategoria}/{producto}/{*pagina}", "~/producto.aspx");

        }

    }
}