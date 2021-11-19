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
       // [Route("api/[controller]")]
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
        [HttpPost("addpizza")]
        //[ValidateAntiForgeryToken]
        public ActionResult<ContosoPizza.Models.Pizza> Create(string Name, bool IsGlutenFree)
        {
            ContosoPizza.Models.Pizza pizza = new ContosoPizza.Models.Pizza();

            pizza.Name = Name;
            pizza.IsGlutenFree = IsGlutenFree;
            PizzaService.Add(pizza);

            return pizza;


            //PizzaService.Add(pizza);

            //return pizza;
            //Console.WriteLine(name, a);
            //return false;
        }
        [HttpPut("updatepizza")]
        public ActionResult<string> Update(int UpdateID, string Name, bool IsGlutenFree)
        {
            ContosoPizza.Models.Pizza pizza = new ContosoPizza.Models.Pizza();

            pizza.Name = Name;
            pizza.IsGlutenFree = IsGlutenFree;

            if (PizzaService.Get(UpdateID) == null)
            {
                return "Cannot update because of invalid value";
            }
            else
            {
                pizza.Id = UpdateID;
                PizzaService.Update(pizza);
                return "Update successful!";
            }    
        }

        [HttpDelete("deletepizza")]
        public ActionResult<string> Delete(int DeleteID)
        {

            if (PizzaService.Get(DeleteID) == null)
            {
                return "Cannot delete because of invalid value";
            }
            else
            {
                PizzaService.Delete(DeleteID);
                return "Delete successful!";
            }
        }

        [HttpPost]
        public IActionResult Create(ContosoPizza.Models.Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ContosoPizza.Models.Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete1(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
