using proyecto_tienda.CLASES;
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
    /// Lógica de interacción para usuario_detalle.xaml
    /// </summary>
    public partial class usuario_detalle : Window
    {
        public usuario_detalle()
        {
            InitializeComponent();
        }

        private void Guardar()
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            bool todobien = false;
            try
            {
                con.Open();
                cmd.CommandText = "INSERT INTO USUARIO(USU_ID, USU_NOMBRE, USU_CONTRASENA) VALUES(@USU_ID, @USU_NOMBRE, @USU_CONTRASENA)";
                cmd.Parameters.AddWithValue("@USU_ID", Convert.ToInt32(txtIdUsuario.Text));
                cmd.Parameters.AddWithValue("@USU_NOMBRE", txtNomUsuario.Text);
                cmd.Parameters.AddWithValue("@USU_CONTRASENA", txtContraUsuarioUnico.Text);
                cmd.ExecuteNonQuery();
                todobien = true;

                /*con.Open();
                cmd.CommandText = "INSERT INTO USUARIO(USU_ID, USU_NOMBRE, USU_CONTRASENA)VALUES(" + Convert.ToInt32(txtIdUsuario.Text) + ",'" + txtNomUsuario.Text + ",'" + txtContraUsuarioUnico.Text +"')";
                cmd.ExecuteNonQuery();
                todobien = true;*/
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


        private void btnRegresarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Window1 x = new Window1(); 
            x.Show();
            this.Close();
        }

        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
        }

        private void txtIdUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                txtNomUsuario.Focus();
            }
        }

        private void txtNomUsuario_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                txtContraUsuarioUnico.Focus();
            }
        }

        private void txtContraUsuarioUnico_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Return)
            {
                btnCrearUsuario.Focus();
            }
        }
    }
}
