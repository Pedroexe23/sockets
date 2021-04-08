using ChatserverApp.comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatserverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = Int32.Parse(ConfigurationManager.AppSettings["puerto"]);
            Console.WriteLine("Iniciando Servidor en puerto {0}", puerto);
            ServerSocket servidor = new ServerSocket(puerto);
            if (servidor.iniciar())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Esperando Clientes");
                if (servidor.ObtenerCliente())
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Conexion Establecida");
                    Console.WriteLine("S: Hola Mundo Cliente");
                    servidor.Escribir("Hola Mundo Cliente");
                    String mensaje = servidor.Leer();
                    Console.WriteLine("C:{0}", mensaje);
                    
                    servidor.CerraConexion();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no es posible iniciar Servidor");
                Console.ReadKey();
            }



        }
    }
}
