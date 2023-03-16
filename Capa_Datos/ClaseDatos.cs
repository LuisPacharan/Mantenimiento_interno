using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;

namespace Capa_Datos
{
    public class ClaseDatos
    {

        public class ClassDatos
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);

            public DataTable D_listar_clientes()
            {
                SqlCommand cmd = new SqlCommand("SP_SM_LISTAR_CLIENTES", cn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            public DataTable D_buscar_clientes(ClaseEntidad obje)
            {
                SqlCommand cmd = new SqlCommand("SP_SM_BUSCAR_CLIENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", obje.nombre);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }

            public String D_mantenimiento_clientes(ClaseEntidad obje)
            {
                String accion = "";
                SqlCommand cmd = new SqlCommand("SP_SM_MANTENIMIENTO_CLIENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", obje.codigo);
                cmd.Parameters.AddWithValue("@nombre", obje.nombre);
                cmd.Parameters.AddWithValue("@edad", obje.edad);
                cmd.Parameters.AddWithValue("@telefono", obje.telefono);
                cmd.Parameters.Add("@accion", SqlDbType.VarChar, 50).Value = obje.accion;
                cmd.Parameters["@accion"].Direction = ParameterDirection.InputOutput;
                if (cn.State == ConnectionState.Open) cn.Close();
                cn.Open();
                cmd.ExecuteNonQuery();
                accion = cmd.Parameters["@accion"].Value.ToString();
                cn.Close();
                return accion;

            }

        }
    }
}
