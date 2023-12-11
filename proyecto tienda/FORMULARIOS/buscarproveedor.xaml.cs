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
    /// Lógica de interacción para buscarproveedor.xaml
    /// </summary>
    public partial class buscarproveedor : Window
    {
        

        public int iProveedor;
        public buscarproveedor()
        {
            InitializeComponent();
            ObservableCollection<clproveedor> lista = new ObservableCollection<clproveedor>(GetDatabase.ObtenerProveedorFiltro(clconexion.Conectar(), txtfiltro.Text));
            dgvfiltro.ItemsSource = lista;
        }
        private void txtfiltro_TextChanged(object sender, TextChangedEventArgs e)
        {
            ObservableCollection<clproveedor> lista = new ObservableCollection<clproveedor>(GetDatabase.ObtenerProveedorFiltro(clconexion.Conectar(), txtfiltro.Text));
            dgvfiltro.ItemsSource = lista;
        }

        private void dgvfiltro_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            var vProveedor = dgvfiltro.SelectedItem;
            Type t = vProveedor.GetType();
            PropertyInfo p = t.GetProperty("PRV_ID");
            iProveedor = (int)p.GetValue(vProveedor, null);
            PropertyInfo pNombre = t.GetProperty("PRV_NOMBRE");
            string nombre_prv = (string)pNombre.GetValue(vProveedor, null);
        }

        private void btnaceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btncancelar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
