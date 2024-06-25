using System;
using System.Collections;

namespace Trabajo_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			Club clubUser = new Club();
			int opcion;
			
			Console.WriteLine("Bienvenido al Menú de Opciones: ");
			Console.WriteLine("---------------------------------");
			Menu();
			
			opcion = int.Parse(Console.ReadLine());
			
			while (opcion != 0) 
			{
				if (opcion < 0) {
					Console.Write("Por favor elija una de las opciones antes mostradas: ");
					opcion = int.Parse(Console.ReadLine());
				}else
				{
					if (opcion ==  1) {
						Console.WriteLine("---------------------------------");
						AgregarDeport(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 2) {
						Console.WriteLine("---------------------------------");
						EliminarDeporte(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 3) {
						Console.WriteLine("---------------------------------");
						AltaEntrenador(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 4) {
						Console.WriteLine("---------------------------------");
						BajaEntrenador(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 5) {
						Console.WriteLine("---------------------------------");
						AltaNinio(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 6) {
						Console.WriteLine("---------------------------------");
						EliminarNinio(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 7) {
						Console.WriteLine("---------------------------------");
						ListadoInscriptos(ref clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 8) {
						Console.WriteLine("---------------------------------");
						ListadoDeudores(clubUser);
						Console.WriteLine("---------------------------------");
					}
					if (opcion == 9) {
						Console.WriteLine("---------------------------------");
						PagoCuota(ref clubUser);
						Console.WriteLine("---------------------------------");
					}

					foreach (Deporte element in clubUser.DEPORTES) 
					{
						Console.WriteLine(element.NOMBRE);
					}
					Menu();
						
					opcion = int.Parse(Console.ReadLine());
				}
			}
		}
		public static void Menu(){
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
		
		public static void AltaEntrenador(ref Club clubUsuario)
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
			
		//Creo la instacia de persona para guardar los datos del nuevo entrenador
			Persona entrenador = new Persona(nombre, apellido, dni);
			
			Console.Write("Ingrese el nombre del deporte al que el entrenador va a pertener: ");
			nombreDeporte = Console.ReadLine();
			
			foreach (Deporte element in clubUsuario.DEPORTES) 
			{
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
			if (flag == false)
				Console.WriteLine("No se encontro el nombre del deporte.");
		}
		
		public static void BajaEntrenador(ref Club clubUsuario)
		{
			Console.WriteLine("Ingrese el dni del entrenador a dar de baja: ");
			int dni = int.Parse(Console.ReadLine());
			bool entrenadorEncontrado = false;
			Persona entrenador;
			
			foreach (Categoria categoria in clubUsuario.CATEGORIAS)
			{
				entrenador = (Persona)categoria.ENTRENADOR;
				if(entrenador != null && entrenador.DNI == dni){
					categoria.ENTRENADOR = null; //Acá asignamos null al atributo entrenador.
					entrenadorEncontrado = true;
					Console.WriteLine("Entrnador con DNI {0} eliminado de la categoría {1}.", dni, categoria.NOMBRE);
				}
			}
			
			if(!entrenadorEncontrado){
				Console.WriteLine("No se encontró al entrenador con el dni ingresado");
			}
		}
		
		public static void AltaNinio(ref Club clubUsuario)
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
									Console.WriteLine("¿La categoria inscribir el niño es {0}? (s/n)", cat.NOMBRE);
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
		
		public static void EliminarNinio(ref Club clubUsuario)
		{
			int dni;
			bool flag = false;
			bool flagDeporte = false;
			string nombreDeporte;
			Ninio ninio;
			Deporte deporteNinio = new Deporte();
			
			Console.Write("Ingrese el DNI del niño que quiere eliminar, sin puntos ni comas: ");
			dni = int.Parse(Console.ReadLine());
			
			
			foreach (Ninio element in clubUsuario.NINIOS) {
				if (element.DNI == dni) {
					ninio = (Ninio)element;
					flag = true;
					break;
				}
			}
			
			if (flag == false)
				Console.WriteLine("El DNI ingresado no pertenece a ningun niño del club.");
			else {
				Console.Write("Ingrese el nombre del deporte al que el niño pertenece: ");
				nombreDeporte = Console.ReadLine();
				
				foreach (Deporte element in clubUsuario.DEPORTES) {
					if (element.NOMBRE == nombreDeporte) {
						deporteNinio = (Deporte)element;
						flagDeporte = true;
					}
				}
				
				if (flagDeporte) {
					foreach (int id in deporteNinio.IDCATEGORIAS) {
						foreach (Categoria cat in clubUsuario.CATEGORIAS) {
							if (cat.ID == id)  {
								foreach (int dniNinioCategoria in cat.DNI_NINIOS_INSCRIPTOS) {
									if (dni == dniNinioCategoria ) {
										cat.EliminarNinio(dni);
										cat.CANTIDADINSCRIPTOS -= 1;
										Console.WriteLine("El niño fue eliminado con exito.");
										break;
									}
								}
							}
						}
					}
				}else{
					Console.WriteLine("El deporte ingresado no se encuentra.");
				}
			}
		}
		
		public static void PagoCuota(ref Club clubUsuario)
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
		
		public static void ListadoInscriptos(ref Club clubUsuario)
		{
			string opc, opcDeporte, opcCategoria;
            int cantxcat= 0, cantxdeportetotal= 0;
            ArrayList ninios = clubUsuario.NINIOS;
            int total = ninios.Count;
            bool estaDeporte = false;
            bool estaCategoria = false;
            
            //creo las variables y el total ya lo calculo porque lo voy a imprimir de todas formas
            Console.WriteLine("Ingrese 'total' si quiere ver solo la cantidad total de inscriptos o 'deporte' si quiere de algun deporte en especifico");
            opc=Console.ReadLine(); //le pido al usuario lo que quiere ver
            if (opc == "deporte"){
                Console.WriteLine("eliga el deporte del que desea ver los inscriptos");
                opcDeporte= Console.ReadLine();
                foreach (Deporte deporte in clubUsuario.DEPORTES) {
                    if (opcDeporte == deporte.NOMBRE) { //verifico que el deporte este registrado en el club
                		estaDeporte = true;
                		
                        Console.WriteLine("Eliga la categoria que desea revisar");
                        opcCategoria= Console.ReadLine();
                        
                        foreach(Categoria cat in clubUsuario.CATEGORIAS) {
                            
                        	if (opcCategoria == cat.NOMBRE) { //lo mismo con la categoria verifico si esta registrado en el deporte
                                cantxcat += cat.CANTIDADINSCRIPTOS; //calculo la cantidad de inscriptos es esa categoria sola
                                estaCategoria = true;
                            }
                        }
                    foreach (Categoria ele in clubUsuario.CATEGORIAS){
                            bool valor= deporte.IDCATEGORIAS.Contains(ele.ID);//verifico si la id de la categoria se encuentra en el deporte
                            if (valor == true){ //si es verdadero, hago el calculo
                                cantxdeportetotal= cantxdeportetotal + ele.CANTIDADINSCRIPTOS; //calculo la cantidad de inscriptos por cada categoria del deporte para saber el total inscriptos en el deporte
                            }
                    }
                 
                    }
                }
                if (!estaDeporte) {
                	Console.WriteLine("La cantidad de inscriptos en total en el deporte elegido son: " + cantxdeportetotal);
                	if (!estaCategoria) {
                		Console.WriteLine("La cantidad de inscriptos segun el deporte y la categoria elegida son: " + cantxcat);
                	}else{
                		Console.WriteLine("La categoria ingresada no se encontro. Lo siento.");
                	}
                
                }else{
                	Console.WriteLine("El deporte ingresado no se encunetra en le club. Lo siento.");
                }
            }
        if (opc == "total") Console.WriteLine("La cantidad de inscriptos en total son: " + total);
        }
		
		public static void ListadoDeudores(Club clubUsuario)
		{
			DateTime mesActual = DateTime.Now;
			bool hayDeudores = false;

			Console.WriteLine("Listado de Deudores:");
    
			foreach (Ninio ninio in clubUsuario.NINIOS)
			{
				// Comparamos solo el mes y el año, sin importar el día
				if (ninio.ULT_MES_PAGO.Year < mesActual.Year ||
				    (ninio.ULT_MES_PAGO.Year == mesActual.Year && ninio.ULT_MES_PAGO.Month < mesActual.Month))
				{
					Console.WriteLine("Nombre: {0} {1}, DNI: {2}, Último mes pago: {3}",
					                  ninio.NOMBRE, ninio.APELLIDO, ninio.DNI, ninio.ULT_MES_PAGO.ToString("MM/yyyy"));
					hayDeudores = true;
				}
			}
			if (!hayDeudores)
			{
				Console.WriteLine("No hay deudores.");
			}
		}
		
		public static Club AgregarDeport(ref Club ClubUsuario)
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
					while (true) {
						if (descuento >= 0) break; 
						else {
							Console.WriteLine("Por favor ingrese un numero positivo.");
							descuento = double.Parse(Console.ReadLine());
						}
					}
					
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
				ClubUsuario.AgregarDeporte(deporteNuevo);
			}
			return ClubUsuario;
		}
		
		public static void EliminarDeporte(ref Club clubUsuario)
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
				if (deporteEliminar.NOMBRE != null){
					clubUsuario.EliminarDeporte(deporteEliminar);
					Console.WriteLine("El deporte fue eliminado con exito del club.");
				}
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
		private double costoCuota, descuento;
		private Persona entrenador;
		private ArrayList dniNiniosInscriptos;
		private static int idUnico = 0;
		
		//CONSTRUCTORES
		public Categoria(){}
		
		public Categoria(string nombre, int cupo, int cantidadInscriptos, double costoCuota, double descuento, string dia, string horario, Persona entrenador){
			this.nombre = nombre;
			this.cupo = cupo;
			this.cantidadInscriptos = cantidadInscriptos;
			this.id = idUnico;
			this.costoCuota = costoCuota;
			this.descuento = descuento;
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
			set{this.cupo = value;}
		}
		
		public int CANTIDADINSCRIPTOS
		{
			get{ return this.cantidadInscriptos;}
			set{this.cantidadInscriptos = value;}
		}
		
		public int ID
		{
			get{ return this.id; }
			set{ this.id = value;}
		}
		
		public double COSTOCUOTA
		{
			get{ return this.costoCuota;}
			set{this.costoCuota = value;}
		}
		
		public double DESCUENTO
		{
			get{return this.descuento;}
			set{this.descuento = value;}
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
		
		public bool EstaNinio(Ninio nin){
			return dniNiniosInscriptos.Contains(nin);
		}
		
		public int VerDNINinioNum(int num){
			return (int)dniNiniosInscriptos[num];
		}
		
		public int VerCantidadNinios(){
			return dniNiniosInscriptos.Count;
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
	    
	    public void AgregarCategoria(int idCategoria){
	    	idCategorias.Add(idCategoria);
	    }
	    
	    public void EliminarCategoria(int idCategoria){
	    	idCategorias.Remove(idCategoria);
	    }
	    
	    public bool CategoriaExiste(int categoriaId){
	    	return idCategorias.Contains(categoriaId);
	    }
	    
	    public int CantidadCategorias(){
	    	return idCategorias.Count;
	    }
	    
	    public int VerIDCategoriaNum(int num){
	    	return (int)idCategorias[num];
	    }
	}
	
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
