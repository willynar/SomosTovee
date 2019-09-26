using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace SomosTovee.App_Code
{
    public class Utilidades
    {

        /// <summary>
        /// remover clase is-valid de un solo textbox y replazar por is-invalid
        /// </summary>
        /// <param name="id">TextBox</param>
        public void remplazarValid(TextBox id)
        {
            id.CssClass = id.CssClass.Replace("is-valid", "");
            id.CssClass += (" is-invalid");
        }
        /// <summary>
        /// agregar clase is-invalid a un textbox
        /// </summary>
        /// <param name="id">TextBox</param>
        public void agregarinvalidoCss(TextBox id)
        {
            id.CssClass += (" is-invalid");
        }
        /// <summary>
        /// remover clase is-invalid de un solo textbox y remplazarla por is-invalid
        /// </summary>
        /// <param name="id">TextBox</param>
        public void remplazarInvalidoCss(TextBox id)
        {
            id.CssClass = id.CssClass.Replace("is-invalid", "");
            id.CssClass += (" is-valid");
        }
        /// <summary>
        /// remover clase is-invalid de un solo textbox
        /// </summary>
        /// <param name="id">TextBox</param>
        public void removerInvalidoCss(TextBox id)
        {
            id.CssClass = id.CssClass.Replace("is-invalid", "");
        }
        /// <summary>
        /// validar que el contenido de el textbox sea alfanumerico string
        /// </summary>
        /// <param name="id">TextBox</param>
        /// <returns>bool</returns>
        public bool validarTextoVacio(TextBox id)
        {
            if (id.Text.Trim() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// valida que la variable tenga el tamaño correto
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="tamaño">int</param>
        /// <returns>bool</returns>
        public bool validarTamaño(TextBox id, int tamaño)
        {
            if (Convert.ToInt32(id.Text.Trim().Length) == tamaño)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// valida si el contenido de los TextBox son iguales
        /// </summary>
        /// <param name="id1">TextBox</param>
        /// <param name="id2">TextBox</param>
        /// <returns>bool</returns>
        public bool validarIguales(TextBox id1, TextBox id2)
        {
            if (id1.Text.Trim() == id2.Text.Trim())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// remover clase css is-valid de uno o mas textbox
        /// </summary>
        /// <param name="ids">TextBox[]</param>
        public void quitarValidoCss(TextBox[] ids)
        {
            foreach (TextBox id in ids)
            {
                id.CssClass = id.CssClass.Replace("is-valid", "");
            }


        }
        /// <summary>
        /// validar email con exprexion regular
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>bool</returns>
        public bool validarCorreo(TextBox id)
        {
            string email = id.Text;
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// encripta variable alfanumerica
        /// </summary>
        /// <param name="variable">string</param>
        /// <returns>string encriptada</returns>
        public string encriptar(string variable)
        {
            SHA512 sha512 = SHA512Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(variable));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            variable = sb.ToString();
            return variable;
        }
    }
}