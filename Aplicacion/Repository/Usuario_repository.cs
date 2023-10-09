using Dominio.Entidades;
using Dominio.interfaces;
using Persistencia;

namespace Aplicacion.Repository
{
    public class Usuario_repository : Generic_repository<Usuario>, IUsuario_repository
    {
        
       private readonly Puestico_context _context;
        public Usuario_repository(Puestico_context context) : base(context)
        {
                   _context = context;  
        }
    }
}