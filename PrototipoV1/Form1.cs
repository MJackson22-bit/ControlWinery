using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrototipoV1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearProducto_Click(object sender, EventArgs e)
        {
            NuevoProducto nuevoProducto = new NuevoProducto();
            nuevoProducto.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bd_bodegaDataSet1.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter1.Fill(this.bd_bodegaDataSet1.Producto);
            // TODO: esta línea de código carga datos en la tabla 'bd_bodegaDataSet1.Producto' Puede moverla o quitarla según sea necesario.
            this.productoTableAdapter1.Fill(this.bd_bodegaDataSet1.Producto);

        }

        private void dataGridViewProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            string codigo = dataGridViewProductos.Rows[dataGridViewProductos.CurrentRow.Index].Cells[0].Value.ToString();
            NuevoProducto nuevoProducto = new NuevoProducto(int.Parse(codigo));
            nuevoProducto.ShowDialog();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.productoTableAdapter1.Fill(this.bd_bodegaDataSet1.Producto);
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = dataGridViewProductos.Rows[dataGridViewProductos.CurrentRow.Index].Cells[0].Value.ToString();
                int codigoInt = Convert.ToInt32(codigo);
                string query = "DELETE FROM Producto WHERE Codigo = " + codigoInt;
                sqlConnection2.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection2);
                if (sqlCommand.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Producto eliminado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("No han ocurrido cambios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                sqlConnection2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection2.Close();
            }
            
           
        }

        private void sqlConnection2_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {

        }

        private void btnVerProducto_Click(object sender, EventArgs e)
        {
            string codigo = dataGridViewProductos.Rows[dataGridViewProductos.CurrentRow.Index].Cells[0].Value.ToString();
            int codigoInt = Convert.ToInt32(codigo);
            NuevoProducto nuevoProducto = new NuevoProducto(codigoInt, true);
            nuevoProducto.ShowDialog();
        }

        private void btnModificarPrecio_Click(object sender, EventArgs e)
        {
            string codigo = dataGridViewProductos.Rows[dataGridViewProductos.CurrentRow.Index].Cells[0].Value.ToString();
            int codigoInt = Convert.ToInt32(codigo);
            ModificarPrecio modificarPrecio = new ModificarPrecio(codigoInt);
            modificarPrecio.ShowDialog();
        }
    }
}
