using InsertarFilasMasivas.PocasInserciones.Modelos2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InsertarFilasMasivas.PocasInserciones.Vistas2
{
    public partial class FormInsertar2 : Form
    {
        public FormInsertar2()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<PrimerCrudTable2> primerCrudTablesLista = new List<PrimerCrudTable2>();

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                PrimerCrudTable2 crudTable = new PrimerCrudTable2()
                {
                    //no se debe colocar el nombre de la columna id ya que esta se inserta sola
                    Nombre = Convert.ToString(fila.Cells["nombre"].Value),
                    Correo = Convert.ToString(fila.Cells["correo"].Value),
                    Fecha = Convert.ToString(fila.Cells["fechaNacimiento"].Value)
                };
                primerCrudTablesLista.Add(crudTable);
            }
            //se crea otra instancia para invocar el método que inserta datos masivos
            PrimerCrudTable2 primerCrudTable = new PrimerCrudTable2();
            primerCrudTable.InsertarDatosMasivos(primerCrudTablesLista);

            MessageBox.Show($"Datos insertados correctamente, datos inseretados {primerCrudTablesLista.Count}");
        }

        private void FormInsertar2_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyCode == Keys.Enter)
            {
                dataGridView1.Rows.Add();
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
            }
        }
    }
}
