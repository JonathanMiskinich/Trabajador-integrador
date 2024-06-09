using System;
using System.Collections;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			Club clubuser = new Club();
			AltaEntrenador(clubuser);
			Console.ReadKey(true);
		}
		public static void AltaEntrenador(Club clubUsuario)
		{
			string nombre, apellido, nombreDeporte;
			int dni;
			bool flag = false;
			
			Console.Write("Ingrese el nombre del Entrenador: ");
			nombre = Console.ReadLine();
			
			Console.Write("Ingrese el apellido del Entrenador: ");
			apellido = Console.ReadLine();
			
			Console.Write("ingrese el DNI del entrenador: ");
			dni = int.Parse(Console.ReadLine());
			
			Persona entrenador = new Persona(nombre, apellido, dni);
			
			Console.Write("Ingrese el nombre del deporte al que el entrenador va a pertener: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte element in clubUsuario.DEPORTES) {
				if (element.NOMBRE == nombreDeporte) {
					flag = true;
					
					foreach (int id in element.IDCATEGORIAS) {
						
						foreach (Categoria cat in clubUsuario.CATEGORIAS) {
							
							if (cat.ID == id) {
								Console.WriteLine("La categoria a dar de alta al entrenador es: {0}? (s/n)", cat.NOMBRE);
								string opc = Console.ReadLine();
								
								if (opc == "s") {
									cat.ENTRENADOR = entrenador;
									Console.WriteLine("Entrenador dado de alta exitosamente.");
									break;
								}
								break;
							}
						}
					}
				}
			}
			if (flag == false) {
				Console.WriteLine("No se encontro el nombre del deporte.");
			}
		}
		public static void BajaEntrenador(Club clubUsuario)
		{
			
		}

		public static void AltaNinio(Club clubUsuario)
		{
			string nombre, apellido, opcion;
			int dni,edad;
			bool esSocio;
			bool flag = false;
			
			Console.Write("Ingrese el nombre del niño: ");
			nombre = Console.ReadLine();
			
			Console.Write("Ingrese el apellido del niño: ");
			apellido = Console.ReadLine();
			
			Console.Write("Ingrese DNI del niño sin puntos  ni espacios: ");
			dni = int.Parse(Console.ReadLine());
			
			Console.Write("Ingrese la edad del niño: ");
			edad = int.Parse(Console.ReadLine());
			
			Console.Write("Ingrese si es socio o no (s/n): ");
			opcion = Console.ReadLine();
			if (opcion == "s") 
				esSocio = true;
			else 
				esSocio = false;
			
			//Creamos Instancia la clase con el niño nuevo a agregar
			Ninio ninioNuevo = new Ninio(nombre,apellido, dni, edad, esSocio);
			
			//Agregamos el niño al Club
			clubUsuario.AgregarNinio(ninioNuevo);
			
			Console.Write("Ingrese el nombre del deporte al que el niño va a inscribirse o f para cancelar: ");
			string nombreDeporte = Console.ReadLine();
			
			while (flag == false && nombreDeporte != "f") 
			{
				foreach (Deporte element in clubUsuario.DEPORTES) 
				{
					if (element.NOMBRE == nombreDeporte) {
						// Si se encontro el deporte Cambia la flag
						flag = true;
						
						//Recorro los id de las categorias en el deporte seleccionado
						foreach (int id in element.IDCATEGORIAS) {
							
							//Recorro la categorias del club en busca del mismo id que contiene el deporte
							foreach (Categoria cat in clubUsuario.CATEGORIAS) {
								
								if (cat.ID == id) {
									Console.WriteLine("¿La categoria inscribir el niño es {0}?", cat.NOMBRE);
									opcion = Console.ReadLine();
									
									if (opcion == "s") {
										try {
											if (cat.CANTIDADINSCRIPTOS == cat.CUPO)
												throw new SinCapacidadException();
											else 
											{
												cat.AgregarNinio(ninioNuevo.DNI);
												cat.CANTIDADINSCRIPTOS += 1;
												Console.WriteLine("El niño fue inscripto con exito.");
												break;
											}
										} catch (SinCapacidadException) 
										{
											Console.WriteLine("Lo siento, no hay cupo para realizar la inscripcion");
											break;
										}
									}
									break;
								}
							}
						}
					}
				}
				if (flag == false){
					Console.WriteLine("No se encontro el nombre del deporte.");
				
					Console.Write("Ingrese el nombre del deporte al que el niño va a inscribirse o f para cancelar: ");
					nombreDeporte = Console.ReadLine();
				}
			}
		}

		public static void PagoCuota(Club clubUsuario)
		{
			int dni;
			double costoCuota;
			string opcion;
			
			Console.Write("Ingrese el numero del DNI del niño a cobrar la cuota (sin puntos ni esppacio): ");
			dni = int.Parse(Console.ReadLine());
			
			foreach (Ninio ninioPagar in clubUsuario.NINIOS) {
				if (ninioPagar.DNI == dni) {
					if (ninioPagar.SOCIO == true) {
						foreach (Categoria categoriaNinio in clubUsuario.CATEGORIAS) {
							foreach (int dniNinio in categoriaNinio.DNI_NINIOS_INSCRIPTOS) {
								if (dniNinio == dni) {
									costoCuota = ((100 -categoriaNinio.DESCUENTO) * categoriaNinio.COSTOCUOTA) / 100;
									Console.WriteLine("El monto total a pagar es de: {0}", costoCuota);
									
									Console.Write("¿Ya realizo el pago correspondiente? (s/n): ");
									opcion = Console.ReadLine();
									
									if (opcion == "s") {
										ninioPagar.ULT_MES_PAGO = DateTime.Now;
										Console.WriteLine("El pago se realizo con exito.");
									}else
										Console.WriteLine("EL pago se realizara en otro momento.");
								}
							}
						}
					} else {
						foreach (Categoria categoriaNinio in clubUsuario.CATEGORIAS) {
							foreach (int dniNinio in categoriaNinio.DNI_NINIOS_INSCRIPTOS) {
								if (dniNinio == dni) {
									Console.WriteLine("El monto total a pagar es de: {0}", categoriaNinio.COSTOCUOTA);
									
									Console.Write("¿Ya realizo el pago correspondiente? (s/n): ");
									opcion = Console.ReadLine();
									
									if (opcion == "s") {
										ninioPagar.ULT_MES_PAGO = DateTime.Now;
										Console.WriteLine("El pago se realizo con exito.");
									}else
										Console.WriteLine("EL pago se realizara en otro momento.");
								}
							}
						}
					}
				}
			}
		}

		public static void ListadoInscriptos(){}
		
		public static void ListadoDeudores(){}

		public static void AgregarDeporte(Club ClubUsuario)
		{
			string nombreDeporte;
			bool flag = false;
			
			Console.Write("Ingrese el nombre de nuevo deporte: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte deporte in ClubUsuario.DEPORTES) {
				if (deporte.NOMBRE == nombreDeporte) {
					flag = true;
					Console.WriteLine("El nombre del deporte ya existe.");
				}
			}
			if (flag == false) {
				Deporte deporteNuevo = new Deporte(nombreDeporte);
				Console.WriteLine("Quieres agregarle categorias (s/n): ");
				string opcion = Console.ReadLine();
				
				while (opcion == "s") {
					string nombreCategoria, dia, horario,nombreEntrenador, apellidoEntrenador;
					int cupo, cantidadInscriptos, dni;
					double costo, descuento;
					
					Console.Write("Ingrese nombre de la categoria: ");
					nombreCategoria = Console.ReadLine();
					
					Console.Write("Ingrese dia de entrenamiento de la categoria: ");
					dia = Console.ReadLine();
					
					Console.Write("Ingrese horario de los entrenamientos (xx a xx): ");
					horario = Console.ReadLine();
					
					Console.Write("Ingrese el cupo: ");
					cupo = int.Parse(Console.ReadLine());
					
					cantidadInscriptos = 0;
					
					Console.Write("Ingrese el costo de la cuota: ");
					costo = double.Parse(Console.ReadLine());
					
					Console.Write("Ingrese el descuento de la categoria: ");
					descuento = double.Parse(Console.ReadLine());
					
					Console.WriteLine("Ingrese los datos del entrenador");
					Console.Write("Ingrese el nombre del entrenador: ");
					nombreEntrenador = Console.ReadLine();
					
					Console.Write("Ingrese el apellido del entrenador: ");
					apellidoEntrenador = Console.ReadLine();
					
					Console.Write("Ingrese el DNI del entrenador, sin puntos ni espacios: ");
					dni = int.Parse(Console.ReadLine());
					
					Persona EntrenadorCategoria = new Persona(nombreEntrenador, apellidoEntrenador, dni);
					Categoria categoriaNueva = new Categoria(nombreCategoria,cupo, cantidadInscriptos, costo, descuento, dia, horario, EntrenadorCategoria);
					
					ClubUsuario.AgregarCategoria(categoriaNueva);
					deporteNuevo.AgregarCategoria(categoriaNueva.ID);
					
					Console.WriteLine("Quieres agregarle categorias (s/n): ");
					opcion = Console.ReadLine();
				}	
			}
		}

		public static void EliminarDeporte(Club clubUsuario)
		{
			string nombreDeporte;
			Deporte deporteEliminar = new Deporte();
			bool flag = false;
			
			Console.Write("Ingrese el nombre del deporte que quiere eliminar: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte element in clubUsuario.DEPORTES) {
				if (element.NOMBRE == nombreDeporte) {
					deporteEliminar = element;
					foreach (int id in element.IDCATEGORIAS) {
						
						foreach (Categoria catDeporte in clubUsuario.CATEGORIAS) {
							
							if (id == catDeporte.ID) {
								
								if (catDeporte.CANTIDADINSCRIPTOS > 0) {
									flag = true;
									break;
								}
								break;
							}
						}
					}
				}
			}
			if (flag == false) {
				if (deporteEliminar.NOMBRE != null) 
					clubUsuario.EliminarDeporte(deporteEliminar);
				else
					Console.WriteLine("El deporte no se encuentra en la lista.");
			}
			else
				Console.WriteLine("El deporte tiene inscriptos. Debe de no tener inscriptos si quiere eliminarlo.");
			
		}
		
	}
	//Excepciones
	public class SinCapacidadException : Exception{}
	
	//Clases
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
		private static int idUnico = 0;
		
		//CONSTRUCTORES
		public Categoria(){}
		
		public Categoria(string nombre, int cupo, int cantidadInscriptos, double costoCuota, string dia, string horario, Persona entrenador){
			this.nombre = nombre;
			this.cupo = cupo;
			this.cantidadInscriptos = cantidadInscriptos;
			this.id = idUnico;
			this.costoCuota = costoCuota;
			this.dia = dia;
			this.horario = horario;
			this.entrenador = entrenador;
			this.dniNiniosInscriptos = new ArrayList();
			idUnico++;
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
		idUnico++;
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

		//Metodos
	     public void AgregarCategoria(int idCategoria){
	    	idCategorias.Add(idCategoria);
	    }
	    
	    public void EliminarCategoria(int idCategoria){
	    	idCategorias.Remove(idCategoria);
	    }
	    
	    public int CantidadCategorias(){
	    	return idCategorias.Count;
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
