using Microsoft.AspNetCore.Mvc;
using practica2.conte;

namespace practica2.Controllers
{
    public class materiaController:ControllerBase
    {
        private readonly appDbcontex _context;

        public materiaController (appDbcontex context)
        {
            _context = context;
        }
    }
}
