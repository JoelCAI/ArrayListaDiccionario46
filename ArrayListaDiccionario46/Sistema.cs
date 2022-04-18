using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
	public class Sistema
	{
		private List<UsuarioAdministrador> _usuarioAdministador;

		private List<Producto> _producto;
		private List<Venta> _venta;

		public Sistema()
		{
			this._usuarioAdministador = new List<UsuarioAdministrador>();
			this._producto = new List<Producto>();
			this._venta = new List<Venta>();
		}

		public void MenuPrincipal()
		{
			Validador.Bienvenida();

			int opcion;
			string nombre;

			int posUsuarioA;

			/* Para crear los objetos (Los Usuarios que tendran acceso a las listas) */
			UsuarioAdministrador uA;

			do
			{
				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menú de Registro de Datos: " +
									   "\n [1] Ingresar como Administrador." +
									   "\n [2] Salir del Sistema.", 1, 2);
				switch (opcion)
				{
					/* Aqui vamos a validar que el usuario exista */
					case 1:
						Console.Clear();
						nombre = "Usuario";
						/* Creo el nuevo usuario */	
						uA = new UsuarioAdministrador(nombre, this._producto,this._venta);
						/* Lo agrego a la lista de Repositores */
						_usuarioAdministador.Add(uA);
						Console.Clear();
						Console.WriteLine("\n Bienvenido *" + nombre + "*.");
						posUsuarioA = 0;
						if (posUsuarioA != -1)
						{
							_usuarioAdministador[posUsuarioA].MenuAdministrador(this._producto,this._venta);
							this._producto = _usuarioAdministador[posUsuarioA].Producto;
							this._venta = _usuarioAdministador[posUsuarioA].Venta;
						}

						break;

				}

			} while (opcion != 2);
			Console.Clear();
			Validador.Despedida();

		}

		public void Iniciar()
		{
			MenuPrincipal();
		}
	}
}