using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomosTovee.Models
{
    public class spModel
    {
        //=============================ejecutar sp con parametros==================================
        public DataSet EjecutarProcedimientoAlmacenado(string ProcedimientoAlmacenado, params SqlParameter[] Parameters)
        {
            var dataset = new DataSet();

            try
            {

                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionBD"].ToString()))
                {
                    using (var cmd = new SqlCommand(ProcedimientoAlmacenado, conexion))
                    {
                        using (var sda = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            if (Parameters != null)
                                foreach (SqlParameter item in Parameters)
                                    cmd.Parameters.Add(item);
                            conexion.Open();

                            sda.Fill(dataset);
                            cmd.Parameters.Clear();

                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                DataTable datatable = new DataTable();
                dataset.Tables.Add(datatable);
                datatable.Columns.Add("Error", typeof(string));
                datatable.Rows.Add(mensaje);
            }
            return dataset;
        }
    }
}