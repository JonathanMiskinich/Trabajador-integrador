namespace Funciones.Helpers.PedirDato
{
    public class PedirDatoString
    {
        public static string PedirString(string dato, string categoria)
        {
            Console.Write($"Ingrese el {0} de {1}: ", dato,categoria);
            return Console.ReadLine();
        }
    }
    public class PedirDatoEntero
    {
        public static int PedirEnteroPosit(string dato)
        {
            Console.Write($"Ingrese el {0}: ", dato);
            string num = Console.ReadLine();

            while (true)
            {
                if (int.Parse(num) < 0)
                {
                    Console.Write("Numero no valido. \nIngrese nuevamente: ");
                    num  = Console.ReadLine();
                }
                else
                    return int.Parse(num);
            }
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