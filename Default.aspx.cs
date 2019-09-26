using SomosTovee.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SomosTovee
{
    public partial class _default : System.Web.UI.Page
    {
        DatosPagina datos = new DatosPagina();
        Utilidades validar = new Utilidades();
        private Button btnAdd = new Button();
        landing mas = new landing();
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void txtSuscribete_Click(object sender, EventArgs e)
        {
            string correo, nombre;
            double celular;
            if (validar.validarTextoVacio(txtNombreSuscribe))
            {
                validar.remplazarInvalidoCss(txtNombreSuscribe);

                if (validar.validarTextoVacio(txtMovilSuscribe))
                {
                    validar.remplazarInvalidoCss(txtMovilSuscribe);

                    if (validar.validarTextoVacio(txtEmailSuscribe))
                    {
                        nombre = txtNombreSuscribe.Text.Trim();
                        celular = Convert.ToDouble(txtMovilSuscribe.Text.Trim());
                        correo = txtEmailSuscribe.Text.Trim();
                        int result = datos.guardarSuscriptor(nombre, celular, correo);
                        if (result != 1)
                        {
                            Response.Write("<script>alert('')</script>");
                            txtNombreSuscribe.Text = "";
                            txtMovilSuscribe.Text = "";
                            txtEmailSuscribe.Text = "";
                            TextBox[] ids = { txtNombreSuscribe, txtMovilSuscribe, txtEmailSuscribe };
                            validar.quitarValidoCss(ids);
                        }
                        else
                        {
                            //Response.Write("<script>alert('')</script>");
                        }
                    }
                    else
                    {
                        //txtEmailSuscribe.CssClass
                        //Response.Write("<script>alert('Para subscribirse debe ingresar un correo primero')</script>");
                        validar.agregarinvalidoCss(txtEmailSuscribe);

                    }
                }
                else
                {
                    validar.agregarinvalidoCss(txtMovilSuscribe);
                }
            }
            else
            {
                validar.agregarinvalidoCss(txtNombreSuscribe);
            }

        }
    }
}