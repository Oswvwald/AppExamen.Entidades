using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppExamen.Entidades;
using AppExamen.ConsumeAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppExamen.MVCWEB.Controllers
{
    public class FarmacosController : Controller
    {
        private string urlApi;
        private readonly string _marcaApi;

        public FarmacosController(IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "") + "/Farmacos";
            _marcaApi = configuration.GetValue("ApiUrlBase", "") + "/MarcaFarmaceuticas";
        }

        // GET: FarmacosController
        public ActionResult Index()
        {
            var data = Crud<Farmaco>.Read(urlApi);
            return View(data);
        }

        // GET: FarmacosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<Farmaco>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: FarmacosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FarmacosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Farmaco data)
        {
            try
            {
                var newData = Crud<Farmaco>.Create(urlApi, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: FarmacosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<Farmaco>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: FarmacosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Farmaco data)
        {
            try
            {
                Crud<Farmaco>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: FarmacosController/Delete/5
        public ActionResult Delete(int id)
        {
            var data = Crud<Farmaco>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: FarmacosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Farmaco data)
        {
            try
            {
                Crud<Farmaco>.Delete(urlApi, id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }
    }
}
