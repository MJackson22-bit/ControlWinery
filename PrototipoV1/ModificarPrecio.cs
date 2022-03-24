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
    public partial class ModificarPrecio : Form
    {
        private int codigo;
        public ModificarPrecio()
        {
            InitializeComponent();
        }
        public ModificarPrecio(int codigo)
        {
            this.codigo = codigo;
            InitializeComponent();
            set_Precio();
        }
        public void set_Precio()
        {
            try
            {
                sqlConnection1.Open();
                string query = "SELECT * FROM Precio WHERE Codigo = " + this.codigo;
                SqlDataReader sqlDataReader = null;
                SqlCommand cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtPrecio1.Text = sqlDataReader["precio1"].ToString();
                        txtPrecio2.Text = sqlDataReader["precio2"].ToString();
                        txtPrecio3.Text = sqlDataReader["precio3"].ToString();
                        txtPrecio4.Text = sqlDataReader["precio4"].ToString();
                    }
                }
                query = "SELECT Nombre FROM Producto WHERE Codigo = " + this.codigo;
                sqlDataReader.Close();
                cmd = new SqlCommand(query,sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        lblNombre.Text = sqlDataReader["Nombre"].ToString();
                    }
                }
                sqlDataReader.Close();
                sqlConnection1.Close();
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection1.Close();
            }
        }
        public void modificar_Precio()
        {
            try
            {
                sqlConnection1.Open();
                string query = "UPDATE Precio SET precio1 = @precio1, precio2 = @precio2, precio3 = @precio3, precio4 = @precio4 WHERE Codigo = " + this.codigo;
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@precio1", Double.Parse(txtPrecio1.Text));
                sqlCommand.Parameters.AddWithValue("@precio2", Double.Parse(txtPrecio2.Text));
                sqlCommand.Parameters.AddWithValue("@precio3", Double.Parse(txtPrecio3.Text));
                sqlCommand.Parameters.AddWithValue("@precio4", Double.Parse(txtPrecio4.Text));
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection1.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            modificar_Precio();
            MessageBox.Show("Precios Actualizados", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

