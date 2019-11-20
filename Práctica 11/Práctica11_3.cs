using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Práctica_11
{
    class Práctica11_3
    {
        //Andrés Lemus 30/10/2019
        
        static void Main(string[] args)
        {
            FileStream stream;
            BinaryWriter archivo;
            BinaryReader archivoLeer = null;
            int op;
            int anchoReg = 9 + 20 + 4 + 16;
            int numReg = 0;
            try
            {
                do
                {
                    stream = new FileStream("alumnos.bin", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    archivo = new BinaryWriter(stream);
                    archivoLeer = new BinaryReader(stream);
                    numReg = Convert.ToInt32(Math.Ceiling((decimal) stream.Length / anchoReg));
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("FICHA DE ALUMNOS DE PROGRAMACIÓN ESTRUCTURADA");
                        Console.WriteLine("=======================================================");
                        Console.WriteLine("1- Agregar Alumno");
                        Console.WriteLine("2- Mostrar Alumnos");
                        Console.WriteLine("3- Buscar Alumno");
                        Console.WriteLine("4- Salir");
                        if (int.TryParse(Console.ReadLine(), out op) && op >= 1 && op <= 4)
                        {
                            switch (op)
                            {
                                case 1:
                                    try
                                    {
                                        Console.Clear();
                                        numReg = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoReg));
                                        archivo.BaseStream.Seek(numReg * anchoReg, SeekOrigin.Begin);
                                        Console.WriteLine("Datos del Alumno");
                                        Console.Write("Carnet: ");
                                        string carnet = Console.ReadLine();
                                        if (carnet.Length > 9)
                                            carnet = carnet.Substring(0, 9);
                                        else
                                            carnet.PadRight(9, ' ');
                                        Console.Write("Nombre: ");
                                        string nombre = Console.ReadLine();
                                        if (nombre.Length > 20)
                                            nombre = nombre.Substring(0, 20);
                                        else
                                            nombre.PadRight(20, ' ');
                                        Console.Write("Edad: ");
                                        int edad = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("CUM: ");
                                        decimal cum = Convert.ToDecimal(Console.ReadLine());
                                        archivo.Write(carnet);
                                        archivo.Write(nombre);
                                        archivo.Write(edad);
                                        archivo.Write(cum);
                                        Console.WriteLine();
                                        Console.WriteLine("¡Alumno ingresado con éxito!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }
                                    break;
                                case 2:
                                    try
                                    {
                                        bool rep;
                                        do
                                        {
                                            rep = false;
                                            Console.Clear();
                                            Console.WriteLine("Mostrar según: ");
                                            Console.WriteLine("1- Todos los alumnos");
                                            Console.WriteLine("2- Filtrados por CUM");
                                            if (int.TryParse(Console.ReadLine(), out op) && op >= 1 && op <= 2)
                                            {
                                                Console.Clear();
                                                switch (op)
                                                {
                                                    case 1:
                                                        try
                                                        {
                                                            numReg = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoReg));
                                                            archivoLeer.BaseStream.Seek(0, SeekOrigin.Begin);
                                                            Console.Clear();
                                                            Console.WriteLine("DATOS DE LOS ALUMNOS");
                                                            Console.WriteLine("================================================================");
                                                            Console.WriteLine("{0, -4} {1, -9} {2, -20} {3, -10} {4, -3}",
                                                                "No", "Carnet", "Nombre", "Edad", "CUM");
                                                            Console.WriteLine("================================================================");
                                                            int num = 1;

                                                            do
                                                            {
                                                                string carnet = archivoLeer.ReadString();
                                                                string nombre = archivoLeer.ReadString();
                                                                int edad = archivoLeer.ReadInt32();
                                                                decimal cum = archivoLeer.ReadDecimal();
                                                                Console.Write("{0, -5}", num);
                                                                Console.Write("{0, -10}", carnet);
                                                                Console.Write("{0, -21}", nombre);
                                                                Console.Write("{0, -11}", edad + " años");
                                                                Console.Write("{0, -4}", cum.ToString("N1"));
                                                                Console.WriteLine();
                                                                archivoLeer.BaseStream.Seek(num * anchoReg, SeekOrigin.Begin);
                                                                num++;
                                                            } while (true);
                                                        }
                                                        catch (Exception)
                                                        {
                                                        }
                                                        break;
                                                    case 2:
                                                        try
                                                        {
                                                            Console.Clear();
                                                            Console.Write("Valor de CUM que desea mostrar: ");
                                                            decimal valCum = Convert.ToDecimal(Console.ReadLine());
                                                            numReg = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoReg));
                                                            archivoLeer.BaseStream.Seek(0, SeekOrigin.Begin);
                                                            Console.Clear();
                                                            Console.WriteLine("DATOS DE LOS ALUMNOS");
                                                            Console.WriteLine("================================================================");
                                                            Console.WriteLine("{0, -4} {1, -9} {2, -20} {3, -10} {4, -3}",
                                                                "No", "Carnet", "Nombre", "Edad", "CUM");
                                                            Console.WriteLine("================================================================");
                                                            int num = 1, n = 1;
                                                            decimal cum;
                                                            do
                                                            {
                                                                
                                                                string carnet = archivoLeer.ReadString();
                                                                string nombre = archivoLeer.ReadString();
                                                                int edad = archivoLeer.ReadInt32();
                                                                cum = archivoLeer.ReadDecimal();
                                                                if (valCum == cum)
                                                                {
                                                                    Console.Write("{0, -5}", n);
                                                                    Console.Write("{0, -10}", carnet);
                                                                    Console.Write("{0, -21}", nombre);
                                                                    Console.Write("{0, -11}", edad + " años");
                                                                    Console.Write("{0, -4}", cum.ToString("N1"));
                                                                    Console.WriteLine();
                                                                    n++;
                                                                }
                                                                archivoLeer.BaseStream.Seek(num * anchoReg, SeekOrigin.Begin);
                                                                num++;
                                                            } while (valCum != cum && true);
                                                        }
                                                        catch (Exception)
                                                        {
                                                            Console.Clear();
                                                            Console.WriteLine("EL CUM ESPECIFICADO NO ESTA REGISTRADO");
                                                            //throw;
                                                        }
                                                        break;
                                                   
                                                    default:
                                                        break;
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Tiene que ser un número entre 1 y 2 :c");
                                                rep = true;
                                            }
                                        } while (rep == true);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                        throw;
                                    }                                    
                                    break;
                                case 3:
                                    try
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Carnet que desea buscar: ");
                                        string car = Console.ReadLine();
                                        numReg = Convert.ToInt32(Math.Ceiling((decimal)stream.Length / anchoReg));
                                        archivoLeer.BaseStream.Seek(0, SeekOrigin.Begin);

                                        int num = 1;
                                        string carnet;

                                        do
                                        {
                                            carnet = archivoLeer.ReadString();
                                            string nombre = archivoLeer.ReadString();
                                            int edad = archivoLeer.ReadInt32();
                                            decimal cum = archivoLeer.ReadDecimal();
                                            if (car == carnet)
                                            {
                                                Console.Clear();
                                                Console.WriteLine("¡Alumno encontrado!");
                                                Console.WriteLine();
                                                Console.WriteLine("DATOS DEL ALUMNO");
                                                Console.WriteLine();
                                                Console.WriteLine("Carnet: " + carnet);
                                                Console.WriteLine("Nombre: " +  nombre);
                                                Console.WriteLine("Edad: " + edad + " años");
                                                Console.WriteLine("CUM: " + cum.ToString("N1"));
                                            }
                                            archivoLeer.BaseStream.Seek(num * anchoReg, SeekOrigin.Begin);
                                            num++;
                                        } while (car != carnet && true);
                                    }
                                    catch (Exception)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("EL CARNET ESPECIFICADO NO ESTA REGISTRADO");
                                        //throw;
                                    }

                                    break;
                            }
                            if (op != 4)
                            {
                                Console.ReadKey();
                            }
                            Console.Clear();
                        }
                    } while (op != 4);
                    Console.WriteLine("¡Hasta Pronto!");
                    Console.ReadKey();
                    archivo.Close();
                    archivoLeer.Close();
                } while (op != 4);
            }
            catch (Exception)
            {

            }
        }
    }
}
