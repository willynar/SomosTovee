using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomosTovee.App_Code
{
    public class DatosPagina
    {
        private Dao DAO = new Dao();
        public DataTable consultarContactos()
        {
            DataSet data = new DataSet();
            DataTable tabla = new DataTable();
            data = DAO.ejecutarProcedimientoAlmacenado("sp_consultar_contacos_pagina");
            if (data.Tables.Count == 0)
            {
                tabla.Columns.Add("Error");
                tabla.Rows.Add("Consulta sin datos");
            }
            else
            {
                if (data.Tables[0].Columns.Contains("Error"))
                {
                    data.Tables[0].Columns.Add("Mensaje");
                    data.Tables[0].Rows.Add("Ocurrio error por fabor contacte al administrador de la pagina");
                }
                tabla = data.Tables[0];

            }


            return tabla;
        }
        public int guardarSuscriptor(string nombre, double celular,string email)
        {
            int result = 0;

            DataSet data = new DataSet();
            SqlParameter[] parametros = {
                new SqlParameter("@nombre",nombre),
                new SqlParameter("@celular",celular),
                new SqlParameter("@correo",email)
            };
            data = DAO.ejecutarProcedimientoAlmacenado("sp_guardar_suscriptor", parametros);
            if (data.Tables.Count == 0)
            {
                result = 1;
            }

            return result;
        }
    }
}