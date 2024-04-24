using MaquinaVending2._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinavending_23 {
	internal class ProductosAlimenticios : Productos {
		//Declaramos las variables de la clase ProductosAlimenticios
		public string InformacionNutricional { get; set; }
		//Declaramos el constructor vacío y el parametrizado, este hereda características de Productos.
		public ProductosAlimenticios() { }
		public ProductosAlimenticios(string nombre, int unidades, double preciounitario, string descripcion, string informacionutricional, int id)
			: base(nombre, unidades, preciounitario, descripcion, id) {
			InformacionNutricional = informacionutricional;
		}
		public override string MostrarDetalles() {
			return base.MostrarDetalles() + $"Información Nutricional:{InformacionNutricional}";

		}
		public override void PedirDatos() {
			base.PedirDatos();
			Console.WriteLine("Introduce la información nutricional: ");
			InformacionNutricional = Console.ReadLine();
		}
	}
}

