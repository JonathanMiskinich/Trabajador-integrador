using Clases.Clubes;
using Clases.Deportes;
using Clases.Categorias;
using Funciones.Helpers.PedirDato;
using Funciones.Helpers.Deportes;
using Funciones.Helpers.Categorias;

namespace Funciones.Services.Deportes
{
    public class ServicesDeporte
    {
        public static void AgregarDeporte(ref Club clubUser)
        {
            Console.WriteLine("Ingrese los datos del deporte.\n");
            string nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");

            while (true)
            {
                if (HelperDeporte.ExisteDeporte(clubUser, nombreDeporte))
                {
                    Console.WriteLine("Ese nombre ya existe.\nIngresa otro: ");
                    nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");
                }
                else {break;}
            }
            Deporte deporteNuevo = new(nombreDeporte);

            Console.WriteLine("Quieres agregarle categorias (s/n): ");
		    string opcion = Console.ReadLine();

            while (opcion.ToLower() == "s")
            {
                Categoria cat = HelperCategoria.CrearCategoria();
                if (deporteNuevo.CantidadCategorias() != 0)
                {
                    if (HelperCategoria.ExisteCategoria(clubUser, deporteNuevo, cat))
                    {
                        Console.WriteLine("La categoria ya existe. Ingresa otra.");
                        cat = HelperCategoria.CrearCategoria();
                    }else
                    {
                        clubUser.AgregarCategoria(cat);
                        deporteNuevo.AgregarCategoria(cat.ID);
                    }
                }

                Console.WriteLine("Quieres agregarle categorias (s/n): ");
		        opcion = Console.ReadLine();
            }
        }

        public static bool EliminarDeporte(ref Club clubUser)
        {
            Console.WriteLine("Ingrse los datos del deporte a eliminar----");
            string nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");

            Deporte deporteEliminar = HelperDeporte.EncontrarDeporte(clubUser, nombreDeporte);

            if (deporteEliminar != null)
            {
                if (!HelperDeporte.DeporteTieneInscriptos(clubUser, deporteEliminar))
                {
                    clubUser.EliminarDeporte(deporteEliminar);
                    return true;
                }
            }
            return false;
        }
    }
}