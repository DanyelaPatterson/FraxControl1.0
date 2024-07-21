using Microsoft.AspNetCore.Mvc;
using FraxControl.Entities;
using FraxControl.Models;

namespace FraxControl.Controllers
{
    public class VisitasController : Controller 
    {

    private readonly ApplicationDbContext _context;

    public VisitasController(ApplicationDbContext context)
    {
        _context = context;
    }
    public ActionResult VisitasList()
    {
        List<VisitaModel> list =_context.Visitas.Select(x => new VisitaModel
        {
            Id = x.Id,
            Name=x.Name,
            Apellido=x.Apellido,
            Marca=x.Marca,
            Modelo=x.Modelo,
            Placas=x.Placas,
            FechaVisita=x.FechaVisita
        }).ToList();

        return View(list);
    }

    
    [HttpGet]
    public IActionResult AddVisita()
    {

        return View();
    }

     [HttpPost]
     public IActionResult AddVisita(VisitaModel visitaModel)
    {
         if (ModelState.IsValid)
            {
                VisitaEntity v = new VisitaEntity();
                v.Id = visitaModel.Id;
                v.Name = visitaModel.Name;
                v.Apellido = visitaModel.Apellido;
                v.Marca = visitaModel.Marca;
                v.Modelo = visitaModel.Modelo;
                v.Placas = visitaModel.Placas;
                v.FechaVisita=visitaModel.FechaVisita;


                this._context.Visitas.Add(v);
                this._context.SaveChanges();
                return RedirectToAction("VisitasList");

            }
        
        return View();
    }

    [HttpGet]
        public IActionResult DeleteVisita(int Id)
        {
            VisitaEntity visita = this._context.Visitas.Where(s => s.Id == Id).First();

            if (visita == null)
            {
                return RedirectToAction("VisitasList","Visitas");

            }

            VisitaModel model = new VisitaModel();
            model.Id = model.Id;
            model.Name = model.Name;
            model.Apellido=model.Apellido;
            model.Marca = model.Marca;
            model.Modelo=model.Modelo;
            model.Placas=model.Placas;
            model.FechaVisita=model.FechaVisita;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteVisita(VisitaModel visitaModel)
        {
            bool exists = this._context.Visitas.Any(a => a.Id == visitaModel.Id);
            if (!exists)
            {
                return View (visitaModel);
            }

            VisitaEntity visita = this._context.Visitas.Where (s => s.Id == visitaModel.Id).First();
            visita.Name=visitaModel.Name;
            visita.Apellido=visitaModel.Apellido;
            visita.Modelo=visitaModel.Modelo;
            visita.Marca=visitaModel.Marca;
            visita.Placas=visitaModel.Placas;
            visita.FechaVisita=visitaModel.FechaVisita;

            this._context.Visitas.Remove(visita);
            this._context.SaveChanges();

            return RedirectToAction("VisitasList","Visitas");

            
        }

        [HttpGet]
    public IActionResult EditVisita(int Id)
    {
            VisitaEntity visita = this._context.Visitas.Where(s => s.Id == Id).First();

            if (visita==null)
            {
                return RedirectToAction("VisitasList","Visitas");
            }

            VisitaModel model = new VisitaModel();
            model.Id = visita.Id;
            model.Name = visita.Name;
            model.Apellido=visita.Apellido;
            model.Marca=visita.Marca;
            model.Modelo=visita.Modelo;
            model.Placas=visita.Placas;
            model.FechaVisita=visita.FechaVisita;


            return View(model);
        
    }

     [HttpPost]
     public IActionResult EditVisita(VisitaModel visitaModel)
     {
        VisitaEntity visita = this._context.Visitas
        .Where(v => v.Id == visitaModel.Id).First();

        if(visitaModel == null)
        {
            return RedirectToAction("VisitaModel");
        }
        visita.Name = visitaModel.Name;
        visita.Apellido=visitaModel.Apellido;
        visita.Marca=visitaModel.Marca;
        visita.Modelo=visitaModel.Modelo;
        visita.Placas=visitaModel.Placas;
        visita.FechaVisita=visitaModel.FechaVisita;


        this._context.Visitas.Update(visita);
        this._context.SaveChanges();
       
       return RedirectToAction("VisitasList","Visitas");

     }


    }

    
}
