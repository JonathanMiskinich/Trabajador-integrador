using System.Collections;
using Clases.Deportes;
using Clases.Categorias;
using Clases.Clubes;
using Clases.Personas;

namespace Funciones.DeporteFunc
{
    public static class DeporteFuncExtensions
    {
        public static Club AgregarDeport(ref Club ClubUsuario)
		{
			string nombreDeporte;
			bool flag = false;
			
			Console.Write("Ingrese el nombre de nuevo deporte: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte deporte in ClubUsuario.DEPORTES) {
				if (deporte.NOMBRE == nombreDeporte) {
					flag = true;
					Console.WriteLine("El nombre del deporte ya existe.");
				}
			}
			if (flag == false) {
				Deporte deporteNuevo = new Deporte(nombreDeporte);
				Console.WriteLine("Quieres agregarle categorias (s/n): ");
				string opcion = Console.ReadLine();
				
				while (opcion == "s") {
					string nombreCategoria, dia, horario,nombreEntrenador, apellidoEntrenador;
					int cupo, cantidadInscriptos, dni;
					double costo, descuento;
					
					Console.Write("Ingrese nombre de la categoria: ");
					nombreCategoria = Console.ReadLine();
					
					Console.Write("Ingrese dia de entrenamiento de la categoria: ");
					dia = Console.ReadLine();
					
					Console.Write("Ingrese horario de los entrenamientos (xx a xx): ");
					horario = Console.ReadLine();
					
					Console.Write("Ingrese el cupo: ");
					cupo = int.Parse(Console.ReadLine());
					
					cantidadInscriptos = 0;
					
					Console.Write("Ingrese el costo de la cuota: ");
					costo = double.Parse(Console.ReadLine());
					
					Console.Write("Ingrese el descuento de la categoria: ");
					descuento = double.Parse(Console.ReadLine());
					while (true) {
						if (descuento >= 0) break; 
						else {
							Console.WriteLine("Por favor ingrese un numero positivo.");
							descuento = double.Parse(Console.ReadLine());
						}
					}
					
					Console.WriteLine("Ingrese los datos del entrenador");
					Console.Write("Ingrese el nombre del entrenador: ");
					nombreEntrenador = Console.ReadLine();
					
					Console.Write("Ingrese el apellido del entrenador: ");
					apellidoEntrenador = Console.ReadLine();
					
					Console.Write("Ingrese el DNI del entrenador, sin puntos ni espacios: ");
					dni = int.Parse(Console.ReadLine());
					
					Persona EntrenadorCategoria = new Persona(nombreEntrenador, apellidoEntrenador, dni);
					Categoria categoriaNueva = new Categoria(nombreCategoria,cupo, cantidadInscriptos, costo, descuento, dia, horario, EntrenadorCategoria);
					
					ClubUsuario.AgregarCategoria(categoriaNueva);
					deporteNuevo.AgregarCategoria(categoriaNueva.ID);
					
					Console.WriteLine("Quieres agregarle categorias (s/n): ");
					opcion = Console.ReadLine();
				}
				ClubUsuario.AgregarDeporte(deporteNuevo);
			}
			return ClubUsuario;
		}
		
		public static void EliminarDeporte(ref Club clubUsuario)
		{
			string nombreDeporte;
			Deporte deporteEliminar = new Deporte();
			bool flag = false;
			
			Console.Write("Ingrese el nombre del deporte que quiere eliminar: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte element in clubUsuario.DEPORTES) {
				if (element.NOMBRE == nombreDeporte) {
					deporteEliminar = element;
					foreach (int id in element.IDCATEGORIAS) {
						
						foreach (Categoria catDeporte in clubUsuario.CATEGORIAS) {
							
							if (id == catDeporte.ID) {
								
								if (catDeporte.CANTIDADINSCRIPTOS > 0) {
									flag = true;
									break;
								}
								break;
							}
						}
					}
				}
			}
			if (flag == false) {
				if (deporteEliminar.NOMBRE != null){
					clubUsuario.EliminarDeporte(deporteEliminar);
					Console.WriteLine("El deporte fue eliminado con exito del club.");
				}
				else
					Console.WriteLine("El deporte no se encuentra en la lista.");
			}
			else
				Console.WriteLine("El deporte tiene inscriptos. Debe de no tener inscriptos si quiere eliminarlo.");
			
		}
    }
}