using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginwpfk020.Datos
{
    internal class LoginDao
    { //mock up
        private const string NOMBRE_ARCHIVO = "C:\\usu.txt";//"C:\\Users\\cid\\source\\repos\\Loginwpfk020\\usuarios.txt";
        public Usuario readFile()
        {

            Usuario user = null;
            try
            {
                StreamReader sr = new StreamReader(NOMBRE_ARCHIVO);
                string line = sr.ReadLine();
                int contador = 1;
                user = new Usuario();
                while (line != null)
                {
                    Console.WriteLine("linea: " + line);
                    if (contador == 1)
                    {
                        user.Username = line;
                    }
                    if (contador == 2)
                    {
                        user.Password = line;
                    }
                    line = sr.ReadLine();
                    contador++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return user;


        }
    }
}
