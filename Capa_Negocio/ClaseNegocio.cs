using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;
using Capa_Entidad;
using static Capa_Datos.ClaseDatos;

namespace Capa_Negocio
{
    public class ClaseNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_clientes()
        {
            return objd.D_listar_clientes();
        }

        public DataTable N_buscar_clientes(ClaseEntidad obje)
        {
            return objd.D_buscar_clientes(obje);
        }

        public String N_mantenimiento_cliente(ClaseEntidad obje)
        {
            return objd.D_mantenimiento_clientes(obje);
        }
    }
}
