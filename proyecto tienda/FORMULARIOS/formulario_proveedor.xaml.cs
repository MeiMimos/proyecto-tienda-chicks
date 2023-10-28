using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Lógica de interacción para Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

         private void Guardar()
        {
            SqlConnection con = new SqlConnection(clsconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            bool todobien = false;
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO PROVEEDOR(PRV_ID, PRV_NOMBRE, PRV_TELEFONO)VALUES(" + Convert.ToInt32(txtidp.Text) + ",'" + txtnombrep.Text + ",'" + txtcontactop.Text + "')";
                cmd.ExecuteNonQuery();
                todobien = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudieron guardar los datos. " + e);
            }
            finally
            {
                if (todobien == true)
                {
                    MessageBox.Show("Sus datos fueron guardados correctamente.");
                }
            }
            con.Close();
        }

        private void btnguardarp_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
    }
}
