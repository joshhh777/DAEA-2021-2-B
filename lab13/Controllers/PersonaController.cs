using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using lab13.Models;

namespace lab13.Controllers
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
                Email = "j.cancino@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. Progreso 325",
                FechaNac = Convert.ToDateTime("1997-11-07"),
                Email = "maria@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Carlos",
                Apellido = "Martinez",
                Direccion = "Av. Los Manzanos 101",
                FechaNac = Convert.ToDateTime("1982-02-14"),
                Email = "carlitos@gmail.com"
            });
            return View(personas);
        }
        public ActionResult Mostrar(int id)
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Jose",
                Apellido = "Cancino",
                Direccion = "Av. Fco Bolognesi 311",
                FechaNac = Convert.ToDateTime("2000-01-27"),
                Email = "j.cancino@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. Progreso 325",
                FechaNac = Convert.ToDateTime("1997-11-07"),
                Email = "maria@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Carlos",
                Apellido = "Martinez",
                Direccion = "Av. Los Manzanos 101",
                FechaNac = Convert.ToDateTime("1982-02-14"),
                Email = "carlitos@gmail.com"
            });

            Persona persona = (from p in personas
                               where p.PersonaID == id
                               select p).FirstOrDefault();
            return View(persona);
        }

        public ActionResult Buscar(string nombre, string apellido)
        {
            List<Persona> personas = new List<Persona>();
            personas.Add(new Persona
            {
                PersonaID = 1,
                Nombre = "Jose",
                Apellido = "Cancino",
                Direccion = "Av. Fco Bolognesi 311",
                FechaNac = Convert.ToDateTime("2000-01-27"),
                Email = "j.cancino@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 2,
                Nombre = "Maria",
                Apellido = "Salas",
                Direccion = "Av. Progreso 325",
                FechaNac = Convert.ToDateTime("1997-11-07"),
                Email = "maria@gmail.com"
            });
            personas.Add(new Persona
            {
                PersonaID = 3,
                Nombre = "Carlos",
                Apellido = "Martinez",
                Direccion = "Av. Los Manzanos 101",
                FechaNac = Convert.ToDateTime("1982-02-14"),
                Email = "carlitos@gmail.com"
            });
           

            Persona persona = (from p in personas
                               where p.Nombre.Contains(nombre) || p.Apellido.Contains(apellido)
                               select p).First();
            return View(persona);
        }
    }
}