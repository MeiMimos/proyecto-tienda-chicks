using proyecto_tienda.CLASES;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica de interacción para Window6.xaml
    /// </summary>
    public partial class Window6 : Window
    {
        public Window6()
        {
            InitializeComponent();
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
            SqlCommand cmd = new SqlCommand("INSERT INTO GRUPO(GRU_ID, GRU_EST_ID, GRU_COLORES) VALUES (@GRU_ID, @GRU_EST_ID, @GRU_COLORES)", con);
            bool todobien = false;
            try
            {
                con.Open();
                cmd.Parameters.AddWithValue("@GRU_ID", Convert.ToInt32(txtIdGrupo.Text));
                cmd.Parameters.AddWithValue("@GRU_EST_ID", cboxEstantes.Text);
                cmd.Parameters.AddWithValue("@GRU_COLORES", txtColorGrupo.Text);
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
    }
}
