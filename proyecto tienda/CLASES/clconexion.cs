using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto_tienda.CLASES
{
    public class clconexion
    {
        public static string Conectar()
        {
            string con = "DATA SOURCE=MEI\\SQLEXPRESS;INITIAL CATALOG=BDCHICKS;USER ID=SA;PASSWORD=132020;";
            return con;
        }
    }
    
}
