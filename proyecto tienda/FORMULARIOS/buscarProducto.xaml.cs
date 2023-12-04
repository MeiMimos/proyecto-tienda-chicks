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
    /// Lógica de interacción para buscarProducto.xaml
    /// </summary>
    public partial class buscarProducto : Window
    {
        public int iProducto;
       public buscarProducto()
        {
            InitializeComponent();
            ObservableCollection<clproducto> lista = new ObservableCollection<clproducto>(GetDatabase.ObtenerProductoFiltro(clconexion.Conectar(), txtfiltroPro.Text));
            filtroPro.ItemsSource = lista;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<clproducto> lista = new ObservableCollection<clproducto>(GetDatabase.ObtenerProductoFiltro(clconexion.Conectar(), txtfiltroPro.Text));
            filtroPro.ItemsSource = lista;
        }
 

        private void filtroPro_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var vProducto = filtroPro.SelectedItem;
            Type t = vProducto.GetType();
            PropertyInfo p = t.GetProperty("PRO_ID");
            iProducto = (int)p.GetValue(vProducto, null);
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}

