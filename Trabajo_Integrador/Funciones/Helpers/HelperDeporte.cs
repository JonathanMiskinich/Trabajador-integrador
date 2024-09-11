using Clases.Clubes;
using Clases.Deportes;

namespace Funciones.Helpers.Deportes
{
    public class HelperDeporte
    {
        public static bool ExisteDeporte(Club club, string nombreDeporte)
        {
            foreach (Deporte deporte in club.DEPORTES) 
            {
				if (deporte.NOMBRE == nombreDeporte) 
                    return true;
            }
            return false;
        }
    }
}