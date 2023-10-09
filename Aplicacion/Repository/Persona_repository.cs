using Dominio.Entidades;
using Dominio.interfaces;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Repository
{
    public class Persona_repository : Generic_repository<Persona>, IPersona_repository
    {
       private readonly Puestico_context _context;
       public Persona_repository(Puestico_context context) : base(context)
       {
         _context = context;
       }
       public override async Task<IEnumerable<Persona>> GetAllAsync()
       {
        return await _context.Personas
        .Include(p => p.Punto)
        .Include(p => p.Usuario)
        .ToListAsync();
       }
    }
}