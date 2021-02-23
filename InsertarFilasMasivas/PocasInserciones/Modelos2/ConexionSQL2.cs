using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertarFilasMasivas.PocasInserciones.Modelos2
{
    public class ConexionSQL2
    {
      
        public static SqlConnection GetConnection()
        {
            return new SqlConnection("server=.;database = PrimerCrud; integrated security = true");
        }
    }
}
