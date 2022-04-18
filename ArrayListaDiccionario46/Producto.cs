using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
	public class Producto
	{
		private string _codigo;
		private string _nombre;
		private int _precio;
		private int _cantidad;

		public string Codigo
		{
			get { return this._codigo; }
			set { this._codigo = value; }
		}
		public string Nombre
		{
			get { return this._nombre; }
			set { this._nombre = value; }
		}
		public int Precio
		{
			get { return this._precio; }
			set { this._precio = value; }
		}

		public int Cantidad
		{
			get { return this._cantidad; }
			set { this._cantidad = value; }
		}

		public Producto(string registro, string nombre, int precio)
		{
			this._codigo = registro;
			this._nombre = nombre;
			this._cantidad = 5000000;
			this._precio = precio;
		}


	}



}