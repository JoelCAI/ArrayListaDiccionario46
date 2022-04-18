using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
    public class Validador
    {
        public static int PedirIntRegistro(string mensaje)
        {
            /* la salida de esta funcion estará en la variable int valor */
            string mensError = "\n Recuerde que ingreso a la opción eliminar por Número de Registro.\n" +
                               "\n Por favor ingrese el valor solicitado y el Sistema continuará" +
                               "\n Debe ingresar un valor que no sea vacio y que ese valor sea un número. ";

            int valor;

            Console.WriteLine(mensaje);

            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Clear();
                Console.WriteLine(mensError);

                return PedirIntRegistro(mensaje);
            }
            else
                return valor;

        }

        public static string ValidarStringNoVacioUsuarioClave(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Puede ser combinación de minúsculas, MAYÚSCULAS y caracteres";
            string mensajeError = "\n Por favor ingrese un valor no vacio para que pueda continuar. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeValidador);

                opcion = Console.ReadLine();

                if (opcion == "")
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }

        public static void VolverMenu()
        {
            Console.WriteLine("\n Presione cualquier tecla para volver al Menú ");
            Console.ReadKey();
        }

        public static void Continuar()
        {
            Console.WriteLine("\n Presione cualquier tecla para continuar ");
            Console.ReadKey();
        }

        public static string ValidarSioNo(string mensaje)
        {

            string opcion;
            bool valido = false;
            string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
                                      "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
            string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeError);
                Console.WriteLine(mensajeValidador);
                opcion = Console.ReadLine().ToUpper();
                string opcionC = "SI";
                string opcionD = "NO";

                if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
                {
                    Console.Clear();
                    Console.WriteLine("\n");

                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return opcion;
        }

        public static int PedirIntMenu(string mensaje, int min, int max)
        {
            int valor;
            bool valido = false;
            string mensajeMenu = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar entre el rango del Menu solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeMenu);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirIntEntre(string mensaje, int min, int max)
        {
            int valor;
            bool valido = false;
            string mensajeValidador = "\n Ingrese un valor entre " + min + " y " + max;
            string mensajeError = "\n El valor no puede ser vacio y tiene que estar dentro del rango solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeValidador);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirIntMayorA(string mensaje, int min)
        {
            int valor;
            bool valido = false;
            string mensajeValidador = "\n Ingrese un valor mayor a " + min;
            string mensajeError = "\n El valor no puede ser vacio y tiene que cumplir con lo solicitado. ";

            do
            {

                Console.WriteLine(mensaje);
                Console.WriteLine(mensajeValidador);

                if (!int.TryParse(Console.ReadLine(), out valor) || valor <= min)
                {
                    Console.Clear();
                    Console.WriteLine("\n");
                    Console.WriteLine(mensajeError);
                }
                else
                {
                    valido = true;
                }

            } while (!valido);

            return valor;

        }

        public static int PedirInt(string mensaje)
        {
            /* la salida de esta funcion estará en la variable long valor */
            string mensError = "\n\n Por favor ingrese el valor solicitado" +
                               "\n Debe ingresar un valor que no sea vacio y que ese valor sea un numero. ";

            int valor;
            Console.WriteLine(mensaje);

            if (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Clear();
                Console.WriteLine(mensError);
                return PedirInt(mensaje);
            }
            else
                return valor;
        }

        public static void Bienvenida()
        {
            Console.WriteLine("\n Bienvenido al Programa");
            Console.WriteLine("\n Usted podrá crear Producto(s) y Precio(s). Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        public static void Despedida()
        {

            Console.WriteLine("\n Gracias por usar nuestro Sistema presione cualquier teclar para finalizar");
            Console.ReadKey();
        }
    }
}