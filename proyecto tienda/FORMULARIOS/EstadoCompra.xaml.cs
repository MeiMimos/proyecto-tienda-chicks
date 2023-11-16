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
    /// Lógica de interacción para EstadoCompra.xaml
    /// </summary>
    public partial class EstadoCompra : Window
    {
        public buscarcompra()
        {
            InitializeComponent();
            ObservableCollection<clcliente> lista = new ObservableCollection<clcomp>(GetDataBase.ObtenerClienteFiltro(clsconexion.Conectar()));
            filtroCompra.ItemsSource = lista;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<clcliente> lista = new ObservableCollection<clcliente>(GetDataBase.ObtenerClienteFiltro(clsconexion.Conectar(), txtfiltro.Text));
            dgvfiltro.ItemsSource = lista;
        }
    }
}
