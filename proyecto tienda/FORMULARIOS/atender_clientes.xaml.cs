using proyecto_tienda.CLASES;
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
using System.Collections.ObjectModel;
using System.Collections;

namespace proyecto_tienda.FORMULARIOS
{
    /// <summary>
    /// Lógica de interacción para atender_clientes.xaml
    /// </summary>
    public partial class atender_clientes : Window
    {
        public atender_clientes()
        {
            InitializeComponent();
            consecutivo();
        }


        private void txtidcliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarcliente bc = new buscarcliente();
                bc.ShowDialog();
                if(bc.DialogResult == true)
                 {
                    txtidcliente.Text = bc.iCliente.ToString();
                    buscarCliente(Convert.ToInt32(txtidcliente.Text));
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
                txtprecios.Text = dr.GetDouble(1).ToString();
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
            cmd.CommandText = "SELECT isnull(max(VEN_ID),0) + 1 AS CONSECUTIVO  FROM VENTA";
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtidventa.Text = Convert.ToString(dr.GetInt32(0));
            }
            con.Close();
            dr.Close();
        }
        private void buscarCliente(int _id_cliente)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataReader dr;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM cliente where CLI_ID = " + _id_cliente;
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtclienteNom.Text = dr.GetString(1);

            }
            con.Close();
            dr.Close();
        }
        private void txtidproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarProducto bc = new buscarProducto();
                bc.ShowDialog();
                if (bc.DialogResult == true)
                {
                    txtidproducto.Text = bc.iProducto.ToString();
                    buscarProducto(Convert.ToInt32(txtidproducto.Text));
                }
            }
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());

            // Crear un nuevo comando para la inserción
            SqlCommand cmdInsert = new SqlCommand("", con);
            cmdInsert.CommandType = CommandType.StoredProcedure;
            cmdInsert.CommandText = "SP_TMP_VENTA";
            cmdInsert.Parameters.AddWithValue("op", 1);
            cmdInsert.Parameters.AddWithValue("@TMP_VEN_ID", Convert.ToInt32(txtidventa.Text));
            cmdInsert.Parameters.AddWithValue("@TMP_VEN_CLI_ID", Convert.ToInt32(txtidcliente.Text));
            cmdInsert.Parameters.AddWithValue("@TMP_VEDCANTIDAD", Convert.ToDouble(txtcantidad.Text));
            cmdInsert.Parameters.AddWithValue("@TMP_VEDPRECIO", Convert.ToDouble(txtprecios.Text));
            cmdInsert.Parameters.AddWithValue("@TMP_VED_PRO_ID", Convert.ToInt32(txtidproducto.Text));

            con.Open();
            cmdInsert.ExecuteNonQuery();
            con.Close();

            // Crear un nuevo comando para la consulta de selección
            SqlCommand cmdSelect = new SqlCommand("SP_TMP_VENTA", con);
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.Parameters.AddWithValue("op", 4);
            cmdSelect.Parameters.AddWithValue("@TMP_VEN_ID", Convert.ToInt32(txtidventa.Text));

            con.Open();
            SqlDataReader rd = cmdSelect.ExecuteReader();
            List<cltempventa> lista = new List<cltempventa>();

            while (rd.Read())
            {
                // Verificar si hay suficientes columnas antes de intentar leerlas
                if (rd.FieldCount >= 6)
                {
                    cltempventa _venta = new cltempventa()
                    {
                        TMP_VEN_ID = Convert.ToInt32(rd[0]),
                        TMP_VEN_CLI_ID = Convert.ToInt32(rd[1]),
                        TMP_VENFECHA = Convert.ToDateTime(rd[2]),
                        TMP_VEDCANTIDAD = Convert.ToInt32(rd[3]),
                        TMP_VEDPRECIO = Convert.ToDouble(rd[4]),
                        TMP_VEDIMPORTE = Convert.ToDouble(rd[5]),
                        TMP_VED_PRO_ID = Convert.ToInt32(rd[6]),
                    };
                    lista.Add(_venta);
                }
                else
                {
                    MessageBox.Show("El resultado del procedimiento almacenado no tiene suficientes columnas.");
                }
            }

            con.Close();
            dtaCliente.ItemsSource = lista;
        }

        private void btnguardar_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }

        private void dtaCliente_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            
        }
    }
}
