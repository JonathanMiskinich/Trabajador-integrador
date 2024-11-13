using Clases.Clubes;
using Clases.Deportes;
using Clases.Categorias;

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

        public static bool DeporteTieneInscriptos(Club club, Deporte deporte)
        {
            foreach (Categoria cat in club.CATEGORIAS)
            {
                if (deporte.IDCATEGORIAS.Contains(cat.ID))
                {
                    if (cat.CANTIDADINSCRIPTOS > 0)
                        return true;
                }
            }
            return false;
        }

        public static Deporte EncontrarDeporte(Club club,string nombreDeporte)
        {
            foreach (Deporte deporte in club.DEPORTES) 
            {
				if (deporte.NOMBRE == nombreDeporte) 
                    return deporte;
            }
            return null;
        }
    }
}