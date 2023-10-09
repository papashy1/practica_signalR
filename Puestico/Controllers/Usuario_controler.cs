using AutoMapper;
using Dominio.interfaces;
using Puestico.Controllers;

namespace Puestico.Controlers
{
    public class Usuario_controler : Base_api_controller
    {
        private readonly IUnidad_trabajo unidad_dt;
        private readonly IMapper mapper;
        public Usuario_controler(IUnidad_trabajo unidad_dt, IMapper _mapper)
        {
            this.unidad_dt = unidad_dt;
            mapper = _mapper;
        }
    }

}