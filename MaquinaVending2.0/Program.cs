using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending2._0 {
	internal class Program {
		public static List<Productos> ListaProductos = new List<Productos>();

		static void Main(string[] args) {

			Cliente cliente = new Cliente(ListaProductos);
			cliente.CargaCompletaProducto();
			cliente.Menu();

		}

	}
}
