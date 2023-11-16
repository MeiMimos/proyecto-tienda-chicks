using proyecto_tienda.CLASES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace proyecto_tienda.FORMULARIOS
{
    /// <summary>
    /// Lógica de interacción para buscarProducto.xaml
    /// </summary>
    public partial class buscarProducto : Window
    {
        public buscarProducto()
        {
            InitializeComponent();
            ObservableCollection<clcliente> lista = new ObservableCollection<clcliente>(GetDatabase.ObtenerClienteFiltro(clconexion.Conectar()));
            filtroPro.ItemsSource = lista;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<clcliente> lista = new ObservableCollection<clcliente>(GetDatabase.ObtenerClienteFiltro(clconexion.Conectar(), txtfiltroPro.Text));
            filtroPro.ItemsSource = lista;
        }
    }
}

