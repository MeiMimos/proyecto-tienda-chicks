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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace proyecto_tienda
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnInicioSesion_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(clconexion.Conectar());
            SqlCommand cmd = new SqlCommand("", con);
            con.Open();

            string login = "SELECT * FROM USUARIO WHERE USU_NOMBRE='" + txtUsuarioInicio.Text + "'AND USU_CONTRASENA= '" + txtContraseñaInicio.Password + "'";
            cmd = new SqlCommand(login, con);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                Window1 x = new Window1();
                x.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos Incorrectos", "ERROR LOGIN", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsuarioInicio.Text = "";
                txtContraseñaInicio.Password = "";
                txtUsuarioInicio.Focus();

            }
        }
    }
}

