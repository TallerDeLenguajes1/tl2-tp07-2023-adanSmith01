using Microsoft.AspNetCore.Mvc;
namespace tl2_tp07_2023_adanSmith01.Controllers;

[ApiController]
[Route("[controller]")]
public class TareasController : ControllerBase
{
    private readonly ILogger<TareasController> _logger;

    public TareasController(ILogger<TareasController> logger)
    {
        _logger = logger;
        
    }

    [HttpGet]
    [Route("AllTareas")]
    public ActionResult<IEnumerable<Tarea>> GetAllTareas(){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        var listaTareas = manejadorT.ListaTareas;

        if(listaTareas.Count == 0){
            return BadRequest("ERROR. Hay un problema en obtener el recurso.");
        } else{
            return Ok(listaTareas);
        }
    }

    [HttpGet]
    [Route("ObtenerTarea/{idTarea}")]
    public ActionResult<Tarea> ObtenerTarea(int idTarea){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        var tareaBuscada = manejadorT.ObtenerTareaPorId(idTarea);
        if(tareaBuscada != null){
            return Ok(tareaBuscada);
        } else{
            return NotFound("ERROR. No se pudo conseguir la tarea especificada.");
        }
    }

    [HttpGet]
    [Route("TareasCompletadas")]
    public ActionResult<IEnumerable<Tarea>> GetTareasCompletadas(){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        var tareasCompletadas = manejadorT.ObtenerTareasCompletadas();
        if(tareasCompletadas.Count == 0){
            return BadRequest("ERROR. No se puede obtener la informacion solicitada");
        } else{
            return Ok(tareasCompletadas);
        }
    }

    [HttpPost("CrearTarea")]
    public ActionResult<string> CrearTareaNueva(Tarea tareaNueva){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        if(manejadorT.CrearTarea(tareaNueva)){
            return Ok("Tarea creada exitosamente.");
        } else{
            return BadRequest("ERROR. No se pudo crear su tarea correctamente.");
        }
    }

    [HttpPut("ActualizarTarea")]
    public ActionResult<string> ModificarTarea(Tarea tareaAModificar){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        if(manejadorT.ModificarTarea(tareaAModificar)){
            return Ok("Se actualizo la tarea correctamente.");
        } else{
            return BadRequest("ERROR. Ocurrio un problema en la actualizacion.");
        }
    }

    [HttpDelete("EliminarTarea/{idTarea}")]
    public ActionResult<string> EliminacionTarea(int idTarea){
        var manejadorT = new ManejoTareas(new AccesoADatos());
        if(manejadorT.EliminarTarea(idTarea)){
            return Ok("Se realizo la eliminacion de la tarea realizada exitosamente.");
        } else{
            return BadRequest("ERROR. Hubo un problema en la eliminacion.");
        }
    }
}
