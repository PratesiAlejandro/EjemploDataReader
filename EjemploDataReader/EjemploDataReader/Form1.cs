using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EjemploDataReader
{
    public partial class Form1 : Form
    {
        SqlConnection conexion;

        public Form1()
        {
            InitializeComponent();

           conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();

            SqlCommand comando = new SqlCommand("Select * from localidades", this.conexion);

            //MessageBox.Show(comando.Connection.ConnectionString);
            this.conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            

            while (lector.Read())
            {
                listBox1.Items.Add("id:  " + lector.GetValue(0).ToString().PadRight(5) + "  Localidad : " + lector.GetString(1));

            }

            this.conexion.Close();

            
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("insert into localidades values ('La Plata')", conexion);

                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();

            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("Update localidades set localidad = 'Ranelagh' where id = 4", conexion);

                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("Delete from localidades where localidad = 'La Plata'", conexion);

                comando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void btnContar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();

                SqlCommand comando = new SqlCommand("select count(id) from localidades", conexion);

                int cantidad = (int) comando.ExecuteScalar();

                MessageBox.Show("Hay " + cantidad + " localidades cargadas");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
