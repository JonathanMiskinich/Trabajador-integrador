using System;
using System.Collections;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			ArrayList deportes = new ArrayList();
			ArrayList ninios = new ArrayList();
			
			Persona entrenador = new Persona("Juan", "Peron", 3232323);
			
			Deporte depor = new Deporte("Futbol");
			Categoria cat = new Categoria("Infantil", entrenador, 20, 20000, "Martes", "14 a 16");
			deportes.Add(depor);
			depor.AgregarCategoria(cat);
			
			BajaEntrenador(deportes);
			
			Console.ReadKey(true);
		}
		public static Persona AltaEntrenador()
		{
			Persona entrenadorNuevo = new Persona(); // Se crea una instancia de persona
			string nombre, apellido;
			int dni;
			
			//Se le piden los datos al usuario
			Console.WriteLine("Ingrese los datos del entrenador: ");
			Console.Write("Nombre: ");
			nombre = Console.ReadLine();
			
			Console.Write("Apellido: ");
			apellido = Console.ReadLine();
			
			Console.Write("DNI: ");
			dni = int.Parse(Console.ReadLine());
			
			//Se le asignan los valores a la la instacia de persona antes creada
			entrenadorNuevo.NOMBRE = nombre;
			entrenadorNuevo.APELLIDO = apellido;
			entrenadorNuevo.DNI = dni;
			
			return entrenadorNuevo;
		}
		
		public static void BajaEntrenador(ArrayList deporte)
		{
			Console.Write("Ingrese el nombre del deporte en el que queire dar de baja al entrenador: ");
			string nombre = Console.ReadLine();
			
			foreach (Deporte elem in deporte) // Recorre el aaray pasado por parametro
			{
				if (elem.NOMBRE == nombre) //Se ve si el nombre ingresado es de algun deporte guardado
				{ 
					foreach (Categoria elem2 in elem.CATEGORIAS) //Recorre el Array de categorias dentro del objeto deporte
					{
						Console.WriteLine("¿La categoria a modificar es {0}?", elem2.DESCRIPCION);
						string opc = Console.ReadLine();
						if (opc == "no") {break;}
						if (opc == "si") 
						{
							Console.WriteLine("El entrenador {0} {1} fue dado de baja.", elem2.ENTRENADOR.NOMBRE, elem2.ENTRENADOR.APELLIDO);
							elem2.ENTRENADOR = null; // Se le asigna un valor nulo al atributo entrenador 
						}
					}
				}
			}
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
	    
	}
	
	public class Categoria
	{
		//Atributos
		private string descripcion, dia, hora;
		private Persona entrenador;
		private int cupo, cantidadInscriptos;
		private double costoCuota;
		
		//Constructores
		public Categoria(){}
		public Categoria(string desc, Persona entre, int cupo, double costoCuota, string dia, string hora){
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
		
		public Persona ENTRENADOR
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
		private string nombre;
		private ArrayList categorias;
		
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
		
		public void verTodasCategorias()
		{
			foreach (Categoria cat in categorias)
			{
				Console.WriteLine(cat);
			}
		}
		
		public void DevolverCatNum (int i)
		{
			try {
				Console.WriteLine(categorias[i]);
			} 
			catch (IndexOutOfRangeException){
				Console.WriteLine("El numero ingresado es incorrecto.");
			}
		}
		
		public bool ExisteCategoria(Categoria categoria)
		{
			bool existe = false;
			if (categorias.Contains(categoria)) {
				existe = true;
			}
			return existe;
		}
		
		public int cantCategorias()
		{
			return categorias.Count;
		}
	}
	
}