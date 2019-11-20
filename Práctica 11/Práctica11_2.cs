using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Práctica_11
{
    class Práctica11_2
    {
        //Andrés Lemus 30/10/2019
        static void Main(string[] args)
        {
            try
            {
                FileStream stream = new FileStream("cliente.bin", FileMode.Open, FileAccess.Read);
                BinaryReader archivo = new BinaryReader(stream);
                string nombre = archivo.ReadString();
                string telefono = archivo.ReadString();
                string fecha = archivo.ReadString();
                decimal salario = archivo.ReadDecimal();
                Console.WriteLine("DATOS DEL CLIENTE");
                Console.WriteLine("==========================================");
                Console.WriteLine("Nombre: " + nombre);
                Console.WriteLine("Télefono: " + telefono);
                Console.WriteLine("Fecha de Nacimiento: " + fecha);
                Console.WriteLine("Salario: " + salario.ToString("C1"));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }
    }
}
