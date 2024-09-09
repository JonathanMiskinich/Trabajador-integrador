using Clases.Personas;
using System.Collections;

namespace Clases.Ninios
{
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
}