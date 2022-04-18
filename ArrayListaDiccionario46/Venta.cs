using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayListaDiccionario46
{
    public class Venta
    {
		private decimal _subTotal;
		private decimal _total;
		private List<Item> _item;

		public List<Item> Item
		{
			get { return this._item; }
			/* set { this._items = value; } No debería poder setearse todo el listado */
			/* Para eso está implementar el método: AddItem */
			
		}
		public decimal SubTotal
		{
			get { return this._subTotal; }
			set { this._subTotal = value; }
		}
		
		public decimal Total
		{
			get { return this._total; }
			set { this._total = value; }
		}

		public Venta()
		{
			this._item = new List<Item>();
		}

		/* Cuando agrego items a la venta con este metodo obtendria el subtotal */
		public void AddItem(Item item)
		{
			this._item.Add(item); /* Se agrega el item a la lista "items" */
			this._subTotal = this._subTotal + (item.CantidadItem * item.PrecioUnitario); /* Se re-calcula el "subTotal" */
		}
		
		public void CalcularTotal()
		{
			this._total = this._subTotal;  /* Se calcula el "total" */
		}
	}
}
