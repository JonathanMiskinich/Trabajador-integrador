using Funciones.Helpers.PedirDato;
using Clases.Categorias;
using Funciones.Helpers.Personas;
using Clases.Personas;
using Clases.Clubes;
using Clases.Deportes;

namespace Funciones.Helpers.Categorias
{
    public class HelperCategoria
    {
        public static Categoria CrearCategoria()
        {
            Console.WriteLine("Ingrese Datos de la categoria ---");

            string nombre = PedirDatoString.PedirString("nombre", "categoria");
            int cupo = PedirDatoEntero.PedirEnteroPosit("cupo");
            
            double costoCuota = PedirDatoDouble.PedirCuota();
            while (true)
            {
                if (costoCuota == -1)
                {
                    Console.WriteLine("La cuota no puede ser negativa.\nVuelva a ingresar el valor: $");
                    costoCuota = PedirDatoDouble.PedirCuota();
                }else {break;}
            }

            double descuento = PedirDatoDouble.PedirDescuento();
            while (true)
            {
                if (descuento == -1)
                {
                    Console.WriteLine("El descuento no puede ser negativa.\nVuelva a ingresar el valor: ");
                    descuento = PedirDatoDouble.PedirDescuento();
                }else {break;}
            }

            string dia = PedirDatoString.PedirString("dia", "horario");
            string horario = PedirDatoString.PedirString("horario", "categoria");

            Persona entrenador = HelperPersona.CrearEntrenador();

            return new Categoria(nombre,cupo, costoCuota, descuento, dia, horario, entrenador);
        }

        public static bool ExisteCategoria(Club club, Deporte deporte, Categoria categoria)
        {
            List<int> listaIdCategorias = deporte.IDCATEGORIAS;

            foreach (Categoria item in club.CATEGORIAS)
            {
                if (listaIdCategorias.Contains(item.ID))
                {
                    if (item.Equals(categoria))
                        return true;
                }
            }
            return false;
        }
    }
}