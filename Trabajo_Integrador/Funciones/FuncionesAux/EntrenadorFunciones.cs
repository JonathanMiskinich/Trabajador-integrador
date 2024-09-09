using Clases.Clubes;
using Clases.Personas;
using Clases.Deportes;
using Clases.Categorias;

namespace Funciones.EntrenadorFunc
{
    public static class EntrenadorFuncExtensions
    {
        public static void AltaEntrenador(ref Club clubUsuario)
		{
			string nombre, apellido, nombreDeporte;
			int dni;
			bool flag = false;
			
			Console.Write("Ingrese el nombre del Entrenador: ");
			nombre = Console.ReadLine();
			
			Console.Write("Ingrese el apellido del Entrenador: ");
			apellido = Console.ReadLine();
			
			Console.Write("ingrese el DNI del entrenador: ");
			dni = int.Parse(Console.ReadLine());
			
		//Creo la instacia de persona para guardar los datos del nuevo entrenador
			Persona entrenador = new Persona(nombre, apellido, dni);
			
			Console.Write("Ingrese el nombre del deporte al que el entrenador va a pertener: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte element in clubUsuario.DEPORTES) 
			{
				if (element.NOMBRE == nombreDeporte) {
					flag = true;
					
					foreach (int id in element.IDCATEGORIAS) {
						
						foreach (Categoria cat in clubUsuario.CATEGORIAS) {
							
							if (cat.ID == id) {
								Console.WriteLine("La categoria a dar de alta al entrenador es: {0}? (s/n)", cat.NOMBRE);
								string opc = Console.ReadLine();
								
								if (opc == "s") {
									cat.ENTRENADOR = entrenador;
									Console.WriteLine("Entrenador dado de alta exitosamente.");
									break;
								}
								break;
							}
						}
					}
				}
			}
			if (flag == false)
				Console.WriteLine("No se encontro el nombre del deporte.");
		}

        public static void BajaEntrenador(ref Club clubUsuario)
		{
			Console.WriteLine("Ingrese el dni del entrenador a dar de baja: ");
			int dni = int.Parse(Console.ReadLine());
			bool entrenadorEncontrado = false;
			Persona entrenador;
			
			foreach (Categoria categoria in clubUsuario.CATEGORIAS)
			{
				entrenador = (Persona)categoria.ENTRENADOR;
				if(entrenador != null && entrenador.DNI == dni){
					categoria.ENTRENADOR = null; //Acá asignamos null al atributo entrenador.
					entrenadorEncontrado = true;
					Console.WriteLine("Entrnador con DNI {0} eliminado de la categoría {1}.", dni, categoria.NOMBRE);
				}
			}
			
			if(!entrenadorEncontrado){
				Console.WriteLine("No se encontró al entrenador con el dni ingresado");
			}
		}
    }
}