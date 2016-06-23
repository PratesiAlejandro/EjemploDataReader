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
    public partial class FormDataAdapter : Form
    {
        private DataSet _dataSet;
        private SqlDataAdapter _dataAdapter;
        private SqlCommand _Select;
        private SqlCommand _Insert;
        private SqlCommand _Update;
        private SqlCommand _Delete;
        private SqlConnection _Connection;


        public FormDataAdapter()
        {
            InitializeComponent();
            _Connection = new SqlConnection(Properties.Settings.Default.ConUTN_Negocios);

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.listaProductos.Items.Clear();
            this._Select = new SqlCommand("SELECT * FROM Proveedores", this._Connection);

        }
    }
}
