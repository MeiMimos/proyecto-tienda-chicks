using proyecto_tienda.CLASES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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

namespace proyecto_tienda.FORMULARIOS
{
    /// <summary>
    /// Lógica de interacción para buscarcliente.xaml
    /// </summary>
    public partial class buscarcliente : Window
    {

        public int iCliente;
        public buscarcliente()
        {
            InitializeComponent();
            ObservableCollection<clcliente> lista = new ObservableCollection<clcliente>(GetDatabase.ObtenerClienteFiltro(clconexion.Conectar(),txtfiltro.Text));
            dgvfiltro.ItemsSource = lista;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<clcliente> lista = new ObservableCollection<clcliente>(GetDatabase.ObtenerClienteFiltro(clconexion.Conectar(), txtfiltro.Text));
            dgvfiltro.ItemsSource = lista;
        }

        private void dgvfiltro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var Cliente = dgvfiltro.SelectedItem;
            Type t = Cliente.GetType();
            PropertyInfo p = t.GetProperty("CLI_ID");
            iCliente = (int)p.GetValue(Cliente, null);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

