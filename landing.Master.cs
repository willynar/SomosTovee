using SomosTovee.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SomosTovee
{
    public partial class landing : System.Web.UI.MasterPage
    {
        DatosPagina datos = new DatosPagina();
        Utilidades validar = new Utilidades();
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {

            DataTable tabla = new DataTable();
            tabla = datos.consultarContactos();
            if (tabla.Columns.Contains("Error"))
            {
                Response.Write("<script>alert('Ocurrio un error al traer contactos pagina')</script>");
            }
            else
            {
                if (tabla.Rows.Count != 0)
                {
                    DataRow row = tabla.Rows[0];
                    lknYoutube.NavigateUrl = row["youtube"].ToString();
                    lknFacebook.NavigateUrl = row["facebook"].ToString();
                    lknInstagram.NavigateUrl = row["instagram"].ToString();
                    lblCorreo.Text = row["correo"].ToString();
                    lblDireccion.Text = row["direccion"].ToString();
                    lblTelefonos.Text = row["telefono"].ToString() + " - " + row["celular"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Ocurrio un error al traer contactos pagina')</script>");

                }
            }
            if (Session["rol"] != null)
            {
                lknCerrarSession.Visible = true;
            }
            else
            {
                lknCerrarSession.Visible = false;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        protected void lknCerrarSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("inicio");
        }

        protected void btnIniciarSession_Click(object sender, EventArgs e)
        {
            string correo, contraseña;
            int result;
            if (txtCorreoIniciar.Text.Trim() != "")
            {
                validar.remplazarInvalidoCss(txtCorreoIniciar);

                if (txtContraseñaIniciar.Text.Trim() != "")
                {
                    validar.removerInvalidoCss(txtContraseñaIniciar);

                    correo = txtCorreoIniciar.Text.Trim();
                    contraseña = txtContraseñaIniciar.Text.Trim();
                    result = usuario.login(correo, contraseña);
                    switch (result)
                    {
                        case 1:
                            switch (Convert.ToInt32(Session["rol"]))
                            {
                                case 1:
                                    Response.Redirect("menuAdministrador");
                                    break;
                                case 2:
                                    Response.Redirect("menuUsuario");
                                    break;
                                default:
                                    Session.Abandon();
                                    Session.Clear();
                                    Response.Redirect("inicio");
                                    break;
                            }
                            break;
                        case 2 | 3:
                            contenidoModalInformacion.Text = "Ocurrio un error por fabor contacte con el administrador de la pagina";
                            abrirModalInformacion();
                            break;
                        case 4:
                            lblErrorCorreoVacioLogin.Visible = false;
                            lblNoExisteCorreoLogin.Visible = true;
                            validar.remplazarValid(txtCorreoIniciar);
                            abrirModal();
                            break;
                        case 5:
                            lblErrorContraseñaVacioLogin.Visible = false;
                            lblNoExisteContraseñaLogin.Visible = true;
                            validar.remplazarValid(txtContraseñaIniciar);
                            abrirModal();
                            break;
                        default:
                            Session.Abandon();
                            Session.Clear();
                            Response.Redirect("inicio");
                            break;
                    }

                }
                else
                {
                    if (lblErrorCorreoVacioLogin.Visible == false)
                    {
                        lblErrorContraseñaVacioLogin.Visible = true;
                        lblNoExisteContraseñaLogin.Visible = false;
                    }
                    validar.agregarinvalidoCss(txtContraseñaIniciar);
                    abrirModal();
                }
            }
            else
            {
                if (lblErrorCorreoVacioLogin.Visible == false)
                {
                    lblErrorCorreoVacioLogin.Visible = true;
                    lblNoExisteCorreoLogin.Visible = false;
                }
                validar.agregarinvalidoCss(txtCorreoIniciar);
                abrirModal();
            }
        }
        public string contentModalInformacion
        {
            get { return contenidoModalInformacion.Text; }
            set { contenidoModalInformacion.Text = value; }
        }
        public bool lknAcercaLandVisible
        {
            get { return lknAcercaLand.Visible; }
            set { lknAcercaLand.Visible = value; }
        }
        public bool lknNoticiasLandVisible
        {
            get { return lknNoticiasLand.Visible; }
            set { lknNoticiasLand.Visible = value; }
        }
        public bool lknContactoLandVisible
        {
            get { return lknContactoLand.Visible; }
            set { lknContactoLand.Visible = value; }
        }
        public bool headerMastheadVisible
        {
            get { return headerMasthead.Visible; }
            set { headerMasthead.Visible = value; }
        }
        public bool lknLandigVisible
        {
            get { return lknLandig.Visible; }
            set { lknLandig.Visible = value; }
        }
        public bool lknGruposLandVisible
        {
            get { return lknGruposLand.Visible; }
            set { lknGruposLand.Visible = value; }
        }
        public bool triggerModalVisible
        {
            get { return triggerModal.Visible; }
            set { triggerModal.Visible = value; }
        }
        //public bool lknRegistrarUsuariosVisible
        //{
        //    get { return lknRegistrarUsuarios.Visible; }
        //    set { lknRegistrarUsuarios.Visible = value; }
        //}
        public bool lknActualizarContactosVisible
        {
            get { return lknActualizarContactos.Visible; }
            set { lknActualizarContactos.Visible = value; }
        }
        public bool lknInicioVisible
        {
            get { return lknInicio.Visible; }
            set { lknInicio.Visible = value; }
        }
        private void abrirModal()
        {
            Response.Write("<script src='Assets/lib/startbootstrap-grayscale/vendor/jquery/jquery.min.js'></script>" +
                           "<script type='text/javascript'>function doDelay(wait){jQuery(document).ready(function () {$('#toveeModal').modal('show');});}doDelay(15000);</script>");
        }
        public void abrirModalInformacion()
        {
            Response.Write("<script src='Assets/lib/startbootstrap-grayscale/vendor/jquery/jquery.min.js'></script>" +
                           "<script type='text/javascript'>function doDelay(wait){jQuery(document).ready(function () {$('#toveeModalInformacion').modal('show');});}doDelay(15000);</script>");
        }
    }
}