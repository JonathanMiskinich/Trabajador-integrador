using System.Collections;
using Clases.Categorias;
using Clases.Ninios;
using Clases.Deportes;

namespace Clases.Clubes
{
    public class Club
	{
		private ArrayList deportes;
		private ArrayList ninios;
		private ArrayList categorias;
		private int idClub;
		private static int idUnico = 0;
		
		//Constructores
		public Club()
		{
			this.deportes = new ArrayList();
			this.ninios = new ArrayList();
			this.categorias = new ArrayList();
			this.idClub = idUnico;
			idUnico++;
		}
		
		//Properties
		public ArrayList DEPORTES
		{
			get{return this.deportes;}
		}
		public ArrayList NINIOS
		{
			get{return this.ninios;}
		}
		public ArrayList CATEGORIAS
		{
			get{return this.categorias;}
		}
		
		public int ID_CLUB
		{
			get{return this.idClub;}
		}
		
		//Metodos Del ArrayList Deportes
		public void AgregarDeporte(Deporte deporte)
		{
			deportes.Add(deporte);
		}
		public void EliminarDeporte(Deporte deporte)
		{
			deportes.Remove(deporte);
		}
		public int CantDeportes()
		{
			return deportes.Count;
		}
		public Deporte ObtenerDeporteNum(int num)
		{
			return (Deporte)deportes[num];
		}
		
		// Metodos del ArrayList Ninios
		public void AgregarNinio(Ninio ninie){
			ninios.Add(ninie);
		}
		public void EliminarNinio(Ninio ninie){
			ninios.Remove(ninie);
		}
		public int CantNinios(){
			return ninios.Count;
		}
		public Ninio ObtenerNinioNum(int num){
			return (Ninio)ninios[num];
		}
		
		//Metodos del ArrayList Categorias
		public void AgregarCategoria(Categoria cat){
			categorias.Add(cat);
		}
		public void EliminarCategoria(Categoria cat){
			categorias.Remove(cat);
		}
		public int CantCategorias(){
			return categorias.Count;
		}
		public Categoria ObtenerCategoriaNum(int num){
			return (Categoria)categorias[num];
		}
		
	}
}