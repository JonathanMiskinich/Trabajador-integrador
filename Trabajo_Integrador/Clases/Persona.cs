namespace Clases.Personas
{
    public class Persona
	{
		//Atributos
		protected string nombre, apellido;
		protected int dni;
		
		//Constructores
		public Persona(){}
		public Persona(string nombre, string apellido, int dni)
        {
			this.nombre = nombre;
			this.apellido = apellido;
			this.dni = dni;
		}
		
		//Propiedades
		public string NOMBRE
        {
			get{return this.nombre;}
			set{this.nombre = value;}
		}
		
		public string APELLIDO
        {
			get{return this.apellido;}
			set{this.apellido = value;}
		}
		
		public int GetDni
        {
			get{return this.dni;}
			set{this.dni = value;}
		}
	}
}