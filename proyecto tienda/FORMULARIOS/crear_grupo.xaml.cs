using proyecto_tienda.CLASES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
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

namespace proyecto_tienda
{
    /// <summary>
    /// Lógica de interacción para Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        int iEstante; 
        public Window6()
        {
            InitializeComponent();
            ObservableCollection<clestanteria> lista = new ObservableCollection<clestanteria>(GetDatabase.ObtenerEstanteria(clconexion.Conectar()));
            cboxEstantes.ItemsSource = lista;
          
        }

        private void btnRegresarGrupo_Click(object sender, RoutedEventArgs e)
        {
            Window2 x = new Window2();
            x.Show();
            this.Close();
        }

        private void Guardar()
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("INSERT INTO GRUPO(GRU_ID, GRU_NOMBRE, GRU_COLORES,GRU_EST_ID) VALUES (@GRU_ID, @GRU_NOMBRE,@GRU_COLORES,@GRU_EST_ID)", con);
            bool todobien = false;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@GRU_ID", Convert.ToInt32(txtIdGrupo.Text));
                cmd.Parameters.AddWithValue("@GRU_NOMBRE", txtNombreGrupo.Text);
                cmd.Parameters.AddWithValue("@GRU_COLORES", txtColorGrupo.Text);
                cmd.Parameters.AddWithValue("@GRU_EST_ID", iEstante);
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
                    MessageBox.Show("Sus datos se guardaron correctamente.");
                }
            }
            con.Close();
        }
        private void btnGuardarGrupo_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void txtIdGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.OemPeriod)
            {
                if (e.Key == Key.OemPeriod && txtIdGrupo.Text.IndexOf('.') != -1)
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else
            {
                MessageBox.Show("Sólo admite números.");
            }
        }

        private void cboxEstantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var estante = cboxEstantes.SelectedItem;
            Type t = estante.GetType();
            PropertyInfo p = t.GetProperty("EST_ID");
            iEstante = (int)p.GetValue(estante, null);

        }

        private void txtNombreGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                cboxEstantes.Focus();
            }
        }

        private void cboxEstantes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                txtColorGrupo.Focus();
            }
        }

        private void txtColorGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnGuardarGrupo.Focus();
            }
        }
    }
}
