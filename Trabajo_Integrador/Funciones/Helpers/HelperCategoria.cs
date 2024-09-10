using Funciones.Helpers.PedirDato;
using Clases.Categorias;
using Funciones.Helpers.Personas;
using Clases.Personas;

namespace Funciones.Helpers.Categorias
{
    public class HelperCategoria
    {
        public static Categoria CrearCategoria()
        {
            Console.WriteLine("Ingrese Datos de la categoria ---");

            string nombre = PedirDatoString.PedirNombre();
            int cupo = PedirDatoEntero.PedirCupo();
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

            string dia = PedirDatoString.PedirDia();
            string horario = PedirDatoString.PedirHorario();

            Persona entrenador = HelperPersona.CrearEntrenador();

            return new Categoria(nombre,cupo, costoCuota, descuento, dia, horario, entrenador);
        }
    }
}