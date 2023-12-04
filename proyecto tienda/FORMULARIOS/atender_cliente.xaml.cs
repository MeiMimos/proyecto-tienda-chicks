using proyecto_tienda.FORMULARIOS;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7()
        {
            InitializeComponent();
            Data();
            WindowState = WindowState.Maximized;
        }
        private int contadorId = 1;
        private DataTable dataTable;
        public string nombreCliente;
        private void txtidcliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarcliente bc = new buscarcliente();
                bc.ShowDialog();
            }
        }

        private void txtidproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F2)
            {
                buscarProducto bc = new buscarProducto();
                bc.ShowDialog();
            }

        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
                
        }


        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }

        private void Data()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Producto", typeof(string));
            dataTable.Columns.Add("Cantidad", typeof(int));
            dataTable.Columns.Add("Precio", typeof(float));
            dataTable.Columns.Add("Descripción", typeof(string));
            //dtaProducto.DataSource = dataTable;                       
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string producto = txtproducto.Text;
            int cantidad;
            decimal precio;
            string desc = txtdesc.Text;

            if(int.TryParse(txtcantidad.Text, out cantidad) && decimal.TryParse(txtprecios.Text, out precio))
            {
                DataRow row = DataTable();
                row["ID"] = contadorId;
                row["Producto"] = producto;
                row["Cantidad"] = cantidad;
                row["Precio"] = precio;
                row["Descripción"] = desc;

                contadorId++;

                txtproducto.Clear();
                txtcantidad.Clear();
                txtprecios.Clear();
                txtdesc.Clear();
            }
            else
            {
                MessageBox.Show("Ingrese valores válidos para cantidad y precio.", "Error", MessageBoxButton.OK);
            }


        }

        private DataRow DataTable()
        {
            throw new NotImplementedException();
        }
    }
}
