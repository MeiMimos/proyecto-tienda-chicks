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
    /// Lógica de interacción para Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
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
    }
}
