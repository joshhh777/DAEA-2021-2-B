using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab12.Models;

namespace lab12.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Listar()
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Jose",
                Apellido = "Cancino",
                Direccion = "Av. Fco Bolognesi 311",
                FechaNac = Convert.ToDateTime("2000-01-27"),
                Email = "jcancino@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. Progreso 234",
                FechaNac = Convert.ToDateTime("1995-10-28"),
                Email = "maria@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Carlos",
                Apellido = "Martinez",
                Direccion = "Av. Los Manzanos 101",
                FechaNac = Convert.ToDateTime("1982-02-14"),
                Email = "carlos@gmail.com"
            });
            return View(personas);
        }
    }
}