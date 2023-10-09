namespace Dominio.Entidades
{
    public class Punto : Base_entity
    {
        public string Nombre_punto {get;set;}
        public ICollection<Persona> Personas {get;set;}
    }
}