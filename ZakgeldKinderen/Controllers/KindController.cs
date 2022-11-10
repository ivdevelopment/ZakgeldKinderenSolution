using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json.Serialization;
using ZakgeldKinderen.Models;

namespace ZakgeldKinderen.Controllers
{
    public class KindController : Controller
    {
        /*private List<Kinderen> kinderen = new()
        {
            {new(){ Naam = "Maarten", Zakgeld = 10m }},
            {new(){ Naam = "Jonas", Zakgeld = 7m }}
        };*/
        public IActionResult Index()
        {
            List<Kinderen> kinderen;
            
            return View();
        }

        /*[HttpGet]
        public IActionResult VerwijderKind(string naam)
        {
            Kinderen? gelezenKind = null;
            if (kinderen.ToString().Contains(naam))
                kinderen.Remove(naam);
            return gelezenPersoon;
            return View(persoon);
        }

        [HttpPost]
        public IActionResult Verwijderen(int id)
        {
            _persoonService.Delete(id);
            return RedirectToAction(nameof(Index));
        }*/
    }
}
