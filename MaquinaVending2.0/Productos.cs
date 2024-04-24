using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending2._0 {
	internal class Productos {
		//Declaramos las variables comunes que van a tener todos los productos
		public string Nombre { get; set; }
		public int Unidades { get; set; }
		public double PrecioUnitario { get; set; }
		public string Descripcion { get; set; }
		public int Id { get; set; }
		//Vamos a crear la lista de productos.

		//declaramos el constructor vacío y el parametrizado


		public Productos() { }
		public Productos(string nombre, int unidades, double preciounitario, string descripcion, int id) {
			Nombre = nombre;
			Unidades = unidades;
			PrecioUnitario = preciounitario;
			Descripcion = descripcion;
			Id = id;


		}
		//Vamos a crear el método para que el usuario pueda ver las características comúnes de todos los productos.
		public virtual string MostrarDetalles() {
			Console.WriteLine($"ID:{Id}|Nombre del producto:{Nombre}|Unidades disponibles:{Unidades}|Precio del producto: {PrecioUnitario}"	);
			return $"ID:{Id}|Nombre del producto:{Nombre}|Unidades disponibles:{Unidades}|Precio del producto: {PrecioUnitario}";


		}

		public virtual void PedirDatos() {
			//Cambiar por atributos de la clase original
			Console.WriteLine("¿Que nombre quieres poner al producto?");
			Nombre = Console.ReadLine();
			Console.WriteLine("Cuantas unidades quieres poner");
			Unidades = int.Parse(Console.ReadLine());
			Console.WriteLine("¿Cual es el precio por unidad?");
			PrecioUnitario = double.Parse(Console.ReadLine());
			Console.WriteLine("Describe el producto");
			Descripcion = Console.ReadLine();
			Console.WriteLine("¿Escribe el ID del producto?");
			Id = int.Parse(Console.ReadLine());
		}

	}
}

