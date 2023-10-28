﻿using proyecto_tienda.CLASES;
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
               // cmd.CommandText = "INSERT INTO CLIENTE(CLI_NOM, CLI_APP, CLI_APM, CLI_APM, CLI_TELEFONO)VALUES(" + Convert.ToInt32(txtidc.Text) + ",'" + txtnombrec.Text + ",'" + txtappc.Text + ",'" + txtapmc.Text + ",'" + txttelefonoc.Text + "')";
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


        private void btnRegresarUsuario_Click(object sender, RoutedEventArgs e)
        {
            MainWindow x = new MainWindow();
            x.Show();
            this.Close();
        }

        private void btnCrearUsuario_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
