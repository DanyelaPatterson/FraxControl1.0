using Microsoft.AspNetCore.Mvc;
using FraxControl;
using FraxControl.Entities;
using FraxControl.Models;

namespace FraxControl.Controllers
{
public class SocialAreaController : Controller
{
    private readonly ApplicationDbContext _context;

    public SocialAreaController (ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult SocialAreaList()
    {
        List<SocialAreaModel> list =_context.AreasSociales.Select(x => new SocialAreaModel
        {
            Id = x.Id,
            Name=x.Name,
            Apellido=x.Apellido,
            FechaReserva=x.FechaReserva
        }).ToList();

        return View(list);
    }

    [HttpGet]
    public IActionResult AddSocialArea()
    {

        return View();
    }

    [HttpPost]
     public IActionResult AddSocialArea(SocialAreaModel socialAreaModel)
    {
         if (ModelState.IsValid)
            {
                SocialAreaEntity s = new SocialAreaEntity();
                s.Id = socialAreaModel.Id;
                s.Name = socialAreaModel.Name;
                s.Apellido=socialAreaModel.Apellido;
                s.FechaReserva=socialAreaModel.FechaReserva;


                this._context.AreasSociales.Add(s);
                this._context.SaveChanges();
                return RedirectToAction("SocialAreaList");

            }
        
        return View();
    }

        [HttpGet]
        public IActionResult DeleteSocialArea(int Id)
        {
            SocialAreaEntity vehiculo = this._context.AreasSociales.Where(s => s.Id == Id).First();

            if (vehiculo == null)
            {
                return RedirectToAction("SocialAreaList","SocialArea");

            }

            SocialAreaModel model = new SocialAreaModel();
            model.Id = model.Id;
            model.Name = model.Name;
            model.Apellido=model.Apellido;
            model.FechaReserva=model.FechaReserva;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteSocialArea(SocialAreaModel socialAreaModel)
        {
            bool exists = this._context.AreasSociales.Any(a => a.Id == socialAreaModel.Id);
            if (!exists)
            {
                return View (socialAreaModel);
            }

            SocialAreaEntity social = this._context.AreasSociales.Where (s => s.Id == socialAreaModel.Id).First();
            social.Name = socialAreaModel.Name;
            social.Apellido=socialAreaModel.Apellido;
            social.FechaReserva=socialAreaModel.FechaReserva;

            this._context.AreasSociales.Remove(social);
            this._context.SaveChanges();

            return RedirectToAction("SocialAreaList","SocialArea");

            
        }
    
    [HttpGet]
    public IActionResult EditSocialArea(int Id)
    {
            SocialAreaEntity social = this._context.AreasSociales.Where(s => s.Id == Id).First();

            if (social==null)
            {
                return RedirectToAction("SocialAreaList","SocialArea");
            }

            SocialAreaModel model = new SocialAreaModel();
            model.Id = social.Id;
            model.Name = social.Name;
            model.Apellido=social.Apellido;
            model.FechaReserva=social.FechaReserva;

            return View(model);
        
    }

     [HttpPost]
     public IActionResult EditSocialArea (SocialAreaModel socialAreaModel)
     {
        SocialAreaEntity social = this._context.AreasSociales
        .Where(v => v.Id == socialAreaModel.Id).First();

        if(socialAreaModel == null)
        {
            return RedirectToAction("SocialAreaModel");
        }
        social.Name = socialAreaModel.Name;
        social.Apellido=socialAreaModel.Apellido;
        social.FechaReserva=social.FechaReserva;


        this._context.AreasSociales.Update(social);
        this._context.SaveChanges();
       
       return RedirectToAction("SocialAreaList","Social");

     }

}}