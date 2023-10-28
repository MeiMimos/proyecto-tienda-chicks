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
    /// Lógica de interacción para Window5.xaml
    /// </summary>
    public partial class Window5 : Window
    {
        public Window5()
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
                cmd.CommandText = "INSERT INTO CLIENTE(CLI_ID, CLI_NOMBRE, CLI_APP, CLI_APM, CLI_TELEFONO)VALUES(" + Convert.ToInt32(txtidc.Text) + ",'" + txtnombrec.Text + ",'" + txtappc.Text + ",'" + txtapmc.Text + ",'"+ txttelefonoc.Text + "')";
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

        private void btnguardarc_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }
    }
}
