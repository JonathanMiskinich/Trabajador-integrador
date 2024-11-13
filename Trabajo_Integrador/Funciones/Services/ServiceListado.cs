using Clases.Categorias;
using Clases.Clubes;
using Clases.Deportes;
using Clases.Ninios;
using Funciones.Helpers.Deportes;

namespace Funciones.Services.Listados
{
    public class ListadosService
    {
        public static void ListadoInscriptos(ref Club clubUsuario)
        {
            Console.Write("Ingrese total o nombre del deporte para saber cantidad de inscriptos: ");
            string opcion = Console.ReadLine();

            if (opcion.ToLower() == "total")
                Console.WriteLine("La cantidad total de inscriptos es de: " + clubUsuario.CantNinios());
            else
            {
                if(HelperDeporte.ExisteDeporte(clubUsuario, opcion))
                {
                    Deporte deporteSeleccionado = HelperDeporte.EncontrarDeporte(clubUsuario, opcion);
                    int total = 0;
                    foreach(Categoria cat in clubUsuario.CATEGORIAS)
                    {
                        if (deporteSeleccionado.CategoriaExiste(cat.ID))
                        {
                            total += cat.CANTIDADINSCRIPTOS;
                            Console.WriteLine($"La cantidad de inscriptos en la categoria {0} es de {1}", cat.NOMBRE, cat.CANTIDADINSCRIPTOS);
                        }
                    }
                    Console.WriteLine($"La cantidad de inscriptos en el deporte {0} es de {1}", opcion, total);
                }else
                    Console.WriteLine("El deporte no se encontró.");
            }
        }
        public static void ListadoDeudores(Club clubUsuario)
        {
            DateTime mesActual = DateTime.Now;
			bool hayDeudores = false;

			Console.WriteLine("Listado de Deudores:");

            foreach (Ninio ninio in clubUsuario.NINIOS)
            {
                if (ninio.ULT_MES_PAGO.Year < mesActual.Year || (ninio.ULT_MES_PAGO.Year == mesActual.Year && ninio.ULT_MES_PAGO.Month < mesActual.Month))
                {
                    Console.WriteLine("Nombre: {0} {1}, DNI: {2}, Último mes pago: {3}",ninio.NOMBRE, ninio.APELLIDO, ninio.GetDni, ninio.ULT_MES_PAGO.ToString("MM/yyyy"));
                    hayDeudores = true;
                }
            }

            if (!hayDeudores)
                Console.WriteLine("No hay deudores.");
        } 
    }
}