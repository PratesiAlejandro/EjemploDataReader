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

namespace EjemploDT
{
    public partial class Form1 : Form
    {
        //Creo la conexion
        SqlConnection conexion;

        public Form1()
        {
            InitializeComponent();

            //Instaciamos la conexion y le pasamos el conecction string
            conexion = new SqlConnection(Properties.Settings.Default.ConUTN_Negocios);


        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.listaPro.Items.Clear();
            SqlCommand comando = new SqlCommand("Select * from Proveedores", this.conexion);
            this.conexion.Open();

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                listaPro.Items.Add("ID: "+ lector.GetValue(0).ToString() + "Nombre: "+ lector.GetString(1) + "Tipo:" + lector.GetString(2));
            }

            this.conexion.Close();
        }

        
    }
}
