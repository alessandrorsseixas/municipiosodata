using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using WebApplication1.dto;
using WebApplication1.service;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService _service;

        private readonly ILogger<MunicipioController> _logger;

        public MunicipioController(IMunicipioService service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery] // Permite $filter, $orderby, $top, etc.
        public ActionResult<IQueryable<municipio>> GetMunicipios()
        {
            var teste = _service.GetAll();
            return Ok(teste); // Certifique-se de que retorna IQueryable<Municipio>
        }
    }
}
