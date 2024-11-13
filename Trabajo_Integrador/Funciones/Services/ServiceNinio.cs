using Clases.Categorias;
using Clases.Clubes;
using Clases.Deportes;
using Clases.Ninios;
using Funciones.Helpers.Deportes;
using Funciones.Helpers.Ninios;
using Funciones.Helpers.PedirDato;

namespace Funciones.Services.Ninios
{
    public class ServicesNinio
    {
        public static void AltaNinio(ref Club clubUsuario)
        {
            Ninio ninio = NiniosHelper.CrearNinio();
            
            Console.WriteLine("Datos del deporte al que se va a incribir.");
            string nombreDeporte = PedirDatoString.PedirString("nombre", "deporte");

            while (nombreDeporte != "f")
            {
                if (HelperDeporte.ExisteDeporte(clubUsuario, nombreDeporte))
                {
                    Deporte deporteSeleccionado = HelperDeporte.EncontrarDeporte(clubUsuario, nombreDeporte);
                    foreach (Categoria cat in clubUsuario.CATEGORIAS)
                    {
                        if (deporteSeleccionado.IDCATEGORIAS.Contains(cat.ID))
                        {
                            Console.WriteLine($"La categoria que quires anadir el niño es {0}? (s/n)", cat.NOMBRE);
                            if (Console.ReadLine() == "s")
                            {
                                cat.AgregarNinio(ninio.GetDni);
                                clubUsuario.AgregarNinio(ninio);
                                return;
                            }
                        }
                    }
                }else
                {
                    Console.Write("El deporte no existe.\n Ingrese de nuevo el nombre o f para salir: ");
                    nombreDeporte = Console.ReadLine();
                }
            }
        }

        public static void EliminarNinio(ref Club clubUsuario)
        {
            int dni = PedirDatoEntero.PedirEnteroPosit("DNI");

            foreach (Ninio ninio in clubUsuario.NINIOS)
            {
                if (ninio.GetDni == dni)
                {
                    clubUsuario.EliminarNinio(ninio);
                    foreach (Categoria cat in clubUsuario.CATEGORIAS)
                    {
                        if (cat.EstaNinio(ninio))
                            cat.EliminarNinio(ninio.GetDni);
                    }
                    return;
                }
            }
        }

        public static void PagoCuota(ref Club clubUsuario)
        {
            int dni = PedirDatoEntero.PedirEnteroPosit("DNI");

            foreach (Ninio ninio in clubUsuario.NINIOS)
            {
                if (ninio.GetDni == dni)
                {
                    foreach (Categoria item in clubUsuario.CATEGORIAS)
                    {
                        if (item.EstaNinio(ninio))
                        {
                            if (ninio.SOCIO)
                            {
                                double costoCuota = ((100 - item.DESCUENTO) * item.COSTOCUOTA) / 100;
                                Console.WriteLine($"El monto es de {0}", costoCuota);
                                Console.Write("Inserte s cuando se haya realizado el pago.");
                                if (Console.ReadLine() == "s")
                                    ninio.ULT_MES_PAGO = DateTime.Now;
                            }else
                            {
                                Console.WriteLine($"El monto es de {0}", item.COSTOCUOTA);
                                Console.Write("Inserte s cuando se haya realizado el pago.");
                                if (Console.ReadLine() == "s")
                                    ninio.ULT_MES_PAGO = DateTime.Now;
                            }
                        }
                    }
                }
            }
        }
    }
}