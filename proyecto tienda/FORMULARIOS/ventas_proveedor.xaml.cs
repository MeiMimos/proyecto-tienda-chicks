using proyecto_tienda.CLASES;
using proyecto_tienda.FORMULARIOS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace proyecto_tienda
{
    /// <summary>
    /// Lógica de interacción para Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
            consecutivo();
        }

        private void txtidproveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarproveedor bp = new buscarproveedor();
                bp.ShowDialog();
                if (bp.DialogResult == true)
                {
                    txtidproveedor.Text = bp.iProveedor.ToString();
                    buscarProveedor(Convert.ToInt32(txtidproveedor.Text));
                }
            }
        }

        private void buscarProducto(int _pro_id)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PRODUCTO where PRO_ID =" + _pro_id;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtproducto.Text = dr.GetString(5);
                txtcosto.Text = dr.GetDouble(1).ToString();
            }
            con.Close();
            dr.Close();
        }
        private void consecutivo()
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT isnull(max(COM_ID),0) + 1 AS CONSECUTIVO  FROM COMPRA";
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtidcompra.Text = Convert.ToString(dr.GetInt32(0));
            }
            con.Close();
            dr.Close();
        }
        private void buscarProveedor(int _id_proveedor)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM PROVEEDOR where PRV_ID = " + _id_proveedor;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtIDPro.Text = dr.GetInt32(0).ToString();
                txtidnom.Text = dr.GetString(1);
            }
            con.Close();
            dr.Close();
        }


        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtIDPro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarProducto bc = new buscarProducto();
                bc.ShowDialog();
                if (bc.DialogResult == true)
                {
                    txtIDPro.Text = bc.iProducto.ToString();
                    buscarProducto(Convert.ToInt32(txtIDPro.Text));
                }
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TMP_COMPRA";
            cmd.Parameters.AddWithValue("op", 1);
            cmd.Parameters.AddWithValue("@TMP_COM_ID", Convert.ToInt32(txtidcompra.Text));
            cmd.Parameters.AddWithValue("@TMP_COM_PRV_ID", Convert.ToInt32(txtIDPro.Text));
            cmd.Parameters.AddWithValue("@TMP_COD_CANTIDAD", Convert.ToDouble(txtcantidad.Text));
            cmd.Parameters.AddWithValue("@TMP_COD_PRECIO", Convert.ToDouble(txtcosto.Text));

            cmd.Parameters.AddWithValue("@TMP_COD_PRO_ID", Convert.ToInt32(txtidcompra.Text));

            con.Open();
            cmd.ExecuteNonQuery();

            con.Close();
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }
    }
}
