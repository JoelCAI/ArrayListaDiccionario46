using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
    public class Item
    {
		private string _codigoProducto;
		private int _precioUnitario;
		private int _cantidadItem;

		public string CodigoProducto
		{
			get { return this._codigoProducto; }
			set { this._codigoProducto = value; }
		}
		public int PrecioUnitario
		{
			get { return this._precioUnitario; }
			set { this._precioUnitario = value; }
		}
		public int CantidadItem
		{
			get { return this._cantidadItem; }
			set { this._cantidadItem = value; }
		}

		public Item(string codigoProducto, int precioUnitario, int cantidadItem)
		{
			this._codigoProducto = codigoProducto;
			this._precioUnitario = precioUnitario;
			this._cantidadItem = cantidadItem;
		}
	}
}
