namespace Dominio.Entidades
{
    public class Persona : Base_entity
    {
        public string Nombre_persona {get; set; }
        public string Apellido_persona {get; set; }
        public int Cedula {get; set; }
        public int Id_punto_fk {get; set; }
        public Usuario Usuario {get; set; }
        public Punto Punto {get; set; }

    }
}