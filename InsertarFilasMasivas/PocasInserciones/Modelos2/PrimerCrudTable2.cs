using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace InsertarFilasMasivas.PocasInserciones.Modelos2
{
    public class PrimerCrudTable2
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }

        public void InsertarDatosMasivos(IEnumerable<PrimerCrudTable2> listaDatos)
        {
            using (var connection = ConexionSQL2.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.Transaction = transaction;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "insert into PrimerCrudTable values (@nombre,@correo,@fecha)";
                        command.Parameters.Add("@nombre",SqlDbType.VarChar,50);
                        command.Parameters.Add("@correo", SqlDbType.VarChar, 50);
                        command.Parameters.Add("@fecha", SqlDbType.VarChar, 50);

                        try
                        {
                            foreach (PrimerCrudTable2 item in listaDatos)
                            {
                                command.Parameters["@nombre"].Value = item.Nombre;
                                command.Parameters["@correo"].Value = item.Correo;
                                command.Parameters["@fecha"].Value = item.Fecha;
                                command.ExecuteNonQuery();
                            }
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            connection.Close();
                            throw;
                        }
                    }
        
                }
            }
        }
    }
}
