using Clases.Ninios;
using Funciones.Helpers.PedirDato;

namespace  Funciones.Helpers.Ninios
{
    public class NiniosHelper
    {
        public static Ninio CrearNinio()
        {
            string nombre = PedirDatoString.PedirString("nombre", "ninio");
			string apellido = PedirDatoString.PedirString("apellido", "ninio");
			int dni = PedirDatoEntero.PedirEnteroPosit("DNI");
			int edad = PedirDatoEntero.PedirEnteroPosit("edad");
			
			Console.Write("Ingrese si es socio o no (s/n): ");
			bool esSocio = Console.ReadLine() == "s";

            return new Ninio(nombre, apellido, dni, edad, esSocio);
        }
    }
}