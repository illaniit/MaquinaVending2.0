using Maquinavending_23;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending2._0 {
	internal class Cliente {
		public static List<Productos> ListaProductos;
		public static List<Productos> ListaCarritos;
		//Creamos una string constante para la contraseña del admin
		private const String ContraseñaAdmin = "7"; //Ponerla donde pongamos el menú del usuario.
		public Cliente(List<Productos> Listaproductos) {
			ListaProductos = Listaproductos;
		}

		//Vamos a crear el método que permite al cliente ver la información de los productos utilizando el método de la clase Productos que posee los caracterísiticas  comunes de todos los productos.

		public void MostrarInformacionProducto() {
			foreach (Productos pr in ListaProductos) pr.MostrarDetalles();

			Console.WriteLine("Introduce el ID para obtener mayor información");
			//Creamos el id temporal para comprobar si ese id corresponde al del producto q iteramos d la lista. 
			int idTemp = int.Parse(Console.ReadLine());
			//declaramos la variable del producto elegido por el usuario a null para poder luego mostar los detalles de ese producto
			Productos ProductoElegido = null;
			foreach (Productos produc in ListaProductos) {
				//Comprobación del id
				if (produc.Id == idTemp) {
					ProductoElegido = produc;

				}
				//Ahora vamos a comprobar si existe el producto elegido
			}
			if (ProductoElegido != null) {
				ProductoElegido.MostrarDetalles();
			}
			else {
				Console.WriteLine("No has elegido un producto válido");
			}





		}
		public void Menu() {
			int opcion = 0;
			do {
				Console.WriteLine("1. Comprar productos");
				Console.WriteLine("2. Mostrar información de productos");
				Console.WriteLine("3. Carga individual de productos");
				Console.WriteLine("4. Carga completa de productos");
				Console.WriteLine("5. Salir");
				Console.WriteLine("Seleccione una opción: ");

				try {
					opcion = int.Parse(Console.ReadLine());
					Console.Clear();
					switch (opcion) {
						case 1:
							AñadirCarrito();
							ComprarProductos();
							break;

						case 2:

							MostrarInformacionProducto();
							break;

						case 3:
							//Comprobación de admin
							if (ComprobacionAdmin() == true) {
								CargaIndividualProducto();
								break;
							}
							else
								break;

						case 4:
							//Comprobación de admin
							if (ComprobacionAdmin() == true) {
								CargaCompletaProducto();
								break;
							}
							else
								break;


						case 5:
							//Salir();
							break;

						default:
							Console.WriteLine("Opción no válida");
							break;

					}
				}
				catch (FormatException) {
					Console.WriteLine("Error: opción no es válida introduzca numero ");
				}
				catch (Exception ex) {
					Console.WriteLine("Error" + ex.Message);
				}

				Console.WriteLine("Presiona una tecla para continuar...");
				Console.ReadKey();

			} while (opcion != 5);
		}
		//Creamos el método para comprobar si la contraseña es correcta para que el admin pueda continuar
		public bool ComprobacionAdmin() {
			Console.WriteLine("Introduce la contraseña de administrador para continuar: ");
			string ContraseñaIntroducida = Console.ReadLine();
			if (ContraseñaIntroducida == ContraseñaAdmin) {
				Console.WriteLine("Contraseña correcta!");
				return true;
			}
			else {
				Console.WriteLine("Contraseña Incorrecta.");
				return false;
			}
		}

		public void AñadirCarrito() {

			double pagoTotal = 0;
			string respuesta = " ";
			do {
				foreach (Productos productos in ListaProductos) {
					Console.WriteLine(productos.MostrarDetalles());
					Console.WriteLine("Escribe el ID del producto que quieres comprar");
					int id_producto = int.Parse(Console.ReadLine());
					if (id_producto == productos.Id) {
						Console.WriteLine("¿Desea añadir algún producto más al carrito? (Si/No)");
						respuesta = Console.ReadLine();
						if (respuesta == "Si") {
							ListaCarritos.Add(productos);
						}
						else {
							Console.WriteLine("Prcederemos al pago");
						}
						pagoTotal += productos.PrecioUnitario;
						Console.WriteLine($"El precio total es {pagoTotal} euros");
					}
				}
			} while (respuesta != "No");

		}
		public void ComprarProductos() {
			int opcion = 0;
			do {

				Console.WriteLine("1. Tarjeta");
				Console.WriteLine("2. Efectivo");
				Console.WriteLine("3. Cancelar pago");
				Console.WriteLine("Introduzca opción de metodo de pago: ");
				try {
					opcion = int.Parse(Console.ReadLine());
					switch (opcion) {
						case 1:
							PagoTarjeta();
							break;

						case 2:
							PagoEfectivo();
							break;

						case 3:
							Console.WriteLine("Saliendo...");
							//Salir();
							break;

						default:
							Console.WriteLine("Opción no válida");
							break;
					}
				}
				catch (FormatException) {
					Console.WriteLine("Error: opción no es válida introduzca numero ");
				}
				catch (Exception ex) {
					Console.WriteLine("Error" + ex.Message);
				}

				Console.WriteLine("Presiona una tecla para continuar...");
				Console.ReadKey();
			} while (opcion != 3);
		}

		public void PagoTarjeta() {
			Console.Write("Datos de la tarjeta: ");
			Console.Write("Nombre ");
			string nombre = Console.ReadLine();
			Console.Write("Primer apellido: ");
			string ape1 = Console.ReadLine();
			Console.Write("Segundo apellido: ");
			string ape2 = Console.ReadLine();
			Console.Write("Numero (PAN): ");
			string numero = Console.ReadLine();
			Console.Write("CVV: ");
			string CVV = Console.ReadLine();
		}

		public void PagoEfectivo() {
			double pagoTotal = 0;
			double cambiototal = pagoTotal;
			foreach (Productos productos in ListaCarritos) {
				Console.WriteLine(productos.MostrarDetalles());
				pagoTotal += productos.PrecioUnitario;
			}
			Console.WriteLine("Inserte el dinero");
			int dineroPagado = int.Parse(Console.ReadLine());
			double dineroFaltante = 0;

			do {
				if (dineroPagado < pagoTotal) {
					cambiototal = dineroPagado - pagoTotal;
					do {
						double cambiorestante = cambiototal - 10;
					} while (dineroPagado < 10);

					do {
						double cambiorestante = cambiototal - 5;
					} while (dineroPagado < 5);

					do {
						double cambiorestante = cambiototal - 2;
					} while (dineroPagado < 2);

					do {
						double cambiorestante = cambiototal - 1;
					} while (dineroPagado < 1);

					do {
						double cambiorestante = cambiototal - 0.5;
					} while (dineroPagado < 0.5);

					do {
						double cambiorestante = cambiototal - 0.2;
					} while (dineroPagado < 0.2);

					do {
						double cambiorestante = cambiototal - 0.1;
					} while (dineroPagado < 0.1);

					do {
						double cambiorestante = cambiototal - 0.05;
					} while (dineroPagado < 0.05);

					do {
						double cambiorestante = cambiototal - 0.02;
					} while (dineroPagado < 0.02);

					do {
						double cambiorestante = cambiototal - 0.001;
					} while (dineroPagado < 0.001);

					dineroFaltante = pagoTotal - dineroPagado;

					Console.WriteLine($"Falta por pagar {dineroPagado}");
				}
				else {
					Console.WriteLine("Gracias por su compra");
				}

			} while (dineroPagado >= pagoTotal);

			do {
				Console.WriteLine("Falta dinero por pagar");
			} while (dineroPagado < pagoTotal);


		}

		public void CargaCompletaProducto() {
			//Ponemos la ruta del .csv
			string ruta = "Productos.csv";
			StreamReader lector = new StreamReader(ruta);
			string linea = "";
			while ((linea = lector.ReadLine()) != null) {
				string[] datos = linea.Split(',');
				if (datos.Length == 11) {
					int tipoProducto = int.Parse(datos[0]);
					string nombre = datos[1];
					int unidades = int.Parse(datos[2]);
					double precioUnitario = double.Parse(datos[3]);
					string descripcion = datos[4];
					string materiales = datos[5];
					double peso = double.Parse(datos[6]);
					string infoNutricional = datos[7];
					bool tieneBateria = datos[8] == "1";
					bool precargado = datos[9] == "1";
					string materialutilizado = datos[10];

					Productos nuevoProducto = null;
					switch (tipoProducto) {
						case 1:
							nuevoProducto = new MaterialesPreciosos(nombre, unidades, precioUnitario, descripcion, materiales, peso, ListaProductos.Count + 1);
							break;
						case 2:
							nuevoProducto = new ProductosAlimenticios(nombre, unidades, precioUnitario, descripcion, infoNutricional, ListaProductos.Count + 1);
							break;
						case 3:
							nuevoProducto = new ProductosElectronicos(nombre, unidades, precioUnitario, descripcion, ListaProductos.Count + 1, tieneBateria, precargado, materialutilizado);
							break;
					}

					if (nuevoProducto != null) {
						ListaProductos.Add(nuevoProducto);
					}
				}
			}

		}
		public void CargaIndividualProducto() {

			int opcion = 0;
			do {
				Console.WriteLine("1. Añadir existencias a algún producto existente");
				Console.WriteLine("2. Añadir nuevos tipos de productos");
				Console.WriteLine("3. Salir");
				Console.WriteLine("Introduzca opción: ");
				try {
					opcion = int.Parse(Console.ReadLine());
					switch (opcion) {
						case 1:
							AñadirExistencias();
							break;

						case 2://añadimos algun producto a lista productos
							   //crear producto debe de hacer return de un producto el cual asignes a p
							   // una vez asignado lo añades a la lista
							CrearProducto();
							break;

						case 3:
							Console.WriteLine("Saliendo...");
							//Salir();
							break;

						default:
							Console.WriteLine("Opción no válida");
							break;
					}
				}
				catch (FormatException) {
					Console.WriteLine("Error: opción no es válida introduzca numero ");
				}
				catch (Exception ex) {
					Console.WriteLine("Error" + ex.Message);
				}

				Console.WriteLine("Presiona una tecla para continuar...");
				Console.ReadKey();
			} while (opcion != 3);

		}

		public Productos BuscarProducto(int id) {
			Productos productoTemp = null;
			foreach (Productos p in ListaProductos) {
				if (p.Id == id) {
					productoTemp = p;
				}
			}
			return productoTemp;
		}

		public void CrearProducto() {



			int eleccion = 0;
			do {

				Console.WriteLine("1. Productos electrónicos");
				Console.WriteLine("2. Materiales preciosos");
				Console.WriteLine("3. Productos alimenticios");
				Console.WriteLine("4. Salir");
				Console.WriteLine("Elige tipo de producto que quieras crear:");
				try {
					eleccion = int.Parse(Console.ReadLine());
					switch (eleccion) {
						case 1:
							ProductosElectronicos productosElectronicos = new ProductosElectronicos();
							productosElectronicos.PedirDatos();
							ListaProductos.Add(productosElectronicos);
							break;

						case 2:

							MaterialesPreciosos materialesPreciosos = new MaterialesPreciosos();
							materialesPreciosos.PedirDatos();
							ListaProductos.Add(materialesPreciosos);
							break;

						case 3:
							ProductosAlimenticios productosAlimenticios = new ProductosAlimenticios();
							productosAlimenticios.PedirDatos();
							ListaProductos.Add(productosAlimenticios);
							break;

						case 4:
							//Salir();
							break;
						default:
							Console.WriteLine("Opción no válida");
							break;
					}
				}
				catch (FormatException) {
					Console.WriteLine("Error: opción no es válida introduzca numero ");
				}
				catch (Exception ex) {
					Console.WriteLine("Error" + ex.Message);
				}

				Console.WriteLine("Presiona una tecla para continuar...");
				Console.ReadKey();

			} while (eleccion != 4);

			
		}
		public void AñadirExistencias() {
			int Id_Introducido = 0; //Ponemos un id para que el usuario selecione el producto después del foreach
			string productocargado = "no"; 
			foreach(Productos p in ListaProductos) {
				p.MostrarDetalles();	
			}
			Console.WriteLine("Introduzca el ID del producto que va a añadir unidades");
			Id_Introducido = int.Parse(Console.ReadLine());
			foreach(Productos p in ListaProductos) {
				if(p.Id ==  Id_Introducido) {
					Console.WriteLine("Unidades a añadir: ");
					int Unidades_add = int.Parse(Console.ReadLine());
					p.Unidades = Unidades_add + p.Unidades;
					productocargado = "si";
				}
			if(productocargado == "Si") {
					Console.WriteLine("Producto Cargado correctamente");
				}
			else{
					Console.WriteLine("Error al encontrar el producto");
				}
			Console.ReadKey();
			}
		}
		/*public void Salir() {
			//Aqui guardamos el contenido de la lista en un fichero
			FileStream fs = new FileStream($"productos.csv", FileMode.OpenOrCreate, FileAccess.Write);
			StreamWriter streamWriter = new StreamWriter(fs);
			foreach (Productos p in ListaProductos) {

				if (p is ProductosAlimenticios) {
					streamWriter.Write(p.BuscarProducto());
				}
				else if (p is ProductosElectronicos) {
					streamWriter.Write(p.BuscarProducto());
				}
				else if (p is MaterialesPreciosos) {
					streamWriter.Write(p.BuscarProducto());
				}
			} 
			streamWriter.Close();
			Console.WriteLine("Saliendo del programa...");
			System.Threading.Thread.Sleep(700);
		} */
	}

}

