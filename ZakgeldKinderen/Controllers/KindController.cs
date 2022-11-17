using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZakgeldKinderen.Models;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ZakgeldKinderen.Controllers
{
    public class KindController : Controller
    {
        private Dictionary<int, Kind> kinderen = new()
        {
            {
                1, new Kind(){Id = 1, Naam = "Jonas", Zakgeld = 10m}
            },
            {
                2, new Kind(){Id = 2, Naam = "Maarten", Zakgeld = 7m}
            }
        };

        public Kind? Read(int id)
        {
            Kind? gelezenKind = null;
            kinderen.TryGetValue(id, out gelezenKind);
            return gelezenKind;
        }

        public IActionResult Index()
        {
            
            
            return View(kinderen.Values.ToList());
        }

        public IActionResult Verwijderd()
        {
            var tempdata = (string?)this.TempData.Peek("kind");
            if (tempdata != null)
            {
                Kind? kind = JsonConvert.DeserializeObject<Kind?>(tempdata);
                return View(kind);
            }
            else
                return Redirect("~/kind");
        }
        public IActionResult VerwijderKind(int id)
        {
            var kind = Read(id);
            if (kind == null) ViewBag.kindnummer = id;
            return View(kind);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var kind = Read(id);
            this.TempData["kind"] = JsonConvert.SerializeObject(kind);
            kinderen.Remove(id);
            return RedirectToAction(nameof(Verwijderd));
        }

        [HttpGet]
        public IActionResult Toevoegen()
        {
            var kind = new Kind();
            return View(kind);
        }

        [HttpPost]
        public IActionResult Toevoegen(Kind k)
        {
                k.Id = kinderen.Keys.Max() + 1;
                kinderen.Add(k.Id, k);
                return RedirectToAction(nameof(Index));
        }
    }
}
