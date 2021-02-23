using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InsertarFilasMasivas.MuchasInserciones.Modelos;

namespace InsertarFilasMasivas.MuchasInserciones
{
    public partial class FormInsertar : Form
    {
        public FormInsertar()
        {
            InitializeComponent();
        }

        private void FormInsertar_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Agregar una nueva fila al darle enter
            if(e.KeyCode == Keys.Enter)
            {
                dataGridView1.Rows.Add();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<PrimerCrudTable> primerCrudTablesLista = new List<PrimerCrudTable>();

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                PrimerCrudTable crudTable = new PrimerCrudTable()
                {
                    //no se debe colocar el nombre de la columna id ya que esta se inserta sola
                    Nombre = Convert.ToString(fila.Cells["nombre"].Value),
                    Correo = Convert.ToString(fila.Cells["correo"].Value),
                    Fecha = Convert.ToString(fila.Cells["fechaNacimiento"].Value)
                };
                primerCrudTablesLista.Add(crudTable);
            }
            //se crea otra instancia para invocar el método que inserta datos masivos
            PrimerCrudTable primerCrudTable = new PrimerCrudTable();
            primerCrudTable.InsertarDatosMasivos(primerCrudTablesLista);

            MessageBox.Show($"Datos insertados correctamente, datos inseretados {primerCrudTablesLista.Count}");   
        }
    }
}
