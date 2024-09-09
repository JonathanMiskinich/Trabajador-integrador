using System.Collections;

namespace Clases.Deportes
{
    public class Deporte
	{
	    //atributos
	    private string nombre;
	    private int id;
	    private ArrayList idCategorias;
	    private static int idUnico = 0;
	    
	    //constructor
	    public Deporte(){
	        idCategorias= new ArrayList();
	    }
	    public Deporte (string nombre){
	        this.nombre = nombre;
	        this.id = idUnico;
	        this.idCategorias = new ArrayList();
	        idUnico ++;
	    }
	    //propiedades
	    public string NOMBRE{
	        get{ return this.nombre;}
	        set{ this.nombre = value;}
	    }
	    public int ID{
	        get{ return this.id;}
	        set{ this.id = value;}
	    }
	    public ArrayList IDCATEGORIAS{
	        get{ return this.idCategorias;}
	        set{ this.idCategorias = value;}
		}
	    
	    // Metodos
	    
	    public void AgregarCategoria(int idCategoria)
        {
	    	idCategorias.Add(idCategoria);
	    }
	    
	    public void EliminarCategoria(int idCategoria)
        {
	    	idCategorias.Remove(idCategoria);
	    }
	    
	    public bool CategoriaExiste(int categoriaId)
        {
	    	return idCategorias.Contains(categoriaId);
	    }
	    
	    public int CantidadCategorias()
        {
	    	return idCategorias.Count;
	    }
	    
	    public int VerIDCategoriaNum(int num)
        {
	    	return (int)idCategorias[num];
	    }
	}
}