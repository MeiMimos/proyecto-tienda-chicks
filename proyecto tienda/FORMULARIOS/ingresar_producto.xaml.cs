using System;
using System.Collections.Generic;
using System.Linq;
using proyecto_tienda.CLASES;
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
using System.Data.SqlClient;
using proyecto_tienda.CLASES;
using System.Collections.ObjectModel;

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
            ObservableCollection<clgrupo> lista = new ObservableCollection<clgrupo>(GetDatabase.ObtenerGrupo(clconexion.Conectar()));
            cbgrupo.ItemsSource = lista;

        }

        private void btnCrearGrupo_Click(object sender, RoutedEventArgs e)
        {
            Window6 x = new Window6();
            x.Show();
            this.Close();

        }

        private void Guardar()
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
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
                MessageBox.Show("No se pudieron guardar los datos. ");
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

        private void btnRegresarIngPro_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();  
            x.Show();
            this.Close();
        }
    }
}
