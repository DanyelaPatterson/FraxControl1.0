using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FraxControl;
using FraxControl.Controllers;
using FraxControl.Entities;
using FraxControl.Models;

namespace FraxControl.Controllers
{
public class VehiculosController : Controller
{
    private readonly ApplicationDbContext _context;

    public VehiculosController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult VehiculosList()
    {
        // VehiculoEntity vehiculo = new VehiculoEntity();
        // vehiculo.Modelo="Mazda 3";
        // vehiculo.Marca="Mazda";
        // vehiculo.Owner="Jaime Nuñez";
        // vehiculo.Placas="E8ST4S7";
        // vehiculo.Direccion="La Paloma #123";
        // this._context.Vehiculos.Add(vehiculo);
        // this._context.SaveChanges();

        List<VehiculoModel> list =_context.Vehiculos.Select(v => new VehiculoModel
        {
            Id = v.Id,
            Owner=v.Owner,
            Marca=v.Marca,
            Modelo=v.Modelo,
            Direccion=v.Direccion,
            Placas=v.Placas

        }).ToList();

        return View(list);
    }

    [HttpGet]
    public IActionResult AddVehiculos()
    {

        return View();
    }

    [HttpPost]
     public IActionResult AddVehiculos(VehiculoModel vehiculoModel)
    {
         if (ModelState.IsValid)
            {
                VehiculoEntity v = new VehiculoEntity();
                v.Id = vehiculoModel.Id;
                v.Modelo = vehiculoModel.Modelo;
                v.Marca=vehiculoModel.Marca;
                v.Owner = vehiculoModel.Owner;
                v.Direccion=vehiculoModel.Direccion;
                v.Placas=vehiculoModel.Placas;


                this._context.Vehiculos.Add(v);
                this._context.SaveChanges();
                return RedirectToAction("VehiculosList");

            }
        
        return View();
    }

        [HttpGet]
        public IActionResult DeleteVehiculos(int Id)
        {
            VehiculoEntity vehiculo = this._context.Vehiculos.Where(s => s.Id == Id).First();

            if (vehiculo == null)
            {
                return RedirectToAction("VehiculosList","Vehiculos");

            }

            VehiculoModel model = new VehiculoModel();
            model.Id = model.Id;
            model.Modelo = model.Modelo;
            model.Marca=model.Marca;
            model.Owner = model.Owner;
            model.Direccion=model.Direccion;
            model.Placas=model.Placas;

            return View (model);
        }

        [HttpPost]
        public IActionResult DeleteVehiculos(VehiculoModel vehiculoModel)
        {
            bool exists = this._context.Vehiculos.Any(a => a.Id == vehiculoModel.Id);
            if (!exists)
            {
                return View (vehiculoModel);
            }

            VehiculoEntity vehiculo = this._context.Vehiculos.Where (s => s.Id == vehiculoModel.Id).First();
            vehiculo.Modelo=vehiculoModel.Modelo;
            vehiculo.Marca=vehiculoModel.Marca;
            vehiculo.Owner=vehiculoModel.Owner;
            vehiculo.Direccion=vehiculoModel.Direccion;
            vehiculo.Placas=vehiculoModel.Placas;

            this._context.Vehiculos.Remove(vehiculo);
            this._context.SaveChanges();

            return RedirectToAction("VehiculosList","Vehiculos");

            
        }
    
    [HttpGet]
    public IActionResult EditVehiculos(int Id)
    {
            VehiculoEntity vehiculo = this._context.Vehiculos.Where(s => s.Id == Id).First();

            if (vehiculo==null)
            {
                return RedirectToAction("VehiculosList","Vehiculos");
            }

            VehiculoModel model = new VehiculoModel();
            model.Id = vehiculo.Id;
            model.Modelo=vehiculo.Modelo;
            model.Marca=vehiculo.Marca;
            model.Owner=vehiculo.Owner;
            model.Direccion=vehiculo.Direccion;
            model.Placas=vehiculo.Placas;

            return View(model);
        
    }

     [HttpPost]
     public IActionResult EditVehiculos(VehiculoModel vehiculoModel)
     {
        VehiculoEntity vehiculo = this._context.Vehiculos
        .Where(v => v.Id == vehiculoModel.Id).First();

        if(vehiculoModel == null)
        {
            return RedirectToAction("VehiculosModel");
        }
        vehiculo.Modelo=vehiculoModel.Modelo;
        vehiculo.Marca=vehiculoModel.Marca;
        vehiculo.Owner=vehiculoModel.Owner;
        vehiculo.Direccion=vehiculoModel.Direccion;
        vehiculo.Placas=vehiculoModel.Placas;


        this._context.Vehiculos.Update(vehiculo);
        this._context.SaveChanges();
       
       return RedirectToAction("VehiculosList","Vehiculos");

     }
}
}

