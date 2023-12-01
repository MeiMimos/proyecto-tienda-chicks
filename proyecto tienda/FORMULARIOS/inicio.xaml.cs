using proyecto_tienda.FORMULARIOS;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void btnRegCliente_Click(object sender, RoutedEventArgs e)
        {
            Window5 x= new Window5();
            x.Show();
            this.Close();
        }

        private void btnRegProducto_Click(object sender, RoutedEventArgs e)
        {
            Window2 x= new Window2();
            x.Show();
            this.Close();
        }

        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            usuario_detalle x = new usuario_detalle();
            x.Show();
            this.Close();
        }

        private void btnRegProveedor_Click(object sender, RoutedEventArgs e)
        {
            Window4 x = new Window4();
            x.Show();
            this.Close();
        }

        private void btnRegCompra_Click(object sender, RoutedEventArgs e)
        {
            Window3 x = new Window3();
            x.Show();
            this.Close();
        }

        private void btnAtenCliente_Click(object sender, RoutedEventArgs e)
        {
            atender_clientes x = new atender_clientes();
            x.Show();
            this.Close();
        }
    }
}
