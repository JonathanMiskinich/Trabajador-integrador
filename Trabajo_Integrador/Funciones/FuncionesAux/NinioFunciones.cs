using Clases.Ninios;
using Clases.Clubes;
using Clases.Deportes;
using Clases.Categorias;
using Excepciones.SinCapacidad;

namespace Funciones.NinioFunc
{
    public static class NinioFuncExtensions
    {
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
			
			
			foreach (Ninio element in clubUsuario.NINIOS) 
            {
				if (element.DNI == dni) 
                {
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
	}	
}