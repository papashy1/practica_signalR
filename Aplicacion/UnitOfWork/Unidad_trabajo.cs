using Aplicacion.Repository;
using Dominio.interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{
    public class Unidad_trabajo : IUnidad_trabajo, IDisposable
    {
        
        private readonly Puestico_context context;
        private Persona_repository _personas;
        private Usuario_repository _usuarios;
        public Unidad_trabajo(Puestico_context _context)
        {
            context = _context;
        }
        public Persona_repository personas
        {
            get
            {
                if (_personas == null)
                {
                    _personas = new Persona_repository(context);
                }
                return _personas;
            }
        }
                public Usuario_repository Usuario
        {
            get
            {
                if (_usuarios == null)
                {
                    _usuarios = new Usuario_repository(context);
                }
                return _usuarios;
            }
        }
        public int Save()
        {
            return context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}