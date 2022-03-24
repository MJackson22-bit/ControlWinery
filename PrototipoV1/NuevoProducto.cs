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
    public partial class NuevoProducto : Form
    {
        private int codigo;
        private bool isUpdate = false;
        private bool isLook = false;
        private double impuesto1, impuesto2, impuesto3, impuesto4;
        public NuevoProducto()
        {
            InitializeComponent();
            this.isUpdate = false;
        }

        public NuevoProducto(int codigo, bool isLook)
        {
            this.codigo = codigo;
            this.isLook = isLook;
            InitializeComponent();
            this.ver_Producto();
        }

        public NuevoProducto(int codigo)
        {
            this.isUpdate = true;
            this.codigo = codigo;
            InitializeComponent();
            this.mofificar_Producto();
        }
        public void ver_Producto()
        {
            button1.Text = "Atrás";
            cbSubcategoria.Enabled = false;
            cbBodega.Enabled = false;
            SqlDataReader sqlDataReader = null;
            sqlConnection1.Open();
            string query = "SELECT * FROM Producto WHERE Codigo = " + this.codigo;
            SqlCommand cmd = new SqlCommand(query, sqlConnection1);
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    //MessageBox.Show(sqlDataReader["Codigo"].ToString());
                    txtCodigo.Enabled = false;
                    txtCodigo.Text = sqlDataReader["Codigo"].ToString();
                    txtNombre.Text = sqlDataReader["Nombre"].ToString();
                    txtNombre.ReadOnly = true;
                    txtPrecio1.Text = sqlDataReader["Precio"].ToString();
                    txtPrecio1.ReadOnly = true;
                    string tipo = sqlDataReader["Tipo"].ToString();
                    if (tipo == "Físico")
                    {
                        rbFisico.Checked = true;
                    }
                    else if (tipo == "Ocasional")
                    {
                        rbOcasional.Checked = true;
                    }
                    else
                    {
                        rbServicio.Checked = true;
                    }
                    groupBox7.Enabled = false;
                    string medida = sqlDataReader["Medida"].ToString();
                    if (medida == "Litros")
                    {
                        cbCompra.SelectedIndex = 1;
                    }
                    else
                    {
                        cbCompra.SelectedIndex = 0;
                    }
                    cbCompra.Enabled = false;
                    string categoria = sqlDataReader["Categoria"].ToString();
                    if (categoria == "Producto 1")
                    {
                        cbCtegoriaProducto.SelectedIndex = 0;
                    }
                    else if (categoria == "Producto 2")
                    {
                        cbCtegoriaProducto.SelectedIndex = 1;
                    }
                    else
                    {
                        cbCtegoriaProducto.SelectedIndex = 2;
                    }
                    cbCtegoriaProducto.Enabled = false;
                    string estado = sqlDataReader["Estado"].ToString();
                    if (estado == "Activo")
                    {
                        cbIsActivo.Checked = true;
                    }
                    else
                    {
                        cbIsActivo.Checked = false;
                    }
                    groupBox6.Enabled = false;
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Precio WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtPrecio1.Text = sqlDataReader["precio1"].ToString();
                        txtPrecio2.Text = sqlDataReader["precio2"].ToString();
                        txtPrecio3.Text = sqlDataReader["precio3"].ToString();
                        txtPrecio4.Text = sqlDataReader["precio4"].ToString();
                        txtPrecio1.ReadOnly = true;
                        txtPrecio2.ReadOnly = true;
                        txtPrecio3.ReadOnly = true;
                        txtPrecio4.ReadOnly = true;
                        txtPrecioUnidad.Text = sqlDataReader["precio_unidad"].ToString();
                        txtPrecioUnidad.ReadOnly = true;
                        txtUS.Text = sqlDataReader["precioUS"].ToString();
                        txtUS.ReadOnly = true;
                        string venta = sqlDataReader["venta_contiene"].ToString();
                        if (venta == "Libras")
                        {
                            cbVenta.SelectedIndex = 0;
                        }
                        else
                        {
                            cbVenta.SelectedIndex = 1;
                        }
                        cbVenta.Enabled = false;
                    }
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Impuesto WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtPrecioImpuesto1.Text = sqlDataReader["impuesto1"].ToString();
                        txtPrecioImpuesto2.Text = sqlDataReader["impuesto2"].ToString();
                        txtPrecioImpuesto3.Text = sqlDataReader["impuesto3"].ToString();
                        txtPrecioImpuesto4.Text = sqlDataReader["impuesto4"].ToString();
                        txtPrecioImpuesto1.ReadOnly = true;
                        txtPrecioImpuesto2.ReadOnly = true;
                        txtPrecioImpuesto3.ReadOnly = true;
                        txtPrecioImpuesto4.ReadOnly = true;
                    }
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Unidad WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtUnidad1.Text = sqlDataReader["unidad1"].ToString();
                        txtUnidad2.Text = sqlDataReader["unidad2"].ToString();
                        txtUnidad3.Text = sqlDataReader["unidad3"].ToString();
                        txtUnidad4.Text = sqlDataReader["unidad4"].ToString();
                        txtUnidad1.ReadOnly = true;
                        txtUnidad2.ReadOnly = true;
                        txtUnidad3.ReadOnly = true;
                        txtUnidad4.ReadOnly = true;
                    }
                }
                sqlDataReader.Close();
                sqlConnection1.Close();
            }
        }
        public void mofificar_Producto()
        {
            button1.Text = "Actualizar";
            SqlDataReader sqlDataReader = null;
            sqlConnection1.Open();
            string query = "SELECT * FROM Producto WHERE Codigo = " + this.codigo;
            SqlCommand cmd = new SqlCommand(query, sqlConnection1);
            sqlDataReader = cmd.ExecuteReader();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    //MessageBox.Show(sqlDataReader["Codigo"].ToString());
                    txtCodigo.Enabled = false;
                    txtCodigo.Text = sqlDataReader["Codigo"].ToString();
                    txtNombre.Text = sqlDataReader["Nombre"].ToString();
                    txtPrecio1.Text = sqlDataReader["Precio"].ToString();
                    string tipo = sqlDataReader["Tipo"].ToString();
                    if (tipo == "Físico")
                    {
                        rbFisico.Checked = true;
                    }
                    else if (tipo == "Ocasional")
                    {
                        rbOcasional.Checked = true;
                    }
                    else
                    {
                        rbServicio.Checked = true;
                    }
                    string medida = sqlDataReader["Medida"].ToString();
                    if (medida == "Litros")
                    {
                        cbCompra.SelectedIndex = 1;
                    }else
                    {
                        cbCompra.SelectedIndex = 0;
                    }
                    string categoria = sqlDataReader["Categoria"].ToString();
                    if (categoria == "Producto 1")
                    {
                        cbCtegoriaProducto.SelectedIndex = 0;
                    }else if (categoria == "Producto 2")
                    {
                        cbCtegoriaProducto.SelectedIndex = 1;
                    }
                    else
                    {
                        cbCtegoriaProducto.SelectedIndex = 2;
                    }
                    string estado = sqlDataReader["Estado"].ToString();
                    if (estado == "Activo")
                    {
                        cbIsActivo.Checked = true;
                    }
                    else
                    {
                        cbIsActivo.Checked= false;
                    }
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Precio WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtPrecio1.Text = sqlDataReader["precio1"].ToString();
                        txtPrecio2.Text = sqlDataReader["precio2"].ToString();
                        txtPrecio3.Text = sqlDataReader["precio3"].ToString();
                        txtPrecio4.Text = sqlDataReader["precio4"].ToString();
                        txtPrecioUnidad.Text = sqlDataReader["precio_unidad"].ToString();
                        txtUS.Text = sqlDataReader["precioUS"].ToString();
                        string venta = sqlDataReader["venta_contiene"].ToString();
                        if (venta == "Libras")
                        {
                            cbVenta.SelectedIndex = 0;
                        }
                        else
                        {
                            cbVenta.SelectedIndex = 1;
                        }
                    }
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Impuesto WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtPrecioImpuesto1.Text = sqlDataReader["impuesto1"].ToString();
                        txtPrecioImpuesto2.Text = sqlDataReader["impuesto2"].ToString();
                        txtPrecioImpuesto3.Text = sqlDataReader["impuesto3"].ToString();
                        txtPrecioImpuesto4.Text = sqlDataReader["impuesto4"].ToString();
                    }
                }
                sqlDataReader.Close();
                query = "SELECT * FROM Unidad WHERE Codigo = " + int.Parse(txtCodigo.Text);
                cmd = new SqlCommand(query, sqlConnection1);
                sqlDataReader = cmd.ExecuteReader();
                if (sqlDataReader != null)
                {
                    while (sqlDataReader.Read())
                    {
                        txtUnidad1.Text = sqlDataReader["unidad1"].ToString();
                        txtUnidad2.Text = sqlDataReader["unidad2"].ToString(); 
                        txtUnidad3.Text = sqlDataReader["unidad3"].ToString(); 
                        txtUnidad4.Text = sqlDataReader["unidad4"].ToString(); 
                    }
                }
                sqlDataReader.Close();
                sqlConnection1.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox10_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.isUpdate == false)
            {
                if (table_Producto() == true && table_Precio() == true && table_Impuesto() == true && table_Unidad() == true)
                {
                    MessageBox.Show("Datos ingresados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error al ingresar datos en una de las tablas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                table_Actualizar();
                MessageBox.Show("Producto actualizado", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void table_Actualizar()
        {
            try
            {
                sqlConnection1.Open();
                string query = "UPDATE Producto SET Descripcion = @Nombre, Nombre = @Nombre, Tipo = @Tipo, @Unidades = @Unidades, Precio = @Precio, Medida = @Medida, Categoria = @Categoria, Estado = @Estado WHERE Codigo = " + this.codigo;
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@Descripcion", txtNombre.Text);
                sqlCommand.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                string tipo = "";
                if (rbFisico.Checked == true)
                {
                    tipo = "Físico";
                }
                else if (rbOcasional.Checked == true)
                {
                    tipo = "Ocasional";
                }
                else
                {
                    tipo = "Servicio";
                }
                sqlCommand.Parameters.AddWithValue("@Tipo", tipo);
                sqlCommand.Parameters.AddWithValue("@Unidades", int.Parse(txtUnidad1.Text));
                sqlCommand.Parameters.AddWithValue("@Precio", Double.Parse(txtPrecio1.Text));
                sqlCommand.Parameters.AddWithValue("@Medida", cbCompra.SelectedItem.ToString());
                sqlCommand.Parameters.AddWithValue("@Categoria", cbCtegoriaProducto.SelectedItem.ToString());
                string estado = "";
                if (cbIsActivo.Checked)
                {
                    estado = "Activo";
                }
                else
                {
                    estado = "Inactivo";
                }
                sqlCommand.Parameters.AddWithValue("@Estado", estado);
                sqlCommand.ExecuteNonQuery();

                //Precio
                query = "UPDATE Precio SET precio1 = @precio1, precio2 = @precio2, precio3 = @precio3, precio4 = @precio4, precio_unidad = @precio_unidad, precioUS = @precioUS, venta_contiene = @venta_contiene, compra_contiene = @compra_contiene WHERE Codigo = " + this.codigo;
                sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@precio1", Double.Parse(txtPrecio1.Text));
                sqlCommand.Parameters.AddWithValue("@precio2", Double.Parse(txtPrecio2.Text));
                sqlCommand.Parameters.AddWithValue("@precio3", Double.Parse(txtPrecio3.Text));
                sqlCommand.Parameters.AddWithValue("@precio4", Double.Parse(txtPrecio4.Text));
                sqlCommand.Parameters.AddWithValue("@precio_unidad", Double.Parse(txtPrecioUnidad.Text));
                sqlCommand.Parameters.AddWithValue("@precioUS", Double.Parse(txtUS.Text));
                sqlCommand.Parameters.AddWithValue("@venta_contiene", cbVenta.SelectedItem.ToString());
                sqlCommand.Parameters.AddWithValue("@compra_contiene", cbCompra.SelectedItem.ToString());
                sqlCommand.ExecuteNonQuery();

                //Impuesto
                query = "UPDATE Impuesto SET impuesto1 = @impuesto1, impuesto2 = @impuesto2, impuesto3 = @imouesto3, impuesto4 = @impuesto4 WHERE Codigo = " + this.codigo;
                impuesto1 = Double.Parse(txtPrecioImpuesto1.Text) + Double.Parse(txtPrecio1.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto1", impuesto1);
                impuesto2 = Double.Parse(txtPrecioImpuesto2.Text) + Double.Parse(txtPrecio2.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto2", impuesto2);
                impuesto3 = Double.Parse(txtPrecioImpuesto3.Text) + Double.Parse(txtPrecio3.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto3", impuesto3);
                impuesto4 = Double.Parse(txtPrecioImpuesto4.Text) + Double.Parse(txtPrecio4.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto4", impuesto4);
                sqlCommand.ExecuteNonQuery();

                //Unidad
                query = "UPDATE Unidad SET unidad1 = @unidad1, unidad2 = @unidad2, unidad3 = @unidad3, unidad4 = @unidad4 WHERE Codigo = " + this.codigo;
                sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@unidad1", int.Parse(txtUnidad1.Text));
                sqlCommand.Parameters.AddWithValue("@unidad2", int.Parse(txtUnidad2.Text));
                sqlCommand.Parameters.AddWithValue("@unidad3", int.Parse(txtUnidad3.Text));
                sqlCommand.Parameters.AddWithValue("@unidad4", int.Parse(txtUnidad4.Text));
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection1.Close();
            }
            
        }

        private void txtPrecio1_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio1.Text == "")
            {
                txtPrecio1.Text = "0.00";
            }
        }

        private void txtPrecio2_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio2.Text == "")
            {
                txtPrecio2.Text = "0.00";
            }
        }

        private void txtPrecio4_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio4.Text == "")
            {
                txtPrecio4.Text = "0.00";
            }
        }

        private void txtPrecio3_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecio3.Text == "")
            {
                txtPrecio3.Text = "0.00";
            }
        }
        public bool table_Precio()
        {
            try
            {
                string query = "INSERT INTO Precio (Codigo, precio1, precio2, precio3, precio4, precio_unidad, precioUS, venta_contiene, compra_contiene) values (@Codigo, @precio1, @precio2, @precio3, @precio4, @precio_unidad, @precioUS, @venta_contiene, @compra_contiene)";
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));
                sqlCommand.Parameters.AddWithValue("@precio1", Double.Parse(txtPrecio1.Text));
                sqlCommand.Parameters.AddWithValue("@precio2", Double.Parse(txtPrecio2.Text));
                sqlCommand.Parameters.AddWithValue("@precio3", Double.Parse(txtPrecio3.Text));
                sqlCommand.Parameters.AddWithValue("@precio4", Double.Parse(txtPrecio4.Text));
                sqlCommand.Parameters.AddWithValue("@precio_unidad", Double.Parse(txtPrecioUnidad.Text));
                sqlCommand.Parameters.AddWithValue("@precioUS", Double.Parse(txtUS.Text));
                sqlCommand.Parameters.AddWithValue("@venta_contiene", cbVenta.SelectedItem.ToString());
                sqlCommand.Parameters.AddWithValue("@compra_contiene", cbCompra.SelectedItem.ToString());
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Precio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection1.Close();
                return false;
            }
        }
        private bool table_Unidad()
        {
            try
            {
                string query = "INSERT INTO Unidad (Codigo, unidad1, unidad2, unidad3, unidad4) values (@Codigo, @unidad1, @unidad2, @unidad3, @unidad4)";
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));
                sqlCommand.Parameters.AddWithValue("@unidad1", int.Parse(txtUnidad1.Text));
                sqlCommand.Parameters.AddWithValue("@unidad2", int.Parse(txtUnidad2.Text));
                sqlCommand.Parameters.AddWithValue("@unidad3", int.Parse(txtUnidad3.Text));
                sqlCommand.Parameters.AddWithValue("@unidad4", int.Parse(txtUnidad4.Text));
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Unidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
           
        }
        public bool table_Impuesto()
        {
            try
            {
                string query = "INSERT INTO Impuesto (Codigo, impuesto1, impuesto2, impuesto3, impuesto4) values (@Codigo, @impuesto1, @impuesto2, @impuesto3, @impuesto4)";
                sqlConnection1.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                sqlCommand.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));
                impuesto1 = Double.Parse(txtPrecioImpuesto1.Text) + Double.Parse(txtPrecio1.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto1", impuesto1);
                impuesto2 = Double.Parse(txtPrecioImpuesto2.Text) + Double.Parse(txtPrecio2.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto2", impuesto2);
                impuesto3 = Double.Parse(txtPrecioImpuesto3.Text) + Double.Parse(txtPrecio3.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto3", impuesto3);
                impuesto4 = Double.Parse(txtPrecioImpuesto4.Text) + Double.Parse(txtPrecio4.Text);
                sqlCommand.Parameters.AddWithValue("@impuesto4", impuesto4);
                sqlCommand.ExecuteNonQuery();
                sqlConnection1.Close();
                return true;
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error en Impuestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                sqlConnection1.Close();
                return false;
            }

        }

        public bool table_Producto()
        {
            if (validar())
            {
                try
                {
                    string query = "INSERT INTO Producto (Codigo, Descripcion, Nombre, Tipo, Unidades, Precio, Medida, Categoria, Estado, ultVenta) values (@Codigo, @Descripcion, @Nombre, @Tipo, @Unidades, @Precio, @Medida, @Categoria, @Estado, @ultVenta)";
                    sqlConnection1.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, sqlConnection1);
                    sqlCommand.Parameters.AddWithValue("@Codigo", int.Parse(txtCodigo.Text));
                    sqlCommand.Parameters.AddWithValue("@Descripcion", txtNombre.Text);
                    sqlCommand.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                    string tipo = "";
                    if (rbFisico.Checked == true)
                    {
                        tipo = "Físico";
                    }
                    else if (rbOcasional.Checked == true)
                    {
                        tipo = "Ocasional";
                    }
                    else
                    {
                        tipo = "Servicio";
                    }
                    sqlCommand.Parameters.AddWithValue("@Tipo", tipo);
                    sqlCommand.Parameters.AddWithValue("@Unidades", int.Parse(txtUnidad1.Text));
                    sqlCommand.Parameters.AddWithValue("@Precio", Double.Parse(txtPrecio1.Text));
                    sqlCommand.Parameters.AddWithValue("@Medida", cbCompra.SelectedItem.ToString());
                    sqlCommand.Parameters.AddWithValue("@Categoria", cbCtegoriaProducto.SelectedItem.ToString());
                    string estado = "";
                    if (cbIsActivo.Checked)
                    {
                        estado = "Activo";
                    }
                    else
                    {
                        estado = "Inactivo";
                    }
                    sqlCommand.Parameters.AddWithValue("@Estado", estado);
                    sqlCommand.Parameters.AddWithValue("@ultVenta", "");
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection1.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlConnection1.Close();
                    return false;  
                }
            }
            else
            {
                MessageBox.Show("Por favor llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private bool validar()
        {
            if (txtCodigo.Text != "" || txtNombre.Text != "" || txtPrecio1.Text != "")
            {
                return true;
            }
            return false;
        }

        private void cbVenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cbVenta.SelectedItem.ToString());
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                groupBox11.Enabled = true;
            }
            else if (checkBox2.Checked == false)
            {
                groupBox11.Enabled = false;
            }
        }

        private void txtPrecioUnidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPrecioUnidad.Text == "")
                {
                    txtPrecioUnidad.Text = "0";
                }
                else
                {
                    double precio = Double.Parse(txtPrecioUnidad.Text);
                    double precioUS = precio * 35.21;
                    txtUS.Text = precioUS.ToString();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void txtPrecioImpuesto1_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioImpuesto1.Text == "")
            {
                txtPrecioImpuesto1.Text = "0.00";
            }
        }

        private void txtPrecioImpuesto2_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioImpuesto2.Text == "")
            {
                txtPrecioImpuesto2.Text = "0.00";
            }
        }

        private void txtPrecioImpuesto3_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioImpuesto3.Text == "")
            {
                txtPrecioImpuesto3.Text = "0.00";
            }
        }

        private void txtPrecioImpuesto4_TextChanged(object sender, EventArgs e)
        {
            if (txtPrecioImpuesto4.Text == "")
            {
                txtPrecioImpuesto4.Text = "0.00";
            }
        }
    }
}
