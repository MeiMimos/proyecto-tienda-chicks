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
using proyecto_tienda.FORMULARIOS;
using System.Reflection;

namespace proyecto_tienda
{
    /// <summary>
    /// Lógica de interacción para Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        int iEstante;
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
            SqlCommand cmd = new SqlCommand("INSERT INTO PRODUCTO(PRO_ID, PRO_PRECIO, PRO_UNIDAD, PRO_GRU_ID, PRO_DESCRIPCION)VALUES(PRO_ID, PRO_PRECIO, PRO_UNIDAD, PRO_GRU_ID, PRO_DESCRIPCION)", con);
            bool todobien = false;
            try
            {
                con.Open();
                /*cmd.CommandText = "INSERT INTO PRODUCTO(PRO_ID, PRO_PRECIO, PRO_UNIDAD, PRO_GRU_ID, PRO_DESCRIPCION)VALUES(" + Convert.ToInt32(txtidp.Text) + ",'" + txtpreciop.Text + ",'" + txtunidadp.Text + ",'" + cbgrupo.SelectedValue + ",'" + txtdescp.Text + "')";*/
                
                cmd.Parameters.AddWithValue("@PRO_ID", Convert.ToInt32(txtidp));
                cmd.Parameters.AddWithValue("@PRO_PRECIO", Convert.ToInt32(txtpreciop));
                cmd.Parameters.AddWithValue("@PRO_UNIDAD", Convert.ToInt32(txtunidadp));
                cmd.Parameters.AddWithValue("@PRO_GRU_ID", iEstante);
                cmd.Parameters.AddWithValue("@PRO_DESCRIPCION",txtdescp.Text);
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

        private void btnRegresarIngPro_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1();  
            x.Show();
            this.Close();
        }

        private void cbgrupo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var estante = cbgrupo.SelectedItem;
            Type t = estante.GetType();
            PropertyInfo p = t.GetProperty("GRU_ID");
            iEstante = (int)p.GetValue(estante, null);
        }

        private void txtidp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtpreciop.Focus();
            }
        }

        private void txtpreciop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtunidadp.Focus();
            }
        }

        private void txtunidadp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cbgrupo.Focus();
            }
        }

        private void cbgrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtdescp.Focus();
            }
        }

        private void txtdescp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnCrearGrupo.Focus();
            }
        }
    }
}
