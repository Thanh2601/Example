using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    public class PizzaController : Controller
    {

        [HttpGet]
        // GET: PizzaController
        public ActionResult<List<ContosoPizza.Models.Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("id")]
        // GET: PizzaController/Details/5
        public ActionResult<ContosoPizza.Models.Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();
            return pizza;
        }


        // POST: PizzaController/Create
        [HttpPost("id")]
        [ValidateAntiForgeryToken]
        public ActionResult<ContosoPizza.Models.Pizza> Create(ContosoPizza.Models.Pizza pizza)
        {
            PizzaService.Add(pizza);

            return pizza;
    
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
