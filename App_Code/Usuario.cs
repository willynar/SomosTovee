using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace SomosTovee.App_Code
{

    public class Usuario
    {
        private Dao DAO = new Dao();
        Utilidades utilidad = new Utilidades();
        /// <summary>
        /// guardar usuario 
        /// </summary>
        /// <param name="nombre">string</param>
        /// <param name="apellido">string</param>
        /// <param name="correo">string</param>
        /// <param name="contraseña">string</param>
        /// <param name="rol">int</param>
        /// <param name="segundoNombre">string</param>
        /// <param name="segundoApellido">string</param>
        /// <param name="cedula">double</param>
        /// <returns></returns>
        public int guardarUsuario(string nombre, string apellido, string correo, string contraseña, int rol, string segundoNombre = "", string segundoApellido = null, double? cedula = null)
        {
            DataSet resultadoMetodo;
            int result = 1;
            string token;
            SqlParameter[] sqlParams = {
                new SqlParameter("@correo",correo)
             };
            try
            {
                //se valida si el correo existe
                resultadoMetodo = DAO.ejecutarProcedimientoAlmacenado("sp_consulta_usuario_existente", sqlParams);
                if (resultadoMetodo.Tables[0].Rows.Count == 0)
                {
                    contraseña = utilidad.encriptar(contraseña);
                    token = utilidad.encriptar(nombre) + utilidad.encriptar(correo);

                    SqlParameter[] sqlParamsRegistro = {
                        new SqlParameter("@nombre",nombre),
                        new SqlParameter("@segundo_nombre",segundoNombre),
                        new SqlParameter("@apellido",apellido),
                        new SqlParameter("@segundo_apellido",segundoApellido),
                        new SqlParameter("@correo",correo),
                        new SqlParameter("@cedula",cedula),
                        new SqlParameter("@token",token),
                        new SqlParameter("@rol",rol),
                        new SqlParameter("@contraseña",contraseña)
                    };
                    //se envian los parametros al metodo en el dao que ejecuta los procedimientos almacenados y se crea el usuario
                    resultadoMetodo = DAO.ejecutarProcedimientoAlmacenado("sp_registrar_usuario", sqlParamsRegistro);
                    //var g = resultadoMetodo.Tables[0].Rows.Count;
                    if (resultadoMetodo.Tables[0].Rows.Count != 0)
                    {
                        result = 4;
                    }
                }
                else
                {
                    result = 2;
                }
            }
            catch (Exception e)
            {
                //string mmensajee = e.Message;
                result = 3;

            }

            return result;
        }
        /// <summary>
        /// hacer login
        /// </summary>
        /// <param name="correo">string</param>
        /// <param name="contraseña">string</param>
        /// <returns></returns>
        public int login(string correo, string contraseña)
        {
            DataSet resultadoMetodo;
            int result = 1;
            string token, nombre;
            int id, rol;
            SqlParameter[] sqlParams = {
                new SqlParameter("@correo",correo)
             };
            try
            {
                //se valida si el correo existe
                resultadoMetodo = DAO.ejecutarProcedimientoAlmacenado("sp_consulta_usuario_login", sqlParams);
                if (resultadoMetodo.Tables[0].Columns.Contains("error")) { result = 3; }
                else
                {
                    if (resultadoMetodo.Tables[0].Columns.Contains("Mensaje")) { result = 4; }
                    else
                    {
                        nombre = Convert.ToString(resultadoMetodo.Tables[0].Rows[0]["nombre"]);
                        id = Convert.ToInt32(resultadoMetodo.Tables[0].Rows[0]["id"]);
                        contraseña = utilidad.encriptar(contraseña);
                        token = utilidad.encriptar(nombre) + utilidad.encriptar(correo);

                        SqlParameter[] sqlParamsRegistro = {
                            new SqlParameter("@id",id),
                            new SqlParameter("@token",token),
                            new SqlParameter("@contrasena",contraseña)
                         };
                        rol = Convert.ToInt32(resultadoMetodo.Tables[0].Rows[0]["rol"]);
                        //se envian los parametros al metodo en el dao que ejecuta los procedimientos almacenados y se crea el usuario
                        resultadoMetodo = DAO.ejecutarProcedimientoAlmacenado("sp_consulta_contraseña_login", sqlParamsRegistro);
                        //var g = resultadoMetodo.Tables[0].Rows.Count;
                        if (resultadoMetodo.Tables[0].Rows.Count == 0)
                        {
                            result = 5;
                        }
                        else
                        {
                            HttpContext.Current.Session["id"] = id;
                            HttpContext.Current.Session["rol"] = rol;
                            HttpContext.Current.Session["correo"] = correo;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result = 2;
            }
            return result;
        }
    }
}