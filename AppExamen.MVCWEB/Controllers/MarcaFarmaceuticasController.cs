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
    public class MarcaFarmaceuticasController : Controller
    {
        private string urlApi;

        public MarcaFarmaceuticasController (IConfiguration configuration)
        {
            urlApi = configuration.GetValue("ApiUrlBase", "").ToString() + "/MarcaFarmaceuticas";
        }

        // GET: DepartamentosController
        public ActionResult Index()
        {
            var data = Crud<MarcaFarmaceutica>.Read(urlApi);
            return View(data);
        }

        // GET: DepartamentosController/Details/5
        public ActionResult Details(int id)
        {
            var data = Crud<MarcaFarmaceutica>.Read_ById(urlApi, id);
            return View(data);
        }

        // GET: DepartamentosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartamentosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MarcaFarmaceutica data)
        {
            try
            {
                var newData = Crud<MarcaFarmaceutica>.Create(urlApi, data);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: DepartamentosController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = Crud<MarcaFarmaceutica>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: DepartamentosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MarcaFarmaceutica data)
        {
            try
            {
                Crud<MarcaFarmaceutica>.Update(urlApi, id, data);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(data);
            }
        }

        // GET: DepartamentosController/Delete/5    
        public ActionResult Delete(int id)
        {
            var data = Crud<MarcaFarmaceutica>.Read_ById(urlApi, id);
            return View(data);
        }

        // POST: DepartamentosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MarcaFarmaceutica data)
        {
            try
            {
                Crud<MarcaFarmaceutica>.Delete(urlApi, id);
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
