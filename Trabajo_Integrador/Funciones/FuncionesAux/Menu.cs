namespace Funciones.MenuFunc
{
    public static class MenuFuncExtensions
    {
        public static void Menu()
        {
            Console.WriteLine("Elija una de las opciones: ");
			Console.WriteLine("1 - Agregar deporte Nuevo.");
			Console.WriteLine("2 - Eliminar deporte existente.");
			Console.WriteLine("3 - Dar de alta a un entrenador a una categoria.");
			Console.WriteLine("4 - Elimminar a un entrenador.");
			Console.WriteLine("5 - Dar de alta a un niño en una categoria.");
			Console.WriteLine("6 - Eliminar a una niño de una categoria.");
			Console.WriteLine("7 - Ver listado de inscriptos.");
			Console.WriteLine("8 - Ver el Listado de los deudores.");
			Console.WriteLine("9 - Realizar el pago de una cuota de un niño.");
			Console.WriteLine("0 - SALIR");
			Console.WriteLine("---------------------------------");
			Console.Write("Elija un numero de las opciones: ");
        }
    }
}