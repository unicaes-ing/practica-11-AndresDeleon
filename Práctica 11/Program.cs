using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Práctica_11
{
    class Program
    {
        //Andrés Lemus 30/10/2019
        static void Main(string[] args)
        {
            try
            {
                FileStream stream = new FileStream("cliente.bin", FileMode.Create, FileAccess.Write);
                BinaryWriter archivo = new BinaryWriter(stream);
                Console.WriteLine("DATOS DEL CLIENTE");
                Console.WriteLine("==========================================");
                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.WriteLine("Fecha de Nacimiento: ");
                string nacimiento = Console.ReadLine();
                Console.WriteLine("Salario: "); Console.Write("$");
                decimal salario = Convert.ToDecimal(Console.ReadLine());
                archivo.Write(nombre);
                archivo.Write(telefono);
                archivo.Write(nacimiento);
                archivo.Write(salario);
                archivo.Close();
                Console.WriteLine("¡Datos ingresados con éxito!");
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
