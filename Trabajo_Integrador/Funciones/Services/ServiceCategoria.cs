using Clases.Categorias;
using Clases.Clubes;
using Clases.Deportes;
using Funciones.Helpers.Categorias;
using Funciones.Helpers.Deportes;
using Funciones.Helpers.PedirDato;

namespace Funciones.Services.Categorias
{
    public class CategoriasService
    {
        public static void AgregarCategoria(ref Club clubUsuario)
        {
            string nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");
            while (nombreDeporte.ToLower() != "f")
            {
                if (HelperDeporte.ExisteDeporte(clubUsuario, nombreDeporte))
                {
                    Categoria categoriaNueva = HelperCategoria.CrearCategoria();
                    Deporte deporteSeleccionado = HelperDeporte.EncontrarDeporte(clubUsuario, nombreDeporte);
                    
                    deporteSeleccionado.AgregarCategoria(categoriaNueva.ID);
                    clubUsuario.AgregarCategoria(categoriaNueva);
                    return;
                }
                else
                {
                    Console.WriteLine("EL deporte no existe.\nIngrese otro nombre o f para salir. ");
                    nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");
                }
            }
        }

        public static void EliminarCategoria(ref Club clubUsuario)
        {
            string nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");
            while (nombreDeporte.ToLower() != "f")
            {
                if (HelperDeporte.ExisteDeporte(clubUsuario, nombreDeporte))
                {
                    Deporte deporteSeleccionado = HelperDeporte.EncontrarDeporte(clubUsuario, nombreDeporte);
                    foreach (Categoria cat in clubUsuario.CATEGORIAS)
                    {
                        if (deporteSeleccionado.IDCATEGORIAS.Contains(cat.ID))
                        {
                            Console.WriteLine($"La categoria a eliminar es {0}? (s/n)", cat.NOMBRE);
                            string opcion = Console.ReadLine();

                            if (opcion == "s")
                            {
                                deporteSeleccionado.EliminarCategoria(cat.ID);
                                clubUsuario.EliminarCategoria(cat);
                                return;
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("EL deporte no existe.\nIngrese otro nombre o f para salir. ");
                    nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");
                }
            }
        }
    }
}