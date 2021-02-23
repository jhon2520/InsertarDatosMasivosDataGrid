using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Esta clase sirve para insertar datos masivos que alcancen un volumen masivo de cientos o miles de datos;
/// </summary>


namespace InsertarFilasMasivas.MuchasInserciones.Modelos
{
    //se debe crear una clase por cada tabla a la que se le va a insertar datos
    public class PrimerCrudTable
    {
        //se crean los parámetros de la tabla sql, se podría crear una clase sóla para estas propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Fecha { get; set; }

        public void InsertarDatosMasivos(IEnumerable<PrimerCrudTable> listaDatos)
        {
            //se crea una tabla igual a la tabla de sql
            DataTable table = new DataTable();
            table.Columns.Add("idUsuario", typeof(int));
            table.Columns.Add("nombre", typeof(string));
            table.Columns.Add("corrre", typeof(string));
            table.Columns.Add("fechaNacimiento", typeof(string));

            //Agregar datos a la tabla según la cantidad de elementos que hay en la lista que se pasa por parámetro a este método

            foreach (PrimerCrudTable dato in listaDatos)
            {
                table.Rows.Add(new object[]
                {
                    dato.ID,
                    dato.Nombre,
                    dato.Correo,
                    dato.Fecha
                });
            }
            //insertar tabla a la base de datos
            using (var connection = ConexionSQL.GetConnection())
            {
                connection.Open();

                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default,transaction))
                    {
                        try
                        {
                            bulkCopy.DestinationTableName = "PrimerCrudTable";
                            bulkCopy.WriteToServer(table);
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
