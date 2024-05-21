using System;
using System.Collections;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Console.ReadKey(true);
		}
	}
	
	public class Persona
	{
		//Atributos
		protected string nombre, apellido;
		protected int dni;
		
		//Constructores
		public Persona(){}
		public Persona(string nombre, string apellido, int dni){
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
		}
		
		//Propiedades
		public string NOMBRE{
			get{return this.nombre;}
			set{this.nombre = value;}
		}
		
		public string APELLIDO{
			get{return this.apellido;}
			set{this.apellido = value;}
		}
		
		public int DNI{
			get{return this.dni;}
			set{this.dni = value;}
		}
	}
	
	
	public class Entrenador: Persona
	{
		//Atributos
		private Categoria categoria;
		
		//Constructores
		public Entrenador(){}
		public Entrenador (string nombre, string apellido, int dni, Categoria categoria): base (nombre, apellido, dni)
		{
			this.categoria = categoria;
		}
		//propiedades
		public Categoria CATEGORIA{
			get{return this.categoria;}
			set{this.categoria = value;}
		}
		
	}
	public class Ninios : Persona
	{
	    // Atributos
	    private int edad;
	    private Deporte deporte;
	    private Categoria categoriaDeporte;
	    private DateTime ultimoMesPago;
	    private bool esSocio;
	
	    // Constructores
	    public Ninios(){}
	    public Ninios(string nombre, string apellido, int dni, int edad, Deporte deporte, Categoria categoriaDeporte, DateTime ultimoMesPago, bool esSocio)
	        : base(nombre, apellido, dni)
	    {
	        this.edad = edad;
	        this.deporte = deporte;
	        this.categoriaDeporte = categoriaDeporte;
	        this.ultimoMesPago = ultimoMesPago;
	        this.esSocio = esSocio;
	    }
	
	    // Propiedades:
	    public int EDAD
	    {
	        get { return this.edad; }
	        set { this.edad = value; }
	    }
	
	    public Deporte DEPORTE
	    {
	        get { return this.deporte; }
	        set { this.deporte = value; }
	    }
	
	    public Categoria CATEGORIA
	    {
	        get { return this.categoriaDeporte; }
	        set { this.categoriaDeporte = value; }
	    }
	
	    public DateTime ULTIMO_MES_PAGO
	    {
	        get { return this.ultimoMesPago; }
	        set { this.ultimoMesPago = value; }
	    }
	
	    public bool ES_SOCIO
	    {
	        get { return this.esSocio; }
	        set { this.esSocio = value; }
	    }
	
	    // Método para cambiar de deporte:
	    public void CambiarDeporte(Deporte nuevoDeporte,Categoria nuevaCategoria)
	    {
	        this.deporte = nuevoDeporte;
	        this.categoriaDeporte = nuevaCategoria;
	    }
	    
	    //Metodo obtener nombre del deporte
	}
	
	public class Categoria
	{
		//Atributos
		private string descripcion, dia, hora;
		private Entrenador entrenador;
		private int cupo, cantidadInscriptos;
		private double costoCuota;
		
		//Constructores
		public Categoria(){}
		public Categoria(string desc, Entrenador entre, int cupo, double costoCuota, string dia, string hora){
			this.descripcion = desc;
			this.entrenador = entre;
			this.cupo = cupo;
			this.costoCuota= costoCuota;
			this.cantidadInscriptos = 0;
			this.dia = dia;
		}
		
		//Propiedades
		public string DESCRIPCION
		{
			get{return this.descripcion;}
			set{this.descripcion = value;}
		}
		
		public string DIA
		{
			get{return this.dia;}
			set{this.dia = value;}
		}
		
		public string HORA
		{
			get{return this.hora;}
			set{this.hora = value;}
		}
		
		public Entrenador ENTRENADOR
		{
			get{return this.entrenador;}
			set{this.entrenador = value;}
		}
		
		public int CUPO
		{
			get{return this.cupo;}
			set{this.cupo = value;}
		}
		
		public int CANT_INSCRIPTOS
		{
			get{return this.cantidadInscriptos;}
			set{this.cantidadInscriptos = value;}
		}
		
		public double COSTO_CUOTA
		{
			get{return this.costoCuota;}
			set{this.costoCuota = value;}
		}
	}
	
	public class Deporte
	{
		//atributos
		protected string nombre;
		protected ArrayList categorias;
		//constructor
		public Deporte (string nombre)
		{
			this.nombre = nombre;
			this.categorias = new ArrayList();
		}
		//propiedades
		public string NOMBRE{
			get{return this.nombre;}
			set{this.nombre = value;}
		}
		public ArrayList CATEGORIAS{
			get{return this.categorias;}
			set{this.categorias = value;} 
		}
		//metodos
		public void AgregarCategoria(Categoria nuevaCat)
		{
			categorias.Add(nuevaCat);
		}
		public void EliminarCategoria(Categoria removerCat)
		{
			categorias.Remove(removerCat);
		}
		public void ModificarCategoria(Categoria catAModificar,Categoria modificarCat)
		{
			//categorias[catAModificar] = modificarCat;
		}
	}
	
}