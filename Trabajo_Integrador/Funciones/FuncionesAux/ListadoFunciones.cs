using System.Collections;
using Clases.Deportes;
using Clases.Categorias;
using Clases.Ninios;
using Clases.Clubes;

namespace Funciones.ListadoFunc
{
    public static class ListadoFuncExtensions
    {
        public static void ListadoInscriptos(ref Club clubUsuario)
		{
			string opc, opcDeporte, opcCategoria;
            int cantxcat= 0, cantxdeportetotal= 0;
            ArrayList ninios = clubUsuario.NINIOS;
            int total = ninios.Count;
            bool estaDeporte = false;
            bool estaCategoria = false;
            
            //creo las variables y el total ya lo calculo porque lo voy a imprimir de todas formas
            Console.WriteLine("Ingrese 'total' si quiere ver solo la cantidad total de inscriptos o 'deporte' si quiere de algun deporte en especifico");
            opc=Console.ReadLine(); //le pido al usuario lo que quiere ver
            if (opc == "deporte"){
                Console.WriteLine("eliga el deporte del que desea ver los inscriptos");
                opcDeporte= Console.ReadLine();
                foreach (Deporte deporte in clubUsuario.DEPORTES) {
                    if (opcDeporte == deporte.NOMBRE) { //verifico que el deporte este registrado en el club
                		estaDeporte = true;
                		
                        Console.WriteLine("Eliga la categoria que desea revisar");
                        opcCategoria= Console.ReadLine();
                        
                        foreach(Categoria cat in clubUsuario.CATEGORIAS) {
                            
                        	if (opcCategoria == cat.NOMBRE) { //lo mismo con la categoria verifico si esta registrado en el deporte
                                cantxcat += cat.CANTIDADINSCRIPTOS; //calculo la cantidad de inscriptos es esa categoria sola
                                estaCategoria = true;
                            }
                        }
                    foreach (Categoria ele in clubUsuario.CATEGORIAS){
                            bool valor= deporte.IDCATEGORIAS.Contains(ele.ID);//verifico si la id de la categoria se encuentra en el deporte
                            if (valor == true){ //si es verdadero, hago el calculo
                                cantxdeportetotal= cantxdeportetotal + ele.CANTIDADINSCRIPTOS; //calculo la cantidad de inscriptos por cada categoria del deporte para saber el total inscriptos en el deporte
                            }
                    }
                 
                    }
                }
                if (!estaDeporte) {
                	Console.WriteLine("La cantidad de inscriptos en total en el deporte elegido son: " + cantxdeportetotal);
                	if (!estaCategoria) {
                		Console.WriteLine("La cantidad de inscriptos segun el deporte y la categoria elegida son: " + cantxcat);
                	}else{
                		Console.WriteLine("La categoria ingresada no se encontro. Lo siento.");
                	}
                
                }else{
                	Console.WriteLine("El deporte ingresado no se encunetra en le club. Lo siento.");
                }
            }
        if (opc == "total") Console.WriteLine("La cantidad de inscriptos en total son: " + total);
        }
		
		public static void ListadoDeudores(Club clubUsuario)
		{
			DateTime mesActual = DateTime.Now;
			bool hayDeudores = false;

			Console.WriteLine("Listado de Deudores:");
    
			foreach (Ninio ninio in clubUsuario.NINIOS)
			{
				// Comparamos solo el mes y el año, sin importar el día
				if (ninio.ULT_MES_PAGO.Year < mesActual.Year ||
				    (ninio.ULT_MES_PAGO.Year == mesActual.Year && ninio.ULT_MES_PAGO.Month < mesActual.Month))
				{
					Console.WriteLine("Nombre: {0} {1}, DNI: {2}, Último mes pago: {3}",
					                  ninio.NOMBRE, ninio.APELLIDO, ninio.DNI, ninio.ULT_MES_PAGO.ToString("MM/yyyy"));
					hayDeudores = true;
				}
			}
			if (!hayDeudores)
			{
				Console.WriteLine("No hay deudores.");
			}
		}
    }
}