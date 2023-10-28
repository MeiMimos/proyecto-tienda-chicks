using proyecto_tienda.CLASES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            ObservableCollection<clgrupo> lista = new ObservableCollection<clgrupo>(GetDataBase.ObtenerGrupo(clsconexion.Conectar()));
            cbgrupo.ItemsSource = lista;
        }
        private void Guardar()
        {
            SqlConnection con = new SqlConnection(clsconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            bool todobien = false;
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO PRODUCTO(PRO_ID, PRO_PRECIO, PRO_UNIDAD, PRO_GRU_ID, PRO_DESCRIPCION)VALUES(" + Convert.ToInt32(txtidp.Text) + ",'" + txtpreciop.Text + ",'" + txtunidadp.Text + ",'" + cbgrupo.SelectedValue + ",'" + txtdescp.Text + "')";
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
