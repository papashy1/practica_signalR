namespace Dominio.Entidades
{
    public class Usuario : Base_entity
    {
        public string User_name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Id_persona_fk{get; set; }
        public Persona Persona { get; set; }

    }
}