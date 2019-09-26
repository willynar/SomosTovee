using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SomosTovee
{
    public partial class Inicio : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
           ocultarElementos();
        }
        public void ocultarElementos()
        {
            ((landing)Master).lknAcercaLandVisible = false;
            ((landing)Master).lknNoticiasLandVisible = false;
            ((landing)Master).lknContactoLandVisible = false;
            ((landing)Master).lknInicioVisible = false;
            ((landing)Master).headerMastheadVisible = false;
            ((landing)Master).lknGruposLandVisible = true;
            ((landing)Master).lknLandigVisible = true; 
            ((landing)Master).triggerModalVisible = true; 
        }
    }
}