namespace Funciones.Helpers.PedirDato
{
    public class PedirDatoString
    {
        public static string PedirNombre()
        {
            Console.Write("Ingrese el nombre: ");
            return Console.ReadLine();
        }
        public static string PedirApellido()
        {
            Console.Write("Ingrese el apellido: ");
            return Console.ReadLine();
        }
        public static string PedirDia()
        {
            Console.Write("Ingrese el dia: ");
            return Console.ReadLine();
        } 
        public static string PedirHorario()
        {
            Console.Write("Ingrese el horario: ");
            return Console.ReadLine();
        }
    }
    public class PedirDatoEntero
    {
        public static int PedirEnteroPositivo()
        {
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                if (num > 0)
                    return num;
            }
            return -1;
        }
        public static int PedirDni()
        {
            Console.Write("Ingrese el DNI: ");
            return PedirEnteroPositivo();
        }
        public static int PedirCupo()
        {
            Console.Write("Ingrese el cupo: ");
            return PedirEnteroPositivo();
        }
    }
    public class PedirDatoDouble
    {
        public static double PedirDoublePositivo()
        {
            double num;
            if (double.TryParse(Console.ReadLine(), out num))
            {
                if (num > 0)
                    return num;
            }
            return -1;
        }
        public static double PedirCuota()
        {
            Console.Write("Ingrese el valor de la cuota: $");
            return PedirDoublePositivo();
        }
        public static double PedirDescuento()
        {
            Console.Write("Ingrese el valor del descuento: ");
            return PedirDoublePositivo();
        }
    }
}