using System;
using System.Collections;
using Funciones.MenuFunc;
using Funciones.DeporteFunc;
using Funciones.ListadoFunc;
using Funciones.NinioFunc;
using Funciones.EntrenadorFunc;
using Clases.Clubes;
using Clases.Deportes;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			Club clubUser = new Club();
			int opcion;
			
			Console.WriteLine("Bienvenido al Menú de Opciones: ");
			Console.WriteLine("---------------------------------");
			MenuFuncExtensions.Menu();
			
			opcion = int.Parse(Console.ReadLine());
			
			while (opcion != 0) 
			{
				if (opcion < 0) {
					Console.Write("Por favor elija una de las opciones antes mostradas: ");
					opcion = int.Parse(Console.ReadLine());
				}else
				{
					if (opcion ==  1) {
						Console.WriteLine("---------------------------------");
						DeporteFuncExtensions.AgregarDeport(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 2) {
						Console.WriteLine("---------------------------------");
						DeporteFuncExtensions.EliminarDeporte(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 3) {
						Console.WriteLine("---------------------------------");
						EntrenadorFuncExtensions.AltaEntrenador(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 4) {
						Console.WriteLine("---------------------------------");
						EntrenadorFuncExtensions.BajaEntrenador(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 5) {
						Console.WriteLine("---------------------------------");
						NinioFuncExtensions.AltaNinio(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 6) {
						Console.WriteLine("---------------------------------");
						NinioFuncExtensions.EliminarNinio(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 7) {
						Console.WriteLine("---------------------------------");
						ListadoFuncExtensions.ListadoInscriptos(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 8) {
						Console.WriteLine("---------------------------------");
						ListadoFuncExtensions.ListadoDeudores(clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 9) {
						Console.WriteLine("---------------------------------");
						NinioFuncExtensions.PagoCuota(ref clubUser);
						Console.WriteLine("---------------------------------");
					}

					foreach (Deporte element in clubUser.DEPORTES) 
					{
						Console.WriteLine(element.NOMBRE);
					}
					MenuFuncExtensions.Menu();
						
					opcion = int.Parse(Console.ReadLine());
				}
			}
		}
	}	
}
