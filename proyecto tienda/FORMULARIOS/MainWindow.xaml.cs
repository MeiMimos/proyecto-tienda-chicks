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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto_tienda
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();
            x.Show();
            this.Close();
        }

        private void btnCrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            usuario_detalle x = new usuario_detalle();  
            x.Show();
            this.Close();
        }

    }
}
