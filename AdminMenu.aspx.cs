using SomosTovee.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SomosTovee
{
    public partial class AdminMenu : System.Web.UI.Page
    {
        Utilidades utlidad = new Utilidades();
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToInt32(Session["rol"]) != 1)
            {
                Response.Redirect("inicio");
            }
            else
            {
                ocultarElementos();
            }

        }

        public void ocultarElementos()
        {
            ((landing)Master).lknAcercaLandVisible = false;
            ((landing)Master).lknNoticiasLandVisible = false;
            ((landing)Master).lknContactoLandVisible = false;
            ((landing)Master).headerMastheadVisible = false;
            ((landing)Master).lknGruposLandVisible = true;
            ((landing)Master).lknLandigVisible = true;
            //((landing)Master).triggerModalVisible = true;
            //((landing)Master).lknRegistrarUsuariosVisible = true;
            ((landing)Master).lknActualizarContactosVisible = true;

        }

        protected void btnAceptarRegistro_Click(object sender, EventArgs e)
        {
            string nombre, segundoNombre, apellido, segundoApellido, correo, contraseña;
            int  result;
            double cedula;

            if (utlidad.validarTextoVacio(txtNombre))
            {
                utlidad.remplazarInvalidoCss(txtNombre);


                if (utlidad.validarTextoVacio(txtApellido))
                {
                    utlidad.remplazarInvalidoCss(txtApellido);
                    abrirModal();
                    if (utlidad.validarTextoVacio(txtSegundoApellido))
                    {
                        utlidad.remplazarInvalidoCss(txtSegundoApellido);
                        abrirModal();
                        if (utlidad.validarTamaño(txtCedula, 10))
                        {

                            utlidad.remplazarInvalidoCss(txtCedula);
                            abrirModal();
                            if (utlidad.validarTextoVacio(txtCorreo))
                            {
                                mensajeInformacionCorreo.Text = "Debe ingresar correo*";
                                utlidad.removerInvalidoCss(txtCorreo);
                                abrirModal();

                                if (utlidad.validarCorreo(txtCorreo))
                                {
                                    mensajeInformacionCorreo.Text = "Solo se permite correos";
                                    utlidad.remplazarInvalidoCss(txtCorreo);
                                    abrirModal();

                                    if (utlidad.validarTextoVacio(txtcontraseña))
                                    {
                                        utlidad.remplazarInvalidoCss(txtcontraseña);
                                        abrirModal();

                                        if (utlidad.validarIguales(txtcontraseña, txtvalidarContraseña))
                                        {
                                            utlidad.remplazarInvalidoCss(txtvalidarContraseña);

                                            nombre = txtNombre.Text;
                                            if (utlidad.validarTextoVacio(txtSegundoNombre))
                                            {
                                                segundoNombre = txtSegundoNombre.Text;
                                            }
                                            else
                                            {
                                                segundoNombre = null;
                                            }
                                            apellido = txtApellido.Text;
                                            segundoApellido = txtSegundoApellido.Text;
                                            cedula = Convert.ToDouble(txtCedula.Text);
                                            correo = txtCorreo.Text;
                                            contraseña = txtcontraseña.Text;
                                            result = usuario.guardarUsuario(nombre, apellido, correo, contraseña, 2, segundoNombre, segundoApellido, cedula);
                                            switch (result)
                                            {
                                                case 1:
                                                    ((landing)Master).contentModalInformacion = "Guardado exitoso";
                                                    ((landing)Master).abrirModalInformacion();
                                                    break;
                                                case 2:
                                                    ((landing)Master).contentModalInformacion = "El usuario ya existe";
                                                    ((landing)Master).abrirModalInformacion();
                                                    break;
                                                case 3:
                                                    ((landing)Master).contentModalInformacion = "Ocurrio un error por fabor contacte con el administrador de la pagina";
                                                    ((landing)Master).abrirModalInformacion();
                                                    break;
                                                case 4:
                                                    ((landing)Master).contentModalInformacion = "Ocurrio un error al guardar nuevo usuario por fabor contacte con el administrador de la pagina";
                                                    ((landing)Master).abrirModalInformacion();
                                                    break;
                                                default:
                                                    ((landing)Master).contentModalInformacion = "Ocurrio un error inesperado por fabor contacte con el administrador de la pagina";
                                                    ((landing)Master).abrirModalInformacion();
                                                    break;
                                            }

                                        }
                                        else
                                        {
                                            utlidad.agregarinvalidoCss(txtvalidarContraseña);
                                            abrirModal();
                                        }
                                    }
                                    else
                                    {
                                        utlidad.agregarinvalidoCss(txtcontraseña);
                                        abrirModal();
                                    }
                                }
                                else
                                {
                                    utlidad.agregarinvalidoCss(txtCorreo);
                                    abrirModal();
                                }
                            }
                            else
                            {
                                utlidad.agregarinvalidoCss(txtCorreo);
                                abrirModal();
                            }


                        }
                        else
                        {
                            utlidad.agregarinvalidoCss(txtCedula);
                            abrirModal();
                        }

                    }
                    else
                    {
                        utlidad.agregarinvalidoCss(txtSegundoApellido);
                        abrirModal();

                    }

                }
                else
                {
                    utlidad.agregarinvalidoCss(txtApellido);
                    abrirModal();
                }

            }
            else
            {
                utlidad.agregarinvalidoCss(txtNombre);
                abrirModal();

            }


        }
        /// <summary>
        /// habre el modal de registro usuarios atraves de jquery y un delay
        /// </summary>
        private void abrirModal()
        {
            Response.Write("<script src='Assets/lib/startbootstrap-grayscale/vendor/jquery/jquery.min.js'></script>" +
                           "<script type='text/javascript'>function doDelay(wait){jQuery(document).ready(function () {$('#toveeModalRegistroAdmin').modal('show');});}doDelay(15000);</script>");
        }

        protected void Button1_Load(object sender, EventArgs e)
        {

        }
    }
}