using System;
using System.Collections;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			Ninio niño = new Ninio();
			
			niño.NOMBRE = "Juan";
			niño.APELLIDO = "Miskinich";
			
			niño.EDAD= 23;
			niño.SOCIO = true;
			Console.WriteLine(niño.SOCIO);
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
	
	public class Ninio : Persona
	{
		private int edad;
		private bool socio;
		private DateTime ultMesPago;
		
		// Constructores
		public Ninio() : base(){}
		public Ninio(string nombre, string apellido, int dni, int edad, bool socio): base(nombre, apellido, dni)
		{
			this.edad = edad;
			this. socio = socio;
			this.ultMesPago = DateTime.Now;
		}
		
		// Properties
		
		public int EDAD{
			get{return this.edad;}
			set{this.edad = value;}
		}
		
		public DateTime ULT_MES_PAGO{
			get{return this.ultMesPago;}
			set{this.ultMesPago = value;}
		}
		
		public bool SOCIO{
			get{return this.socio;}
			set{this.socio = value;}
		}
	}
	
	public class Categoria
	{
		//ATRIBUTOS
		private string nombre, dia, horario;
		private int cupo, cantidadInscriptos, id;
		private double costoCuota;
		private Persona entrenador;
		private ArrayList dniNiniosInscriptos;
		
		//CONSTRUCTORES
		public Categoria(){}
		
		public Categoria(string nombre, int cupo, int cantidadInscriptos, int id, double costoCuota, string dia, string horario, Persona entrenador){
			this.nombre = nombre;
			this.cupo = cupo;
			this.cantidadInscriptos = cantidadInscriptos;
			this.id = id;
			this.costoCuota = costoCuota;
			this.dia = dia;
			this.horario = horario;
			this.entrenador = entrenador;
			this.dniNiniosInscriptos = new ArrayList();
		}
		
		//PROPIEDADES
		public string NOMBRE
		{
			get{ return this.nombre; }
			set{ this.nombre = value; }
		}
		
		public string DIA
		{
			get{ return this.dia; }
			set{ this.dia = value; }
		}
		
		public string HORARIO
		{
			get{ return this.horario; }
			set{ this.horario = value; }
		}
		
		public int CUPO
		{
			get{ return this.cupo;}
			set{
				if( value < 0)
					Console.WriteLine("El cupo no puede ser negativo");
				else
					this.cupo = value;
				}
		}
		
		public int CANTIDADINSCRIPTOS
		{
			get{ return this.cantidadInscriptos;}
			set
			{
				if( value < 0 || value > cupo)
					Console.WriteLine("La cantidad de inscriptos no puede ser negativa, ni mayor a la cantidad de cupos");
				else
					this.cantidadInscriptos = value;
			}
		}
		
		public int ID
		{
			get{ return this.id; }
			set{ this.id = value;}
		}
		
		public double COSTOCUOTA
		{
			get{ return this.costoCuota;}
			set{
				if( value < 0)
					Console.WriteLine("El costo de la cuota no puede ser menor a 0");
				else
					this.costoCuota = value;
			}
		}
		
		public Persona ENTRENADOR
		{
			get{ return this.entrenador;}
			set{ this.entrenador = value;}
		}
		
		public ArrayList DNI_NINIOS_INSCRIPTOS
		{
			get{ return this.dniNiniosInscriptos;}
		}
		
		//Metodos
		public void AgregarNinio(int dniNInio){
			dniNiniosInscriptos.Add(dniNInio);
		}
		
		public void EliminarNinio(int dniNinio){
			dniNiniosInscriptos.Remove(dniNinio);
		}
		
	}
	
	public class Club
	{
		private ArrayList deportes;
		private ArrayList ninios;
		private ArrayList categorias;
		
		//Constructores
		public Club()
		{
			this.deportes = new ArrayList();
			this.ninios = new ArrayList();
			this.categorias = new ArrayList();
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
		
		//Metodos
		public void AgregarDeporte(string nombreDeporte)
		{
			
		}
		public void EliminarDeporte(string nombreDeporte){}
		public void ModificarDeporte(string nombreDeporte){}
		public void VerDatosDeporte(string nombreDeporte){}
		
		public void AgregarNinio(int dniNinio){}
		public void EliminarNinio(int dniNinio){}
		public void ModificarNinio(int dniNinio){}
		public void VerDatosNinio(int dniNinio){}
		
		public void AgregarCategoria(string nombreDeporte){}
		public void EliminarCategoria(string nombreDeporte){}
		public void ModificarCategoria(string nombreDeporte){}
		public void VerDatosCategoria(string nombreDeporte){}
	}
}
