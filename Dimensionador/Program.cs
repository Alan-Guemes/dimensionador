using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dimensionador
{
    class Program
    {
        static void Main(string[] args)
        {
            double PCTFREE;

            int campos;
            int[] tamañocampo;
            string[] tipocampo;

            int encabezadoregistro;
            int[] tamañoencabezado;
            int[] registros;

            double espaciobloque;
            double cabecerabloque;
            double filasbloque;
            double espaciototal;

            int tuplas = 0;
            double longitudfila;
            double espacioutil;

            Console.WriteLine("Bienvenido!");
            Console.WriteLine("Programa de dimensionamiento");
            Console.Write("Ingrese el No. de Campos: ");
            campos = int.Parse(Console.ReadLine());

            longitudfila = 0;
            tamañocampo = new int[campos];
            tamañoencabezado = new int[campos];
            registros = new int[campos];
            encabezadoregistro = 0;
            tipocampo = new string[campos];
            for (int c = 0; c < campos; c++)
            {
                Console.Write("(C" + (c + 1) + ")" + " Ingrese el tipo del campo: ");
                tipocampo[c] = Console.ReadLine();
                Console.Write("(C" + (c + 1) + ")" + " Ingrese el tamaño del campo(en bytes): ");
                tamañocampo[c] = int.Parse(Console.ReadLine());
                Console.Write("(C" + (c + 1) + ")" + " Ingrese el No. de registros: ");
                registros[c] = int.Parse(Console.ReadLine());
                Console.Write("(C" + (c + 1) + ")" + " Ingrese el espacio que ocupa el encabezado del campo(en bytes): ");
                tamañoencabezado[c] = int.Parse(Console.ReadLine());
                longitudfila = longitudfila + tamañocampo[c] + tamañoencabezado[c];
                if(tuplas == 0) 
                {
                    tuplas = registros[c];
                }
                else if (registros[c]!=0)
                {
                    tuplas = tuplas * registros[c];
                }
                Console.WriteLine();
            }

            Console.Write("Ingrese el espacio que ocupa el encabezado del registro(en bytes): ");
            encabezadoregistro = int.Parse(Console.ReadLine());
            Console.WriteLine();
            longitudfila = longitudfila + encabezadoregistro;
            Console.Write("Ingrese el espacio que ocupa cada bloque(en kilobytes): ");
            espaciobloque = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Ingrese el espacio que ocupa la cabecera del bloque(en bytes): ");
            cabecerabloque = double.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Resultados: ");
            Console.WriteLine("Cantidad de tuplas: " + tuplas + " tuplas");
            Console.WriteLine("Longitud de fila: " + longitudfila + " bytes");

            espacioutil = (espaciobloque * 1024) - cabecerabloque;
            Console.WriteLine("Espacio útil: " + espacioutil + " bytes");

            filasbloque = espacioutil / longitudfila;
            filasbloque = Math.Floor(filasbloque);
            Console.WriteLine("No. Filas por bloque: " + filasbloque + " filas");

            espaciototal = tuplas / filasbloque;
            espaciototal = Math.Ceiling(espaciototal);
            Console.WriteLine("Espacio total requerido: " + espaciototal + " bloques");
            espaciototal = espaciototal * espaciobloque;
            Console.WriteLine("Espacio total requerido: " + espaciototal + " kilobytes");

            Console.WriteLine();
            Console.WriteLine("Campos: ");
            for (int c = 0; c < campos; c++)
            {
                Console.WriteLine("////////////////////////////////////////////////////////");
                Console.WriteLine("(C" + (c + 1) + ")" + " Tipo del campo: " + tipocampo[c]);
                Console.WriteLine("(C" + (c + 1) + ")" + " Tamaño del campo: " + tamañocampo[c] + " bytes");
                Console.WriteLine("(C" + (c + 1) + ")" + " No. de registros: " + registros[c]);
                Console.WriteLine("(C" + (c + 1) + ")" + " Espacio que ocupa el encabezado del campo: " + tamañoencabezado[c] + " bytes");
                Console.WriteLine("(C" + (c + 1) + ")" + " Espacio que ocupa el encabezado del registro: " + encabezadoregistro + " bytes");
            }
            Console.ReadKey();
        }
    }
}
