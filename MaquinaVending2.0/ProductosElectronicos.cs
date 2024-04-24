using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending2._0 {
	internal class ProductosElectronicos : Productos {
		//Declaramos las características de los productos electrónicos mediante el uso de booleanos (true/false)
		public bool InclusionPilas { get; set; }
		public bool Precargado { get; set; }
		public string MaterialUtilizado { get; set; }
		//Declaramos el Constructor vacío y el parametrizado que hereda de la clase productos. 
		public ProductosElectronicos() { }
		public ProductosElectronicos(string nombre, int unidades, double preciounitario, string descripcion, int id, bool inclusionpilas, bool precargado, string materialutilizado)
			: base(nombre, unidades, preciounitario, descripcion, id) {
			InclusionPilas = inclusionpilas;
			Precargado = precargado;
			MaterialUtilizado = materialutilizado;
		}
		public override string MostrarDetalles() {
			Console.WriteLine(base.MostrarDetalles());
			return $"Tiene pilas?:{InclusionPilas} | Está precargado?:{Precargado} Material utilizado:{MaterialUtilizado}";
		}

		public override void PedirDatos() {
			base.PedirDatos();
			Console.WriteLine("Tiene pilas? (Si tiene introduce si sino no)");
			string Eleccion = Console.ReadLine();
			if ( Eleccion == "no" ) {
				InclusionPilas = false;
			}
			else {
				InclusionPilas = true;
			}
			Console.WriteLine("Está precargado? (si/no)");
			string Opcion_Precargado = Console.ReadLine();
			if(Opcion_Precargado == "no") {
				Precargado = false;
			}
			else {
				Precargado = true;
			}
			Console.WriteLine("Introduce el material utilizado: ");
			MaterialUtilizado = Console.ReadLine();
			//preguntar por lo demas
		}
	}
}
