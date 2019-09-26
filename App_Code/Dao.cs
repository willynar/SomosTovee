using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SomosTovee.App_Code
{
    public class Dao
    {
        public DataSet ejecutarProcedimientoAlmacenado(string nombreProcedimiento, params SqlParameter[] Parameters)
        {
            var dataset = new DataSet();
            DataTable datatable = new DataTable();
            try
            {
                using (var conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexionTovee"].ToString()))
                {
                    using (var cmd = new SqlCommand(nombreProcedimiento, conexion))
                    {
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            if (Parameters != null)
                                foreach (SqlParameter item in Parameters)
                                    cmd.Parameters.Add(item);
                            conexion.Open();
                            adapter.Fill(dataset);
                            cmd.Parameters.Clear();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                datatable.Columns.Add("error");
                datatable.Rows.Add(mensaje);
                dataset.Tables.Add(datatable);
            }
            return dataset;
        }
    }
}