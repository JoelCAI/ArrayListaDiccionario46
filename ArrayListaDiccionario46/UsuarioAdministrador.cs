using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
	public class UsuarioAdministrador : Usuario
	{
		protected List<Producto> _producto;
		protected List<Venta> _venta;
		public List<Producto> Producto
		{
			get { return this._producto; }
			set { this._producto = value; }
		}

		public UsuarioAdministrador(string nombre, List<Producto> producto, List<Venta> venta) : base(nombre)
		{
			this._producto = producto;
			this._venta = venta;
		}

		public List<Venta> Venta
		{
			get { return this._venta; }
			set { this._venta = value; }
		}
		public void AddVenta(Venta venta)
		{
			this._venta.Add(venta);
		}


		public void MenuAdministrador(List<Producto> producto, List<Venta> venta)
		{
			Producto = producto;
			Venta = venta;
			int opcion;
			do
			{

				Console.Clear();
				opcion = Validador.PedirIntMenu("\n Menu del Sistema" +
									   "\n [1] Crear Producto(s)." +
									   "\n [2] Establecer Precio(s)." +
									   "\n [3] Crear Serie de Productos." +
									   "\n [4] Volver al menu Principal.", 1, 4);

				switch (opcion)
				{
					case 1:
						CrearProducto();
						break;
					case 2:
						EstablecerPrecioUnitario();
						
						break;
					case 3:
						RegistrarVenta();
						Validador.VolverMenu();
						break;

				}
			} while (opcion != 4);
		}

		protected override void EstablecerPrecioUnitario()
		{

			string codigo;
			
			string opcion;
			VerProducto();
			do
			{
				int precio;
				codigo = ValidarStringNoVacioProducto("\n Ingrese un código existente del producto del cual desea establecer su precio"+
					                                  "\n Recuerde que si NO ingresa un código existente el Sistema volverá a solicitar un código que lo sea." );

				if (BuscarProductoCodigo(codigo) == -1)
				{
					VerProducto();
					Console.WriteLine(" No existe un producto con el código: *" + codigo + "*. ");
					Validador.VolverMenu();

				}
				else
				{

					VerProducto();
					Console.WriteLine("\n ¡En hora buena! Puede utilizar este código para establecer el precio del Producto");
					Console.WriteLine("\n Si escribe *0* en el Precio regresará al Menú. ");
					precio = Validador.PedirInt("\n Ingrese el precio a establecer del producto");

					if (precio == 0)
					{
						break;
					}

					VerProducto();
					Console.WriteLine("\n Código del Producto a establecer Precio: " + Producto[BuscarProductoCodigo(codigo)].Codigo +
										"\n Nombre del Producto a establecer Precio " + Producto[BuscarProductoCodigo(codigo)].Nombre);
					Console.WriteLine("\n El nuevo precio del Producto será: " + precio);
					opcion = ValidarSioNoProducto("\n Está seguro que desea establecer el Precio de este Producto? ", codigo);
					if (opcion == "SI")
					{

						Producto[BuscarProductoCodigo(codigo)].Precio = precio;
						VerProducto();
						Console.WriteLine("\n Código de Producto : " + Producto[BuscarProductoCodigo(codigo)].Codigo +
											"\n Nombre de Producto : " + Producto[BuscarProductoCodigo(codigo)].Nombre +
											"\n Precio de Producto : " + Producto[BuscarProductoCodigo(codigo)].Precio);

						Console.WriteLine("\n El Precio ha sido establecido exitósamente");
						
						Validador.VolverMenu();

					}
					else
					{
						VerProducto();
						Console.WriteLine("\n Como puede verificar no se hizo ningún cambio");
						Validador.VolverMenu();

					}

				}
			} while ((BuscarProductoCodigo(codigo) == -1));

		}


		public void RegistrarVenta()
		{

			string codigo;
			int precio;
			int cantidad;
			int productosDiferentes;
			
			Console.Clear();

			productosDiferentes = 5000;
			/* venta es un objeto temporal de la clase Venta  y una vez que lo tengo lo agrego a mi lista 
			   de objetos de la clase Venta con el metodo AddVenta */
			Venta venta = new Venta();
			for (int i = 0; i < productosDiferentes; i++)
			{
				VerProducto();
				
				codigo = ValidarStringNoVacioProducto("\n Ingrese el código del producto a vender" +
													  "\n Si ingresa un código erróneo se tomará como vacío" +
													  "\n Ingrese *0* si desea dejar de seguir cargando productos.");
				if (codigo == "0")
                {
					RealizarCierre();
					break;
                }
				if (!(BuscarProductoCodigo(codigo) == -1))
                {
					int pos = BuscarProductoCodigo(codigo);
					/* Si no encuentra el codigo mandar posicion -1 y volver a pedirlo */
					while (pos == -1)
					{
						Console.WriteLine("El código *" + codigo + "* no existe.");
						Console.WriteLine("Intente con uno Existente en la Lista de Productos");
						VerProducto();
						codigo = ValidarStringNoVacioProducto("Ingrese el código del producto a vender");
						pos = BuscarProductoCodigo(codigo);
					}
					precio = Producto[pos].Precio; /* Precio */
					Console.Write("Cantidad: ");
					cantidad = Validador.PedirInt("\n Ingrese la cantidad "); ; /* Cantidad */
					/* Por cada venta que realice disminuira el stock y si no tengo stock invalidara continuar la venta */
					while (Producto[pos].Cantidad < cantidad)
					{
						Console.WriteLine("Error. No hay productos suficientes. Contamos con " + Producto[pos].Cantidad.ToString() + " unidades.");
						Console.Write("Cantidad: ");
						/* Valido que el cliente no se pueda llevar mas de 37 unidades del mismo producto */
						cantidad = Validador.PedirInt("Escriba *0* para continuar");
					}
					Producto[pos].Cantidad = Producto[pos].Cantidad - cantidad;
					Item item = new Item(codigo, precio, cantidad);
					venta.AddItem(item);

				}
				
			
			}
			Console.WriteLine("\n Presione Cualquier Tecla para ver la lista Actualizada");
			Console.ReadLine();
			venta.CalcularTotal();

			AddVenta(venta);
			RealizarCierre();

		}

		public void RealizarCierre()
		{
			/* Mostrar resumen de las ventas registradas en el sistema */
			Console.Clear();
			Console.WriteLine("\n Total de Cargas del Día");
			Console.WriteLine("\n #\tSubTot.\tTotal.\t");
			for (int i = 0; i < Venta.Count; i++)
			{
				Console.Write("\n " + (i + 1));
				Console.Write("\t");
				Console.Write(Venta[i].SubTotal);
				Console.Write("\t");
				Console.Write(Venta[i].Total);
				Console.Write("\n");
			}

			Decimal total_cobrado = 0;
			int cantidad_productos = 0;
			
			decimal total_descuentos = 0;
			/* los productos vendidos estan en la lista de Ventas así que recorremos esa lista */
			foreach (Venta venta in Venta)
			{
				/*  */
				total_cobrado = total_cobrado + venta.Total;
			}
			/* cantidad de productos vendidos */
			foreach (Venta venta in Venta)
			{
				foreach (Item item in venta.Item)
				{
					cantidad_productos = cantidad_productos + item.CantidadItem;
				}

			}
			
			Console.WriteLine("\n Monto Total de Acuerdo a los Ingresos Anteriores: *" + total_cobrado.ToString() + "*.");
			Console.WriteLine("\n Cantidad de productos en la Lista: *" + cantidad_productos.ToString() + "*.");
			Validador.Continuar();
		}


		protected override void CrearProducto()
		{


			string codigo;
			string nombre;
			int precio;
			string opcion;

			
				VerProducto();
				
				codigo = ValidarStringNoVacioProducto("\n Ingrese el Código del Producto a agregar ");
				
				/* Mientras que a buscarProducto pasandole el código como parámetro retorne -1 indicar */
				
				if (BuscarProductoCodigo(codigo) == -1)
				{

					VerProducto();
					Console.WriteLine("\n ¡En hora buena! Puede utilizar este Código para crear un Producto Nuevo");
					nombre = ValidarStringNoVacioProducto("\n Ingrese el nombre del Producto a Crear");

					precio = Validador.PedirInt("Ingrese el Precio");

					VerProducto();
					Console.WriteLine("\n Código de Producto a Crear: " + codigo +
										"\n Nombre de ¨Producto Crear: " + nombre +
										"\n Precio de ¨Producto Crear: " + precio);

					opcion = ValidarSioNoProducto("\n Está seguro que desea crear este Producto? ", codigo);
					if (opcion == "SI")
					{
						/* Como la clase Alumno esta en el namespace podemos usarlo y creo el objeto con el constructor */
						Producto p = new Producto(codigo, nombre, precio);
						/* Agrego el objeto a la lista */
						AddProducto(p);
						VerProducto();
						Console.WriteLine("\n Producto *" + nombre + "* con Código *" + codigo + "* agregado exitósamente");
						Validador.VolverMenu();
					}
					else
					{
						VerProducto();
						Console.WriteLine("\n Como puede verificar no se creo ningún Producto");
						Validador.VolverMenu();

					}

				}
				else
				{
					VerProducto();
					Console.WriteLine("\n Usted digitó el Código *" + codigo + "*");
					Console.WriteLine("\n Ya existe un Producto con ese Código");
					Console.WriteLine("\n Será direccionado nuevamente al Menú para que lo realice correctamente");
					Validador.VolverMenu();
				}
			

		}

		public void AddProducto(Producto producto)
		{
			this._producto.Add(producto);
		}

		protected string ValidarStringNoVacioProducto(string mensaje)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Recuerde que no puede ingresar un Código de Producto existente" +
									  "\n Por favor ingrese el valor solicitado y que no sea vacio.";


			do
			{
				VerProducto();
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeValidador);

				opcion = Console.ReadLine().ToUpper();

				if (opcion == "")
				{

					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}

		protected string ValidarSioNoProducto(string mensaje, string codigo)
		{

			string opcion;
			bool valido = false;
			string mensajeValidador = "\n Si esta seguro de ello escriba *" + "si" + "* sin los asteriscos" +
									  "\n De lo contrario escriba " + "*" + "no" + "* sin los asteriscos";
			string mensajeError = "\n Por favor ingrese el valor solicitado y que no sea vacio. ";

			do
			{
				VerProducto();
				if (BuscarProductoCodigo(codigo) != -1)
				{
					Console.WriteLine("\n Código de Producto : " + Producto[BuscarProductoCodigo(codigo)].Codigo +
									  "\n Nombre de Producto : " + Producto[BuscarProductoCodigo(codigo)].Nombre);
				}
				Console.WriteLine(mensaje);
				Console.WriteLine(mensajeError);
				Console.WriteLine(mensajeValidador);
				opcion = Console.ReadLine().ToUpper();
				string opcionC = "SI";
				string opcionD = "NO";

				if (opcion == "" || (opcion != opcionC) & (opcion != opcionD))
				{
					Console.WriteLine("\n");

				}
				else
				{
					valido = true;
				}

			} while (!valido);

			return opcion;
		}


		public int BuscarProductoCodigo(string codigo)
		{
			for (int i = 0; i < this._producto.Count; i++)
			{
				if (this._producto[i].Codigo == codigo)
				{
					return i;
				}
			}
			/* si no encuentro el alumno retorno una posición invalida */
			return -1;
		}

		public void VerProducto()
		{
			Console.Clear();
			Console.WriteLine("\n Número de Producto(s)");
			Console.WriteLine(" #\tCódigo\tNombre\tPrecio");
			for (int i = 0; i < Producto.Count; i++)
			{
				Console.Write(" " + (i + 1));
				Console.Write("\t");
				Console.Write(Producto[i].Codigo);
				Console.Write("\t");
				Console.Write(Producto[i].Nombre);
				Console.Write("\t");
				Console.Write(Producto[i].Precio);
				Console.Write("\n");

			}

		}

	}
}