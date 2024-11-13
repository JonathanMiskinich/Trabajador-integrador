using Clases.Personas;
using Clases.Ninios;
using System.Collections;

namespace Clases.Categorias
{
    public class Categoria
	{
		//ATRIBUTOS
		private string nombre, dia, horario;
		private int cupo, cantidadInscriptos, id;
		private double costoCuota, descuento;
		private Persona entrenador;
		private List<int> dniNiniosInscriptos;
		private static int idUnico = 0;
		
		//CONSTRUCTORES
		public Categoria(){}
		
		public Categoria(string nombre, int cupo, double costoCuota, double descuento, string dia, string horario, Persona entrenador){
			this.nombre = nombre;
			this.cupo = cupo;
			this.cantidadInscriptos = 0;
			this.id = idUnico;
			this.costoCuota = costoCuota;
			this.descuento = descuento;
			this.dia = dia;
			this.horario = horario;
			this.entrenador = entrenador;
			this.dniNiniosInscriptos = new List<int>();
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
		
		public List<int> DNI_NINIOS_INSCRIPTOS
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
			return dniNiniosInscriptos.Contains(nin.GetDni);
		}
		
		public int VerDNINinioNum(int num){
			return dniNiniosInscriptos[num];
		}
		
		public int VerCantidadNinios(){
			return dniNiniosInscriptos.Count;
		}
		
	}
}