using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practica2.conte;
using practica2.model;

namespace practica2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class uniController : ControllerBase
    {
        private readonly appDbcontex _context;

        public uniController(appDbcontex context)
        {
            _context = context;
        }
        [Route("")]
        [HttpGet]
        public IEnumerable<universidad> Get()
        {
            return _context.universidad.ToList();
        }
        [HttpPost]
        [Route("uni")]
        public IActionResult CrearUni([FromBody] universidad universidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.universidad.Add(universidad);
                    _context.SaveChanges();
                }
                return Ok(new { mensaje = "Creacion exitosa" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
        [Route("uni")]
        [HttpPut]
        public IActionResult Put([FromBody] universidad universidad)
        {
            _context.universidad.Update(universidad);
            _context.SaveChanges();
            return Ok(universidad);
        }

        [HttpDelete("ELIMINAR/{Id_uni}")]
        public IActionResult Eliminaruni(int Id_uni)
        {
            try
            {

                var uni = _context.universidad.Find(Id_uni);

                if (uni == null)
                {
                    return NotFound();
                }

                _context.universidad.Remove(uni);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mesaje = "Eliminado" });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mesaje = error.Message });
            }
        }
    }
}
