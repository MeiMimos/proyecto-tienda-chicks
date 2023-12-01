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
                }
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
