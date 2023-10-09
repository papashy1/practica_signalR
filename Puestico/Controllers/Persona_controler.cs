using AutoMapper;
using Dominio.interfaces;

namespace Puestico.Controllers
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

//     [HttpGet("GetHistorialVentas/{anio}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<IEnumerable<VentasxAnioDto>>> GetHistorialVentas(int anio)
//     {
//         var ventas = await _unitOfWork.Ventas.GetVentasxAnio(anio);
//         return _mapper.Map<List<VentasxAnioDto>>(ventas);
//     }
//     [HttpGet("GetValorTotalVentas/{anio}")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     [ProducesResponseType(StatusCodes.Status400BadRequest)]
//     public async Task<ActionResult<TotalVentasxAnioDto>> GetValorTotalVentas(int anio)
//     {
//         var ventas = await _unitOfWork.Ventas.GetTotalVentasxAnio(anio);
//         return _mapper.Map<TotalVentasxAnioDto>(ventas);
//     }
//     [HttpGet("generatepdf")]
//     [ProducesResponseType(StatusCodes.Status200OK)]
//     public async Task<IActionResult> GeneratePDF(int anio)
//     {

//         var ventas = await _unitOfWork.Ventas.GetVentasxAnio(anio);
//         IEnumerable<VentasxAnioDto> datos = _mapper.Map<List<VentasxAnioDto>>(ventas);
//         var datosmap = _mapper.Map<List<VentasxAnio>>(datos);

//         var ventasTotal = await _unitOfWork.Ventas.GetTotalVentasxAnio(anio);
//         TotalVentasxAnioDto datoResumen = _mapper.Map<TotalVentasxAnioDto>(ventasTotal);
//         var resumen = _mapper.Map<TotalVentasxAnio>(datoResumen);
//         string image = GetBase64string();
//         var response = await _unitOfWork.Ventas.GenPdf(datosmap, resumen, image);
//         string Filename = "ReporteVentas-" + anio + ".pdf";
//         return File(response, "application/pdf", Filename);
//     }
//     [NonAction]
//     public string GetBase64string()
//     {
//         string filepath = Path.Combine(Directory.GetCurrentDirectory(), "img", "Gatitou.jpg");
//         Console.WriteLine(filepath);
//         byte[] imgarray = System.IO.File.ReadAllBytes(filepath);
//         string base64 = Convert.ToBase64String(imgarray);
//         return base64;
//     }
// }