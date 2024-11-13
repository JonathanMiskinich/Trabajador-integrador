using Clases.Personas;
using Funciones.Helpers.PedirDato;

namespace Funciones.Helpers.Personas
{
    public class HelperPersona
    {
        public static Persona CrearEntrenador()
        {
            Console.WriteLine("Ingrese los datos del entrenador ---");

            string nombre = PedirDatoString.PedirString("nombre", "entrenador");
            string apellido = PedirDatoString.PedirString("apellido", "entrenador");
            int dni = PedirDatoEntero.PedirEnteroPosit("DNI");

            while (true)
            {
                if (dni == -1)
                {
                    Console.WriteLine("El DNI debe de ser positivo.\nIngreselo de nuevo: ");
                    dni = PedirDatoEntero.PedirEnteroPosit("DNI");
                }else {break;}
            }

            return new Persona(nombre,apellido, dni);
        }
    }
}