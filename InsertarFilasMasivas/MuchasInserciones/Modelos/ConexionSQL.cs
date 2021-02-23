using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace InsertarFilasMasivas.MuchasInserciones.Modelos
{
    class ConexionSQL
    {
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("server=(local); database=PrimerCrud; integrated security = true");
        }
    }
}
