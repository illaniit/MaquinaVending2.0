using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending2._0 {
	internal class MaterialesPreciosos :Productos {
		//Declaramos las variables de materialprecioso
		public string TipoMaterial {  get; set; }
		public double Peso {  get; set; }
		//Declaramos el constructor parametrizado y vacío, el parametrizado hereda las características de la clase Productos
		public MaterialesPreciosos() { }
		public MaterialesPreciosos(string nombre, int unidades, double preciounitario, string descripcion,string tipomaterial, double peso, int id) : base(nombre,unidades,preciounitario,descripcion,id) {
			TipoMaterial = tipomaterial;
			
		}
		public override string MostrarDetalles() {
			return (base.MostrarDetalles() + $"Tipo de material {TipoMaterial}. Peso {Peso}");

		}
		public override void PedirDatos() {
			base.PedirDatos();
			Console.WriteLine("Introduce el tipo de material utilizado: ");
			TipoMaterial = Console.ReadLine();
			Console.WriteLine("Introduce el peso: ");
			Peso = double.Parse(Console.ReadLine());
		}
	}
	
}
